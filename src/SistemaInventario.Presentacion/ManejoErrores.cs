using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
// muestra los errores que manda la capa de negocio
internal static class ManejoErrores
{
    // pone cada error al lado del campo que toca corregir
    /// <summary>
    /// muestra el error al usuario y lo relaciona con el campo cuando aplica
    /// </summary>
    /// <param name="error">excepcion que se va a registrar o mostrar</param>
    /// <param name="proveedor">dato que necesita la operacion</param>
    /// <param name="campos">dato que necesita la operacion</param>
    public static void Mostrar(Exception error, ErrorProvider proveedor = null, Dictionary<string, Control> campos = null)
    {
        ValidacionException validacion = error as ValidacionException;
        if (validacion != null && proveedor != null && campos != null)
        {
            proveedor.Clear();
            foreach (IGrouping<string, ErrorValidacion> grupo in validacion.Errores.GroupBy(e => e.Campo))
            {
                Control control;
                if (campos.TryGetValue(grupo.Key, out control)) proveedor.SetError(control, string.Join(Environment.NewLine, grupo.Select(e => e.Mensaje)));
            }
            Control primero;
            if (validacion.Errores.Count > 0 && campos.TryGetValue(validacion.Errores[0].Campo, out primero)) primero.Focus();
            return;
        }
        if (!(error is ValidacionException) && !(error is PermisoException) && !(error is DatosException)) RegistroErrores.Registrar(error);
        string mensaje = validacion == null ? error.Message : string.Join(Environment.NewLine, validacion.Errores.Select(e => e.Mensaje));
        MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
}
