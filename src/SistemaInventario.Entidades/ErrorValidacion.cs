using System;

namespace SistemaInventario.Entidades
{
// indica en cual campo de la pantalla debe salir el error
public class ErrorValidacion
{
    public string Campo { get; private set; }
    public string Mensaje { get; private set; }
    // crea el error que despues se muestra con ErrorProvider
    /// <summary>
    /// guarda el campo y el mensaje de un error de validacion
    /// </summary>
    /// <param name="campo">nombre del campo que se esta validando</param>
    /// <param name="mensaje">dato que necesita la operacion</param>
    public ErrorValidacion(string campo, string mensaje) { Campo = campo; Mensaje = mensaje; }
}
}
