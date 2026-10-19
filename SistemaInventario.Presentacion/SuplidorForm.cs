using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
// pantalla para llenar los datos del suplidor
public partial class SuplidorForm : Form
{
    private ServiciosAplicacion servicios;
    private int id;
    // este lo usa el disenador de Visual Studio
    /// <summary>
    /// prepara la pantalla donde se edita un suplidor
    /// </summary>
    public SuplidorForm() { InitializeComponent(); }
    // recibe los servicios y el id del suplidor que se va a editar
    /// <summary>
    /// prepara la pantalla donde se edita un suplidor
    /// </summary>
    /// <param name="servicios">servicios que utiliza el formulario</param>
    /// <param name="id">identificador del registro</param>
    public SuplidorForm(ServiciosAplicacion servicios, int id = 0) : this() { this.servicios = servicios; this.id = id; }
    /// <summary>
    /// prepara la pantalla cuando termina de cargarse el formulario
    /// </summary>
    /// <param name="e">dato que necesita la operacion</param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || servicios == null) return;
        try
        {
            servicios.Sesion.ExigirAcceso(true);
            lblTitulo.Text = id == 0 ? "Agregar suplidor" : "Editar suplidor";
            if (id == 0) return;
            Suplidor suplidor = servicios.Suplidores.Obtener(id);
            txtNombreEmpresa.Text = suplidor.NombreEmpresa; txtNombreContacto.Text = suplidor.NombreContacto;
            txtTelefono.Text = suplidor.Telefono; txtCorreo.Text = suplidor.Correo; txtSitioWeb.Text = suplidor.SitioWeb;
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); Close(); }
    }
    private void btnGuardar_Click(object sender, EventArgs e)
    {
        errores.Clear();
        try
        {
            servicios.Suplidores.Guardar(new Suplidor { Id = id, NombreEmpresa = txtNombreEmpresa.Text,
                NombreContacto = txtNombreContacto.Text, Telefono = txtTelefono.Text, Correo = txtCorreo.Text, SitioWeb = txtSitioWeb.Text });
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            ManejoErrores.Mostrar(ex, errores, new Dictionary<string,Control> { { "NombreEmpresa", txtNombreEmpresa },
                { "NombreContacto", txtNombreContacto }, { "Telefono", txtTelefono }, { "Correo", txtCorreo }, { "SitioWeb", txtSitioWeb } });
        }
    }
}
}
