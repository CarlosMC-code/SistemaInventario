using System;
using SistemaInventario.Entidades;
using System.Data;
using System.Data.SqlClient;
namespace SistemaInventario.AccesoDatos
{
// aqui se guardan y se buscan los productos en SQL Server
public class ProductoRepositorio : RepositorioSql<Producto>
{
    // recibe la conexion por constructor
    /// <summary>
    /// prepara el repositorio de productos con su conexion
    /// </summary>
    /// <param name="conexion">conexion usada para comunicarse con SQL Server</param>
    public ProductoRepositorio(IConexionBD conexion) : base(conexion) { }
    protected override string Consulta { get { return "SELECT t.* FROM dbo.Productos t"; } }
    protected override string PrefijoProcedimiento { get { return "Producto"; } }
    /// <summary>
    /// convierte los datos de SQL Server en una entidad del sistema
    /// </summary>
    /// <param name="lector">lector con los datos devueltos por SQL Server</param>
    /// <returns>resultado de la operacion</returns>
    protected override Producto Leer(SqlDataReader lector)
    {
        Producto entidad = new Producto(); LeerBase(lector, entidad);
            entidad.Nombre = (string)lector["Nombre"];
            entidad.PrecioUnitario = (decimal)lector["PrecioUnitario"];
            entidad.CategoriaId = (int)lector["CategoriaId"];
            entidad.SuplidorId = (int)lector["SuplidorId"];
            entidad.FotoNombre = lector["FotoNombre"] == DBNull.Value ? "" : (string)lector["FotoNombre"];
            entidad.Foto = lector["Foto"] == DBNull.Value ? null : (byte[])lector["Foto"];
        return entidad;
    }
    /// <summary>
    /// agrega los parametros SQL necesarios para guardar la entidad
    /// </summary>
    /// <param name="comando">comando SQL al que se agregan los parametros</param>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void AgregarParametros(SqlCommand comando, Producto entidad)
    {
            comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = entidad.Nombre;
            SqlParameter precio = comando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
            precio.Precision = 18; precio.Scale = 2; precio.Value = entidad.PrecioUnitario;
            comando.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = entidad.CategoriaId;
            comando.Parameters.Add("@SuplidorId", SqlDbType.Int).Value = entidad.SuplidorId;
            comando.Parameters.Add("@FotoNombre", SqlDbType.NVarChar, 260).Value =
                string.IsNullOrEmpty(entidad.FotoNombre) ? (object)DBNull.Value : entidad.FotoNombre;
            comando.Parameters.Add("@Foto", SqlDbType.VarBinary, -1).Value = (object)entidad.Foto ?? DBNull.Value;
    }

}
}
