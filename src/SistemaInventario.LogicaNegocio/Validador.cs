using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;
using System.Globalization;
using System.Text.RegularExpressions;
namespace SistemaInventario.LogicaNegocio
{
// aqui revisa los datos que se piden en varios formularios
public static class Validador
{
    // quita los espacios que sobran y revisa que el texto tenga el largo permitido
    /// <summary>
    /// revisa que un texto cumpla con la longitud permitida
    /// </summary>
    /// <param name="errores">lista donde se guardan los errores encontrados</param>
    /// <param name="campo">nombre del campo que se esta validando</param>
    /// <param name="valor">dato que necesita la operacion</param>
    /// <param name="minimo">valor minimo permitido</param>
    /// <param name="maximo">valor maximo permitido</param>
    /// <returns>texto calculado por la operacion</returns>
    public static string Texto(List<ErrorValidacion> errores, string campo, string valor, int minimo, int maximo)
    {
        valor = (valor ?? "").Trim();
        if (valor.Length < minimo || valor.Length > maximo)
            errores.Add(new ErrorValidacion(campo, "Debe tener entre " + minimo + " y " + maximo + " caracteres."));
        return valor;
    }
    // junta los errores para que salgan todos a la vez en el formulario
    /// <summary>
    /// detiene el guardado cuando existen errores de validacion
    /// </summary>
    /// <param name="errores">lista donde se guardan los errores encontrados</param>
    public static void LanzarSiHay(List<ErrorValidacion> errores)
    { if (errores.Count > 0) throw new ValidacionException(errores); }
    // revisa que el precio sea mayor a cero y no pase de dos decimales
    /// <summary>
    /// comprueba que el precio sea positivo y tenga como maximo dos decimales
    /// </summary>
    /// <param name="errores">lista donde se guardan los errores encontrados</param>
    /// <param name="precio">precio que se va a validar</param>
    public static void Precio(List<ErrorValidacion> errores, decimal precio)
    {
        // revisa los decimales sin redondear y avisa si se escribieron de mas
        int decimales = (decimal.GetBits(precio)[3] >> 16) & 0x7F;
        if (precio <= 0 || precio > 9999999999999999.99m || decimales > 2)
            errores.Add(new ErrorValidacion("PrecioUnitario", "El precio debe ser mayor que cero, con maximo 2 decimales y dentro del rango DECIMAL(18,2)."));
    }
    // convierte el precio aqui para no repetir lo mismo en cada formulario
    /// <summary>
    /// convierte un texto en un precio valido
    /// </summary>
    /// <param name="texto">texto usado para buscar o convertir datos</param>
    /// <returns>precio convertido a numero decimal</returns>
    public static decimal LeerPrecio(string texto)
    {
        decimal precio;
        NumberStyles estilo = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
        if (!decimal.TryParse(texto, estilo, CultureInfo.GetCultureInfo("es-DO"), out precio))
            throw new ValidacionException("PrecioUnitario", "Escribe un precio valido, por ejemplo 1500.50, sin separadores de miles.");
        return precio;
    }
    // revisa que el telefono tenga el formato dominicano que se pidio
    /// <summary>
    /// comprueba que el telefono tenga el formato dominicano requerido
    /// </summary>
    /// <param name="telefono">dato que necesita la operacion</param>
    /// <returns>verdadero si pasa la comprobacion; falso en caso contrario</returns>
    public static bool TelefonoValido(string telefono)
    { return Regex.IsMatch(telefono ?? "", @"^(809|829|849)-\d{3}-\d{4}$", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(200)); }
    // revisa el formato del correo con una expresion regular
    /// <summary>
    /// comprueba que el correo tenga un formato permitido
    /// </summary>
    /// <param name="correo">dato que necesita la operacion</param>
    /// <returns>verdadero si pasa la comprobacion; falso en caso contrario</returns>
    public static bool CorreoValido(string correo)
    { return Regex.IsMatch(correo ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(200)); }
    // acepta una direccion con http o https y tambien deja el campo vacio
    /// <summary>
    /// comprueba la direccion web cuando no esta vacia
    /// </summary>
    /// <param name="web">dato que necesita la operacion</param>
    /// <returns>verdadero si pasa la comprobacion; falso en caso contrario</returns>
    public static bool WebValida(string web)
    {
        if (string.IsNullOrWhiteSpace(web)) return true;
        Uri uri;
        return Uri.TryCreate(web, UriKind.Absolute, out uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps) && !string.IsNullOrWhiteSpace(uri.Host);
    }
}
}
