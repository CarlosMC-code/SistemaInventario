using System;
using SistemaInventario.Entidades;
using System.Data;
using System.Data.SqlClient;
namespace SistemaInventario.AccesoDatos
{
// aqui se guardan y se buscan las categorias en SQL Server
public class CategoriaRepositorio : RepositorioSql<Categoria>
{
    // recibe la conexion por constructor
    /// <summary>
    /// prepara el repositorio de categorias con su conexion
    /// </summary>
    /// <param name="conexion">conexion usada para comunicarse con SQL Server</param>
    public CategoriaRepositorio(IConexionBD conexion) : base(conexion) { }
    protected override string Consulta { get { return "SELECT t.*, (SELECT COUNT(*) FROM dbo.FotosCategoria f WHERE f.CategoriaId = t.Id AND f.Activo = 1) AS FotosActivas FROM dbo.Categorias t"; } }
    protected override string PrefijoProcedimiento { get { return "Categoria"; } }
    /// <summary>
    /// convierte los datos de SQL Server en una entidad del sistema
    /// </summary>
    /// <param name="lector">lector con los datos devueltos por SQL Server</param>
    /// <returns>resultado de la operacion</returns>
    protected override Categoria Leer(SqlDataReader lector)
    {
        Categoria entidad = new Categoria(); LeerBase(lector, entidad);
            entidad.Nombre = (string)lector["Nombre"];
            entidad.Descripcion = (string)lector["Descripcion"];
            entidad.CantidadFotos = Convert.ToInt32(lector["FotosActivas"]);
        return entidad;
    }
    /// <summary>
    /// agrega los parametros SQL necesarios para guardar la entidad
    /// </summary>
    /// <param name="comando">comando SQL al que se agregan los parametros</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void AgregarParametros(SqlCommand comando, Categoria entidad)
    {
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = entidad.Nombre;
            comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 500).Value = entidad.Descripcion;
    }

    /// <summary>
    /// carga los datos relacionados con la entidad desde SQL Server
    /// </summary>
    /// <param name="cn">conexion abierta a SQL Server</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void CargarDetalles(SqlConnection cn, Categoria entidad)
    {
        using (SqlCommand comando = new SqlCommand("SELECT * FROM dbo.FotosCategoria WHERE CategoriaId=@Id AND Activo=1 ORDER BY Id", cn))
        {
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = entidad.Id;
            using (SqlDataReader lector = comando.ExecuteReader())
                while (lector.Read())
                {
                    FotoCategoria foto = new FotoCategoria { CategoriaId = entidad.Id, NombreArchivo = (string)lector["NombreArchivo"], Contenido = (byte[])lector["Contenido"] };
                    LeerBase(lector, foto); entidad.Fotos.Add(foto);
                }
        }
        entidad.CantidadFotos = entidad.Fotos.Count;
    }
    /// <summary>
    /// guarda los datos relacionados con la entidad dentro de la transaccion
    /// </summary>
    /// <param name="cn">conexion abierta a SQL Server</param>
    /// <param name="transaccion">transaccion de la operacion actual</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    /// <param name="id">identificador del registro</param>
    protected override void GuardarDetalles(SqlConnection cn, SqlTransaction transaccion, Categoria entidad, int id)
    {
        // guarda la categoria y sus fotos juntas y si algo falla deshace todo
        using (SqlCommand limpiar = new SqlCommand("dbo.sp_FotoCategoria_Desactivar", cn, transaccion))
        {
            limpiar.CommandType = CommandType.StoredProcedure;
            limpiar.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = id; limpiar.ExecuteNonQuery();
        }
        foreach (FotoCategoria foto in entidad.Fotos)
            using (SqlCommand comando = new SqlCommand("dbo.sp_FotoCategoria_Agregar", cn, transaccion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@NombreArchivo", SqlDbType.NVarChar, 260).Value = foto.NombreArchivo;
                comando.Parameters.Add("@Contenido", SqlDbType.VarBinary, -1).Value = foto.Contenido;
                comando.ExecuteNonQuery();
            }
    }
}
}
