using System;
using SistemaInventario.Entidades;
using System.Data.SqlClient;
namespace SistemaInventario.AccesoDatos
{
// sirve para pasar la conexion a los repositorios
public interface IConexionBD
{
    // crea una conexion nueva para cada operacion
    /// <summary>
    /// crea una conexion nueva a SQL Server con la configuracion actual
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    SqlConnection CrearConexion();
}
}
