using System;

namespace SistemaInventario.Entidades
{
// error de la base con un mensaje que se le puede mostrar al usuario
public class DatosException : Exception
{
    // guarda tambien el error original para anotarlo en el log
    /// <summary>
    /// crea un error de datos y conserva la excepcion original
    /// </summary>
    /// <param name="mensaje">dato que necesita la operacion</param>
    /// <param name="interna">dato que necesita la operacion</param>
    public DatosException(string mensaje, Exception interna) : base(mensaje, interna) { }
}
}
