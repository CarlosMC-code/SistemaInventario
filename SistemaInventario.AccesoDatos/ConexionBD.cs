using System;
using SistemaInventario.Entidades;
using System.Configuration;
using System.Data.SqlClient;
namespace SistemaInventario.AccesoDatos
{
// usa Singleton para tener la configuracion de SQL Server en un solo lugar
public sealed class ConexionBD : IConexionBD
{
    private static readonly Lazy<ConexionBD> instancia = new Lazy<ConexionBD>(() => new ConexionBD());
    private readonly string cadena;
    private ConexionBD()
    {
        ConnectionStringSettings configuracion = ConfigurationManager.ConnectionStrings["InventarioDB"];
        if (configuracion == null) throw new InvalidOperationException("Falta InventarioDB en App.config.");
        cadena = configuracion.ConnectionString;
    }
    public static ConexionBD Instancia { get { return instancia.Value; } }
    // crea una conexion por operacion y ADO.NET se encarga de reutilizar los recursos
    /// <summary>
    /// crea una conexion nueva a SQL Server con la configuracion actual
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public SqlConnection CrearConexion() { return new SqlConnection(cadena); }
}
}
