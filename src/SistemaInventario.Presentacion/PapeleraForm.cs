using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
// muestra lo que esta en la papelera y permite restaurarlo
public partial class PapeleraForm : Form
{
    private ServiciosAplicacion servicios;
    private bool cargando = true;
    // este lo usa el disenador de Visual Studio
    /// <summary>
    /// prepara la pantalla para consultar y restaurar registros
    /// </summary>
    public PapeleraForm() { InitializeComponent(); }
    // recibe los servicios de la sesion
    /// <summary>
    /// prepara la pantalla para consultar y restaurar registros
    /// </summary>
    /// <param name="servicios">servicios que utiliza el formulario</param>
    public PapeleraForm(ServiciosAplicacion servicios) : this() { this.servicios = servicios; }
    /// <summary>
    /// prepara la pantalla cuando termina de cargarse el formulario
    /// </summary>
    /// <param name="e">dato que necesita la operacion</param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || servicios == null) return;
        try { servicios.Sesion.ExigirAcceso(true); cmbTipo.SelectedIndex = 0; cargando = false; Cargar(); }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); Close(); }
    }
    private void Cargar()
    {
        if (cargando || servicios == null) return;
        try
        {
            switch (cmbTipo.SelectedIndex)
            {
                case 0: dgvEliminados.DataSource = BusquedaGenerica.Filtrar(servicios.Categorias.ListarEliminados(), txtBuscar.Text, x => x.Nombre + " " + x.Descripcion); break;
                case 1: dgvEliminados.DataSource = BusquedaGenerica.Filtrar(servicios.Suplidores.ListarEliminados(), txtBuscar.Text, x => x.NombreEmpresa + " " + x.NombreContacto); break;
                default: dgvEliminados.DataSource = BusquedaGenerica.Filtrar(servicios.Productos.ListarEliminados(), txtBuscar.Text, x => x.Nombre); break;
            }
            TablasUI.Preparar(dgvEliminados);
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); }
    }
    private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e) { Cargar(); }
    private void txtBuscar_TextChanged(object sender, EventArgs e) { Cargar(); }
    private void btnRestaurar_Click(object sender, EventArgs e)
    {
        int id = TablasUI.IdSeleccionado(dgvEliminados);
        if (id == 0) { MessageBox.Show("Selecciona un registro primero.", "Aviso"); return; }
        try
        {
            switch (cmbTipo.SelectedIndex)
            {
                case 0: servicios.Categorias.Restaurar(id); break;
                case 1: servicios.Suplidores.Restaurar(id); break;
                default: servicios.Productos.Restaurar(id); break;
            }
            Cargar();
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); }
    }
}
}
