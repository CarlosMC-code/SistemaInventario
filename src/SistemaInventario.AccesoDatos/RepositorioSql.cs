using System;
using SistemaInventario.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace SistemaInventario.AccesoDatos
{
// pone el codigo de SQL que se repite en los repositorios
public abstract class RepositorioSql<T> : IRepositorio<T> where T : EntidadBase
{
    protected readonly IConexionBD conexion;
    protected abstract string Consulta { get; }
    protected abstract string PrefijoProcedimiento { get; }
    // recibe por constructor lo que usa para abrir las conexiones
    /// <summary>
    /// recibe la conexion que utilizan las operaciones del repositorio
    /// </summary>
    /// <param name="conexion">conexion usada para comunicarse con SQL Server</param>
    protected RepositorioSql(IConexionBD conexion) { this.conexion = conexion ?? throw new ArgumentNullException(nameof(conexion)); }
    /// <summary>
    /// convierte los datos de SQL Server en una entidad del sistema
    /// </summary>
    /// <param name="lector">lector con los datos devueltos por SQL Server</param>
    /// <returns>resultado de la operacion</returns>
    protected abstract T Leer(SqlDataReader lector);
    /// <summary>
    /// agrega los parametros SQL necesarios para guardar la entidad
    /// </summary>
    /// <param name="comando">comando SQL al que se agregan los parametros</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected abstract void AgregarParametros(SqlCommand comando, T entidad);
    /// <summary>
    /// guarda los datos relacionados con la entidad dentro de la transaccion
    /// </summary>
    /// <param name="cn">conexion abierta a SQL Server</param>
    /// <param name="transaccion">transaccion de la operacion actual</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    /// <param name="id">identificador del registro</param>
    protected virtual void GuardarDetalles(SqlConnection cn, SqlTransaction transaccion, T entidad, int id) { }
    /// <summary>
    /// carga los datos relacionados con la entidad desde SQL Server
    /// </summary>
    /// <param name="cn">conexion abierta a SQL Server</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected virtual void CargarDetalles(SqlConnection cn, T entidad) { }
    /// <summary>
    /// copia los campos comunes desde el lector de SQL
    /// </summary>
    /// <param name="lector">lector con los datos devueltos por SQL Server</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected static void LeerBase(SqlDataReader lector, EntidadBase entidad)
    {
        entidad.Id = (int)lector["Id"]; entidad.Activo = (bool)lector["Activo"];
        entidad.FechaCreacion = (DateTime)lector["FechaCreacion"];
        entidad.FechaModificacion = (DateTime)lector["FechaModificacion"];
    }
    /// <summary>
    /// ejecuta una lectura SQL y registra cualquier error de la base
    /// </summary>
    /// <param name="accion">operacion que se ejecutara en SQL Server</param>
    /// <returns>resultado de la operacion</returns>
    protected TResult Ejecutar<TResult>(Func<SqlConnection, TResult> accion)
    {
        // el using cierra la conexion aunque SQL Server de un error
        try { using (SqlConnection cn = conexion.CrearConexion()) { cn.Open(); return accion(cn); } }
        catch (SqlException ex)
        {
            Logger.Registrar(ex);
            string mensaje = ex.Number >= 50000 ? ex.Message :
                (ex.Number == 2601 || ex.Number == 2627 ? "Ya existe un registro con ese nombre, incluso en la papelera." :
                "No se pudo completar la operacion en SQL Server. Revisa la conexion o el archivo errores.log.");
            throw new DatosException(mensaje, ex);
        }
    }
    /// <summary>
    /// realiza una escritura SQL dentro de una transaccion
    /// </summary>
    /// <param name="accion">operacion que se ejecutara en SQL Server</param>
    /// <returns>resultado de la operacion</returns>
    protected TResult Escribir<TResult>(Func<SqlConnection, SqlTransaction, TResult> accion)
    {
        return Ejecutar(cn =>
        {
            using (SqlTransaction transaccion = cn.BeginTransaction())
            {
                try { TResult resultado = accion(cn, transaccion); transaccion.Commit(); return resultado; }
                catch
                {
                    // si algo falla deshace todo para que no quede guardado a medias
                    try { transaccion.Rollback(); }
                    catch (SqlException ex) { Logger.Registrar(ex); }
                    catch (InvalidOperationException ex) { Logger.Registrar(ex); }
                    throw;
                }
            }
        });
    }
    // trae los registros activos si no se le pide otra cosa
    /// <summary>
    /// obtiene los registros activos o todos si se solicita
    /// </summary>
    /// <param name="incluirInactivos">indica si se incluyen los registros inactivos</param>
    /// <returns>resultado de la operacion</returns>
    public List<T> Listar(bool incluirInactivos = false)
    {
        return Ejecutar(cn =>
        {
            List<T> lista = new List<T>();
            using (SqlCommand comando = new SqlCommand(Consulta + (incluirInactivos ? "" : " WHERE t.Activo = 1") + " ORDER BY t.Id", cn))
            using (SqlDataReader lector = comando.ExecuteReader()) while (lector.Read()) lista.Add(Leer(lector));
            return lista;
        });
    }
    // busca el registro y trae tambien sus detalles
    /// <summary>
    /// busca un registro por su identificador
    /// </summary>
    /// <param name="id">identificador del registro</param>
    /// <returns>resultado de la operacion</returns>
    public T Obtener(int id)
    {
        return Ejecutar(cn =>
        {
            T entidad = null;
            using (SqlCommand comando = new SqlCommand(Consulta + " WHERE t.Id = @Id", cn))
            {
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                using (SqlDataReader lector = comando.ExecuteReader()) if (lector.Read()) entidad = Leer(lector);
            }
            if (entidad != null) CargarDetalles(cn, entidad);
            return entidad;
        });
    }
    // guarda con un procedimiento almacenado y devuelve el id
    /// <summary>
    /// guarda un registro nuevo y devuelve su identificador
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    /// <returns>identificador o valor calculado por la operacion</returns>
    public int Agregar(T entidad)
    {
        return Escribir((cn, transaccion) =>
        {
            using (SqlCommand comando = CrearComando(cn, transaccion, "Agregar"))
            {
                AgregarParametros(comando, entidad);
                SqlParameter salida = comando.Parameters.Add("@Id", SqlDbType.Int); salida.Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery(); int id = (int)salida.Value;
                GuardarDetalles(cn, transaccion, entidad, id); return id;
            }
        });
    }
    // guarda todo en la misma transaccion para que no quede nada a medias
    /// <summary>
    /// guarda los cambios hechos a un registro existente
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    public void Actualizar(T entidad)
    {
        Escribir((cn, transaccion) =>
        {
            using (SqlCommand comando = CrearComando(cn, transaccion, "Actualizar"))
            {
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = entidad.Id;
                AgregarParametros(comando, entidad); comando.ExecuteNonQuery();
                GuardarDetalles(cn, transaccion, entidad, entidad.Id); return 0;
            }
        });
    }
    // lo manda a la papelera sin borrar la fila de la base
    /// <summary>
    /// marca un registro como inactivo sin borrarlo fisicamente
    /// </summary>
    /// <param name="id">identificador del registro</param>
    public void Eliminar(int id) { CambiarEstado(id, "Eliminar"); }
    // lo saca de la papelera si pasa las revisiones del procedimiento
    /// <summary>
    /// vuelve a activar un registro que estaba en la papelera
    /// </summary>
    /// <param name="id">identificador del registro</param>
    public void Restaurar(int id) { CambiarEstado(id, "Restaurar"); }
    private void CambiarEstado(int id, string accion)
    {
        Escribir((cn, transaccion) =>
        {
            using (SqlCommand comando = CrearComando(cn, transaccion, accion))
            { comando.Parameters.Add("@Id", SqlDbType.Int).Value = id; comando.ExecuteNonQuery(); return 0; }
        });
    }
    /// <summary>
    /// prepara el comando del procedimiento almacenado
    /// </summary>
    /// <param name="cn">conexion abierta a SQL Server</param>
    /// <param name="transaccion">transaccion de la operacion actual</param>
    /// <param name="accion">operacion que se ejecutara en SQL Server</param>
    /// <returns>resultado de la operacion</returns>
    protected SqlCommand CrearComando(SqlConnection cn, SqlTransaction transaccion, string accion)
    { return new SqlCommand("dbo.sp_" + PrefijoProcedimiento + "_" + accion, cn, transaccion) { CommandType = CommandType.StoredProcedure }; }
}
}
