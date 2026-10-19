using System;
using SistemaInventario.Entidades;
using System.Data;
using System.Data.SqlClient;
namespace SistemaInventario.AccesoDatos
{
// busca las cuentas activas en SQL Server
public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly IConexionBD conexion;
    // recibe por constructor lo que va a usar para abrir las conexiones
    /// <summary>
    /// prepara el repositorio que consulta las cuentas de usuario
    /// </summary>
    /// <param name="conexion">conexion usada para comunicarse con SQL Server</param>
    public UsuarioRepositorio(IConexionBD conexion) { this.conexion = conexion; }
    // busca la cuenta y deja que la capa de negocio revise la clave
    /// <summary>
    /// busca una cuenta por su nombre de usuario
    /// </summary>
    /// <param name="nombreUsuario">nombre de usuario que se busca</param>
    /// <returns>resultado de la operacion</returns>
    public Usuario BuscarPorNombre(string nombreUsuario)
    {
        try
        {
            using (SqlConnection cn = conexion.CrearConexion())
            using (SqlCommand comando = new SqlCommand("dbo.sp_Usuario_Buscar", cn))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar, 50).Value = nombreUsuario;
                cn.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (!lector.Read()) return null;
                    return new Usuario { Id = (int)lector["Id"], NombreUsuario = (string)lector["NombreUsuario"],
                        NombreCompleto = (string)lector["NombreCompleto"], Rol = (string)lector["Rol"],
                        ClaveHash = (string)lector["ClaveHash"], Sal = (string)lector["Sal"], Activo = (bool)lector["Activo"],
                        FechaCreacion = (DateTime)lector["FechaCreacion"], FechaModificacion = (DateTime)lector["FechaModificacion"] };
                }
            }
        }
        catch (SqlException ex)
        {
            // guarda el detalle del error y en pantalla muestra un mensaje mas sencillo
            Logger.Registrar(ex);
            throw new DatosException("No se pudo iniciar sesion. Revisa que SQL Server este iniciado, que exista SistemaInventarioDB y que el servidor de App.config sea correcto.", ex);
        }
    }
}
}
