using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// asi sirve la misma busqueda para distintos tipos de listas
public static class BusquedaGenerica
{
    // busca por una parte del texto sin importar las mayusculas y ordena el resultado
    /// <summary>
    /// aplica una busqueda generica sin distinguir mayusculas y minusculas
    /// </summary>
    /// <typeparam name="T">tipo de los elementos que se van a filtrar</typeparam>
    /// <param name="origen">coleccion sobre la que se hace la busqueda</param>
    /// <param name="texto">texto usado para buscar o convertir datos</param>
    /// <param name="obtenerTexto">funcion que obtiene el texto que se va a comparar</param>
    /// <returns>resultado de la operacion</returns>
    public static List<T> Filtrar<T>(IEnumerable<T> origen, string texto, Func<T, string> obtenerTexto)
    {
        string criterio = (texto ?? "").Trim();
        return origen.Where(x => (obtenerTexto(x) ?? "").IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0)
            .OrderBy(obtenerTexto, StringComparer.CurrentCultureIgnoreCase).ToList();
    }
}
}
