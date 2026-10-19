using System;
using SistemaInventario.Entidades;
using System.Data;
using System.Data.SqlClient;
namespace SistemaInventario.AccesoDatos
{
// aqui se guardan y se buscan los suplidores en SQL Server
public class SuplidorRepositorio : RepositorioSql<Suplidor>
{
    // recibe la conexion por constructor
    /// <summary>
    /// prepara el repositorio de suplidores con su conexion
    /// </summary>
    /// <param name="conexion">conexion usada para comunicarse con SQL Server</param>
    public SuplidorRepositorio(IConexionBD conexion) : base(conexion) { }
    protected override string Consulta { get { return "SELECT t.* FROM dbo.Suplidores t"; } }
    protected override string PrefijoProcedimiento { get { return "Suplidor"; } }
    /// <summary>
    /// convierte los datos de SQL Server en una entidad del sistema
    /// </summary>
    /// <param name="lector">lector con los datos devueltos por SQL Server</param>
    /// <returns>resultado de la operacion</returns>
    protected override Suplidor Leer(SqlDataReader lector)
    {
        Suplidor entidad = new Suplidor(); LeerBase(lector, entidad);
            entidad.NombreEmpresa = (string)lector["NombreEmpresa"];
            entidad.NombreContacto = (string)lector["NombreContacto"];
            entidad.Telefono = (string)lector["Telefono"];
            entidad.Correo = (string)lector["Correo"];
            entidad.SitioWeb = (string)lector["SitioWeb"];
        return entidad;
    }
    /// <summary>
    /// agrega los parametros SQL necesarios para guardar la entidad
    /// </summary>
    /// <param name="comando">comando SQL al que se agregan los parametros</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void AgregarParametros(SqlCommand comando, Suplidor entidad)
    {
            comando.Parameters.Add("@NombreEmpresa", SqlDbType.NVarChar, 150).Value = entidad.NombreEmpresa;
            comando.Parameters.Add("@NombreContacto", SqlDbType.NVarChar, 100).Value = entidad.NombreContacto;
            comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 12).Value = entidad.Telefono;
            comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 150).Value = entidad.Correo;
            comando.Parameters.Add("@SitioWeb", SqlDbType.NVarChar, 250).Value = entidad.SitioWeb;
    }

}
}
