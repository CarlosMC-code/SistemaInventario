using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// junta los errores de los campos para mostrarlos con ErrorProvider
public class ValidacionException : Exception
{
    public List<ErrorValidacion> Errores { get; private set; }
    // guarda los campos que tienen errores para mostrarlos todos juntos
    /// <summary>
    /// crea un error con los datos que no pasaron la validacion
    /// </summary>
    /// <param name="errores">lista donde se guardan los errores encontrados</param>
    public ValidacionException(IEnumerable<ErrorValidacion> errores) : base("Revisa los campos indicados.") { Errores = errores.ToList(); }
    // crea un error para un solo campo
    /// <summary>
    /// crea un error con los datos que no pasaron la validacion
    /// </summary>
    /// <param name="campo">nombre del campo que se esta validando</param>
    /// <param name="mensaje">dato que necesita la operacion</param>
    public ValidacionException(string campo, string mensaje) : this(new[] { new ErrorValidacion(campo, mensaje) }) { }
}
}
