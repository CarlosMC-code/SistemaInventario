using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// avisa cuando la cuenta no tiene permiso para hacer algo
public class PermisoException : Exception
{
    // crea el mensaje que le va a salir al usuario
    /// <summary>
    /// crea un error de acceso con su mensaje
    /// </summary>
    /// <param name="mensaje">dato que necesita la operacion</param>
    public PermisoException(string mensaje) : base(mensaje) { }
}
}
