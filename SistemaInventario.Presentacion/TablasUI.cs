using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
// ajustes de las tablas para no repetir lo mismo en cada formulario
internal static class TablasUI
{
    // oculta los ids y acomoda como se ven los precios y las fechas
    /// <summary>
    /// configura la tabla para mostrar correctamente los registros
    /// </summary>
    /// <param name="tabla">tabla de resultados de Windows Forms</param>
    public static void Preparar(DataGridView tabla)
    {
        foreach (DataGridViewColumn columna in tabla.Columns)
        {
            if (new[] { "Id", "Activo", "CategoriaId", "SuplidorId", "Fotos", "Foto", "FotoNombre", "ClaveHash", "Sal" }.Contains(columna.Name)) columna.Visible = false;
            if (columna.ValueType == typeof(DateTime)) columna.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            if (columna.ValueType == typeof(decimal))
            { columna.DefaultCellStyle.Format = "N2"; columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; }
        }
        Dictionary<string, string> encabezados = new Dictionary<string, string> {
            { "NombreEmpresa", "Empresa" }, { "NombreContacto", "Contacto" }, { "SitioWeb", "Sitio web" },
            { "PrecioUnitario", "Precio unitario" }, { "Categoria", "Categoria" }, { "FechaCreacion", "Creado" },
            { "FechaModificacion", "Modificado" }, { "CantidadFotos", "Fotos" }, { "CantidadProductos", "Productos" },
            { "PrecioPromedio", "Promedio" }, { "PrecioMinimo", "Minimo" }, { "PrecioMaximo", "Maximo" }
        };
        foreach (KeyValuePair<string,string> campo in encabezados) if (tabla.Columns.Contains(campo.Key)) tabla.Columns[campo.Key].HeaderText = campo.Value;
        tabla.EnableHeadersVisualStyles = false;
        tabla.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225,236,247);
        tabla.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
        tabla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(246,248,251);
    }
    // devuelve cero si no hay una fila seleccionada
    /// <summary>
    /// devuelve el identificador del registro seleccionado
    /// </summary>
    /// <param name="tabla">tabla de resultados de Windows Forms</param>
    /// <returns>identificador o valor calculado por la operacion</returns>
    public static int IdSeleccionado(DataGridView tabla)
    { return tabla.CurrentRow == null ? 0 : Convert.ToInt32(tabla.CurrentRow.Cells["Id"].Value); }
}
}
