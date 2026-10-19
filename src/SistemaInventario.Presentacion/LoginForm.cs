using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
// pantalla para entrar con el usuario y su clave
public partial class LoginForm : Form
{
    public ServiciosAplicacion Servicios { get; private set; }
    // este lo usa el disenador sin tener que cargar datos
    /// <summary>
    /// prepara la pantalla donde se inicia sesion
    /// </summary>
    public LoginForm() { InitializeComponent(); }
    // recibe los servicios de la aplicacion por constructor
    /// <summary>
    /// prepara la pantalla donde se inicia sesion
    /// </summary>
    /// <param name="servicios">servicios que utiliza el formulario</param>
    public LoginForm(ServiciosAplicacion servicios) : this()
    {
        Servicios = servicios;
    }
    private void chkMostrarClave_CheckedChanged(object sender, EventArgs e)
    { txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked; }
    private void btnIngresar_Click(object sender, EventArgs e)
    {
        errores.Clear(); lblMensaje.Text = "";
        try
        {
            // busca la cuenta en SQL Server y deja que la capa de negocio revise la clave
            Servicios.Usuarios.Autenticar(txtUsuario.Text, txtClave.Text);
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            ManejoErrores.Mostrar(ex, errores, new Dictionary<string,Control> { { "NombreUsuario", txtUsuario }, { "Clave", txtClave } });
            if (ex is ValidacionException) lblMensaje.Text = "Revisa los campos marcados.";
        }
    }
}
}
