using System;
using SistemaInventario.Entidades;
using System.IO;
using System.Text;
namespace SistemaInventario.AccesoDatos
{
// guarda el error para poder revisarlo despues
public static class Logger
{
    private static readonly object bloqueo = new object();
    /// <summary>
    /// indica en que archivo se guardan los errores
    /// </summary>
    public static string RutaArchivo { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SistemaInventario", "errores.log"); } }
    // anota la fecha y el error en el log sin meter las claves de los usuarios
    /// <summary>
    /// guarda el error y sus detalles en el archivo de registro
    /// </summary>
    /// <param name="error">excepcion que se va a registrar o mostrar</param>
    public static void Registrar(Exception error)
    {
        if (error == null) return;
        try
        {
            lock (bloqueo)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(RutaArchivo));
                File.AppendAllText(RutaArchivo, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + error + Environment.NewLine + Environment.NewLine, Encoding.UTF8);
            }
        }
        catch (IOException) { System.Diagnostics.Debug.WriteLine(error); }
        catch (UnauthorizedAccessException) { System.Diagnostics.Debug.WriteLine(error); }
    }
}
}
