using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// sirve para guardar un error desde la pantalla sin llamar directo a AccesoDatos
public static class RegistroErrores
{
    // manda el error al Logger para dejarlo guardado
    /// <summary>
    /// guarda el error y sus detalles en el archivo de registro
    /// </summary>
    /// <param name="error">excepcion que se va a registrar o mostrar</param>
    public static void Registrar(Exception error) { SistemaInventario.AccesoDatos.Logger.Registrar(error); }
    public static string RutaArchivo { get { return SistemaInventario.AccesoDatos.Logger.RutaArchivo; } }
}
}
