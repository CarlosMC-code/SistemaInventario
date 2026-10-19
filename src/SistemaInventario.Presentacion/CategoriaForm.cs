using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using System.IO;
using System.Drawing;
namespace SistemaInventario.Presentacion
{
// pantalla para ver o editar la categoria y sus fotos
public partial class CategoriaForm : Form
{
    private ServiciosAplicacion servicios;
    private int id;
    private bool soloLectura;
    private List<FotoCategoria> fotos = new List<FotoCategoria>();
    // este lo usa el disenador
    /// <summary>
    /// prepara la pantalla de categorias y sus fotos
    /// </summary>
    public CategoriaForm() { InitializeComponent(); }
    // recibe los servicios y el id de la categoria o cero si es nueva
    /// <summary>
    /// prepara la pantalla de categorias y sus fotos
    /// </summary>
    /// <param name="servicios">servicios que utiliza el formulario</param>
    /// <param name="id">identificador del registro</param>
    /// <param name="soloLectura">indica si el formulario permite solo consultar</param>
    public CategoriaForm(ServiciosAplicacion servicios, int id = 0, bool soloLectura = false) : this()
    { this.servicios = servicios; this.id = id; this.soloLectura = soloLectura || !servicios.Sesion.EsAdministrador; }
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
            servicios.Sesion.ExigirAcceso();
            if (id > 0)
            {
                Categoria categoria = servicios.Categorias.Obtener(id);
                txtNombre.Text = categoria.Nombre; txtDescripcion.Text = categoria.Descripcion; fotos = categoria.Fotos;
            }
            lblTitulo.Text = soloLectura ? "Consultar categoria" : (id == 0 ? "Agregar categoria" : "Editar categoria");
            txtNombre.ReadOnly = txtDescripcion.ReadOnly = soloLectura;
            btnAgregarFoto.Enabled = btnQuitarFoto.Enabled = !soloLectura; btnGuardar.Visible = !soloLectura;
            if (soloLectura) btnCancelar.Text = "Cerrar";
            RefrescarFotos();
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); Close(); }
    }
    private Dictionary<string,Control> Campos()
    { return new Dictionary<string,Control> { { "Nombre", txtNombre }, { "Descripcion", txtDescripcion }, { "Fotos", grpFotos } }; }
    private void RefrescarFotos()
    {
        lstFotos.DataSource = null; lstFotos.DataSource = fotos.Select(f => f.NombreArchivo).ToList();
        lblCantidadFotos.Text = fotos.Count + " / 5 fotos"; MostrarFoto();
    }
    private void MostrarFoto()
    {
        // libera la imagen anterior para que no se quede ocupando memoria al cambiar de foto
        Image anterior = picFoto.Image; picFoto.Image = null; if (anterior != null) anterior.Dispose();
        if (lstFotos.SelectedIndex < 0 || lstFotos.SelectedIndex >= fotos.Count) return;
        try
        {
            using (MemoryStream archivo = new MemoryStream(fotos[lstFotos.SelectedIndex].Contenido))
            using (Image imagen = Image.FromStream(archivo)) picFoto.Image = new Bitmap(imagen);
        }
        catch (ArgumentException ex) { ManejoErrores.Mostrar(ex); }
    }
    private void lstFotos_SelectedIndexChanged(object sender, EventArgs e) { MostrarFoto(); }
    private void btnAgregarFoto_Click(object sender, EventArgs e)
    {
        errores.Clear();
        using (OpenFileDialog dialogo = new OpenFileDialog { Filter = "Imagenes|*.jpg;*.jpeg;*.png", Multiselect = true, Title = "Seleccionar fotos" })
        {
            if (dialogo.ShowDialog(this) != DialogResult.OK) return;
            try { foreach (string ruta in dialogo.FileNames) fotos.Add(servicios.Categorias.CargarFoto(ruta, fotos.Count)); }
            catch (Exception ex) { ManejoErrores.Mostrar(ex, errores, Campos()); }
            RefrescarFotos();
        }
    }
    private void btnQuitarFoto_Click(object sender, EventArgs e)
    { if (lstFotos.SelectedIndex >= 0) { fotos.RemoveAt(lstFotos.SelectedIndex); RefrescarFotos(); errores.Clear(); } }
    private void btnGuardar_Click(object sender, EventArgs e)
    {
        // recoge lo que se escribio y deja que el servicio revise los datos
        errores.Clear();
        try
        {
            servicios.Categorias.Guardar(new Categoria { Id = id, Nombre = txtNombre.Text, Descripcion = txtDescripcion.Text, Fotos = fotos });
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex, errores, Campos()); }
    }
    /// <summary>
    /// libera los recursos de la pantalla al cerrarse
    /// </summary>
    /// <param name="e">dato que necesita la operacion</param>
    protected override void OnFormClosed(FormClosedEventArgs e)
    { if (picFoto.Image != null) { picFoto.Image.Dispose(); picFoto.Image = null; } base.OnFormClosed(e); }
}
}
