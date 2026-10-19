using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
// pantalla para el producto con su categoria y su suplidor activos
public partial class ProductoForm : Form
{
    private ServiciosAplicacion servicios;
    private int id;
    private Producto producto = new Producto();
    // este deja abrir el disenador sin hacer consultas
    /// <summary>
    /// prepara la pantalla donde se edita un producto
    /// </summary>
    public ProductoForm() { InitializeComponent(); }
    // recibe los servicios y el id del producto que se va a editar
    /// <summary>
    /// prepara la pantalla donde se edita un producto
    /// </summary>
    /// <param name="servicios">servicios que utiliza el formulario</param>
    /// <param name="id">identificador del registro</param>
    public ProductoForm(ServiciosAplicacion servicios, int id = 0) : this() { this.servicios = servicios; this.id = id; }
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
            cmbCategoria.DisplayMember = "Nombre"; cmbCategoria.ValueMember = "Id"; cmbCategoria.DataSource = servicios.Categorias.Listar();
            cmbSuplidor.DisplayMember = "NombreEmpresa"; cmbSuplidor.ValueMember = "Id"; cmbSuplidor.DataSource = servicios.Suplidores.Listar();
            cmbCategoria.SelectedIndex = cmbSuplidor.SelectedIndex = -1;
            lblTitulo.Text = id == 0 ? "Agregar producto" : "Editar producto";
            if (id == 0) return;
            producto = servicios.Productos.Obtener(id);
            MostrarFoto();
            txtNombre.Text = producto.Nombre; txtPrecio.Text = producto.PrecioUnitario.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("es-DO"));
            cmbCategoria.SelectedValue = producto.CategoriaId; cmbSuplidor.SelectedValue = producto.SuplidorId;
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); Close(); }
    }
    private void btnGuardar_Click(object sender, EventArgs e)
    {
        errores.Clear();
        try
        {
            // deja la foto que ya estaba y cambia los campos del formulario
            producto.Id = id;
            producto.Nombre = txtNombre.Text;
            producto.CategoriaId = cmbCategoria.SelectedValue is int ? (int)cmbCategoria.SelectedValue : 0;
            producto.SuplidorId = cmbSuplidor.SelectedValue is int ? (int)cmbSuplidor.SelectedValue : 0;
            servicios.Productos.GuardarConPrecio(producto, txtPrecio.Text); DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            ManejoErrores.Mostrar(ex, errores, new Dictionary<string,Control> { { "Nombre", txtNombre },
                { "PrecioUnitario", txtPrecio }, { "CategoriaId", cmbCategoria }, { "SuplidorId", cmbSuplidor }, { "Foto", grpFoto } });
        }
    }
    private void btnElegirFoto_Click(object sender, EventArgs e)
    {
        errores.Clear();
        using (OpenFileDialog dialogo = new OpenFileDialog { Filter = "Imagenes|*.jpg;*.jpeg;*.png", Title = "Elegir foto del producto" })
        {
            if (dialogo.ShowDialog(this) != DialogResult.OK) return;
            try
            {
                servicios.Productos.CargarFoto(producto, dialogo.FileName);
                MostrarFoto();
            }
            catch (Exception ex) { ManejoErrores.Mostrar(ex, errores, new Dictionary<string,Control> { { "Foto", grpFoto } }); }
        }
    }
    private void btnQuitarFoto_Click(object sender, EventArgs e)
    {
        producto.Foto = null;
        producto.FotoNombre = "";
        errores.Clear();
        MostrarFoto();
    }
    private void MostrarFoto()
    {
        // libera la foto anterior antes de cargar otra como en categorias
        Image anterior = picFoto.Image;
        picFoto.Image = null;
        if (anterior != null) anterior.Dispose();
        lblArchivoFoto.Text = string.IsNullOrEmpty(producto.FotoNombre) ? "Sin foto seleccionada" : producto.FotoNombre;
        if (producto.Foto == null) return;
        using (MemoryStream archivo = new MemoryStream(producto.Foto))
        using (Image imagen = Image.FromStream(archivo)) picFoto.Image = new Bitmap(imagen);
    }
    /// <summary>
    /// libera los recursos de la pantalla al cerrarse
    /// </summary>
    /// <param name="e">dato que necesita la operacion</param>
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (picFoto.Image != null) { picFoto.Image.Dispose(); picFoto.Image = null; }
        base.OnFormClosed(e);
    }

}
}
