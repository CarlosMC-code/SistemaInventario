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
// aqui van los listados, los filtros y el resumen del inventario
public partial class PrincipalForm : Form
{
    private ServiciosAplicacion servicios;
    private List<Categoria> categorias = new List<Categoria>();
    private List<Suplidor> suplidores = new List<Suplidor>();
    private List<ProductoListado> productos = new List<ProductoListado>();
    private bool cargando = true;
    public bool CerrarSesion { get; private set; }
    // crea los controles para que el disenador abra sin buscar datos
    /// <summary>
    /// prepara la ventana principal del inventario
    /// </summary>
    public PrincipalForm() { InitializeComponent(); }
    // recibe los servicios y la sesion desde el login
    /// <summary>
    /// prepara la ventana principal del inventario
    /// </summary>
    /// <param name="servicios">servicios que utiliza el formulario</param>
    public PrincipalForm(ServiciosAplicacion servicios) : this() { this.servicios = servicios; }
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
            lblUsuario.Text = servicios.Sesion.UsuarioActual.NombreCompleto + "  (" + servicios.Sesion.UsuarioActual.Rol + ")  -  SQL Server";
            bool administrador = servicios.Sesion.EsAdministrador;
            btnNuevaCategoria.Enabled = btnEditarCategoria.Enabled = btnEliminarCategoria.Enabled = administrador;
            btnNuevaSuplidor.Enabled = btnEditarSuplidor.Enabled = btnEliminarSuplidor.Enabled = administrador;
            btnEliminarProducto.Enabled = administrador; btnPapelera.Visible = administrador;
            cmbConsulta.SelectedIndex = 0;
            Refrescar();
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); Close(); }
    }
    private void Refrescar()
    {
        cargando = true;
        try
        {
            categorias = servicios.Categorias.Listar(); suplidores = servicios.Suplidores.Listar();
            productos = servicios.Consultas.ListadoProductos();
            List<Categoria> categoriasFiltro = new List<Categoria> { new Categoria { Id = 0, Nombre = "Todas" } }; categoriasFiltro.AddRange(categorias);
            List<Suplidor> suplidoresFiltro = new List<Suplidor> { new Suplidor { Id = 0, NombreEmpresa = "Todos" } }; suplidoresFiltro.AddRange(suplidores);
            cmbFiltroCategoria.DisplayMember = "Nombre"; cmbFiltroCategoria.ValueMember = "Id"; cmbFiltroCategoria.DataSource = categoriasFiltro;
            cmbFiltroSuplidor.DisplayMember = "NombreEmpresa"; cmbFiltroSuplidor.ValueMember = "Id"; cmbFiltroSuplidor.DataSource = suplidoresFiltro;
        }
        finally { cargando = false; }
        AplicarFiltros(); ActualizarResumen();
    }
    private void AplicarFiltros()
    {
        // espera a llenar los combos antes de filtrar para no usar listas a medio cargar
        if (cargando || servicios == null) return;
        errores.Clear();
        try
        {
            dgvCategoria.DataSource = servicios.Categorias.Buscar(categorias, txtBuscarCategoria.Text);
            dgvSuplidor.DataSource = servicios.Suplidores.Buscar(suplidores, txtBuscarSuplidor.Text);
            int categoriaId = cmbFiltroCategoria.SelectedValue is int ? (int)cmbFiltroCategoria.SelectedValue : 0;
            int suplidorId = cmbFiltroSuplidor.SelectedValue is int ? (int)cmbFiltroSuplidor.SelectedValue : 0;
            dgvProducto.DataSource = servicios.Consultas.FiltrarProductos(productos, txtBuscarProducto.Text,
                categoriaId == 0 ? (int?)null : categoriaId, suplidorId == 0 ? (int?)null : suplidorId,
                chkRango.Checked ? (decimal?)numMinimo.Value : null, chkRango.Checked ? (decimal?)numMaximo.Value : null);
            TablasUI.Preparar(dgvCategoria); TablasUI.Preparar(dgvSuplidor); TablasUI.Preparar(dgvProducto);
            MostrarFotoProducto();
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex, errores, new Dictionary<string,Control> { { "RangoPrecios", numMaximo } }); }
    }
    private void Filtros_TextChanged(object sender, EventArgs e) { AplicarFiltros(); }
    private void chkRango_CheckedChanged(object sender, EventArgs e)
    { numMinimo.Enabled = numMaximo.Enabled = chkRango.Checked; AplicarFiltros(); }
    private void btnLimpiarFiltros_Click(object sender, EventArgs e)
    {
        cargando = true; txtBuscarProducto.Clear(); cmbFiltroCategoria.SelectedIndex = cmbFiltroSuplidor.SelectedIndex = 0;
        chkRango.Checked = false; numMinimo.Value = 0; numMaximo.Value = 1000000; cargando = false; AplicarFiltros();
    }
    private void ActualizarResumen()
    {
        // cada opcion usa una consulta LINQ de la capa de negocio
        if (cargando || servicios == null) return;
        try
        {
            switch (cmbConsulta.SelectedIndex)
            {
                case 0: dgvResumen.DataSource = servicios.Consultas.ConteoPorCategoria(); break;
                case 1: dgvResumen.DataSource = servicios.Consultas.TopSuplidores(); break;
                case 2: dgvResumen.DataSource = servicios.Consultas.PreciosPorCategoria(); break;
                default: dgvResumen.DataSource = servicios.Consultas.ProductosMasCaros(); break;
            }
            TablasUI.Preparar(dgvResumen);
        }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); }
    }
    private void cmbConsulta_SelectedIndexChanged(object sender, EventArgs e) { ActualizarResumen(); }
    private void btnActualizarResumen_Click(object sender, EventArgs e) { ActualizarResumen(); }
    private void AbrirCategoria(int id, bool soloLectura = false)
    {
        using (CategoriaForm formulario = new CategoriaForm(servicios, id, soloLectura))
            if (formulario.ShowDialog(this) == DialogResult.OK) Refrescar();
    }
    private void AbrirSuplidor(int id)
    {
        using (SuplidorForm formulario = new SuplidorForm(servicios, id))
            if (formulario.ShowDialog(this) == DialogResult.OK) Refrescar();
    }
    private void AbrirProducto(int id)
    {
        using (ProductoForm formulario = new ProductoForm(servicios, id))
            if (formulario.ShowDialog(this) == DialogResult.OK) Refrescar();
    }
    private int Seleccionar(DataGridView tabla)
    {
        int id = TablasUI.IdSeleccionado(tabla);
        if (id == 0) MessageBox.Show("Selecciona un registro primero.", "Aviso");
        return id;
    }
    private void Eliminar(DataGridView tabla, Action<int> accion)
    {
        int id = Seleccionar(tabla); if (id == 0) return;
        if (MessageBox.Show("¿Mover el registro seleccionado a la papelera?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try { accion(id); Refrescar(); }
        catch (Exception ex) { ManejoErrores.Mostrar(ex); }
    }
    private void btnNuevaCategoria_Click(object sender, EventArgs e) { AbrirCategoria(0); }
    private void btnEditarCategoria_Click(object sender, EventArgs e) { int id = Seleccionar(dgvCategoria); if (id > 0) AbrirCategoria(id); }
    private void btnVerCategoria_Click(object sender, EventArgs e) { int id = Seleccionar(dgvCategoria); if (id > 0) AbrirCategoria(id, true); }
    private void btnEliminarCategoria_Click(object sender, EventArgs e) { Eliminar(dgvCategoria, servicios.Categorias.Eliminar); }
    private void btnNuevaSuplidor_Click(object sender, EventArgs e) { AbrirSuplidor(0); }
    private void btnEditarSuplidor_Click(object sender, EventArgs e) { int id = Seleccionar(dgvSuplidor); if (id > 0) AbrirSuplidor(id); }
    private void btnEliminarSuplidor_Click(object sender, EventArgs e) { Eliminar(dgvSuplidor, servicios.Suplidores.Eliminar); }
    private void btnNuevaProducto_Click(object sender, EventArgs e) { AbrirProducto(0); }
    private void btnEditarProducto_Click(object sender, EventArgs e) { int id = Seleccionar(dgvProducto); if (id > 0) AbrirProducto(id); }
    private void btnEliminarProducto_Click(object sender, EventArgs e) { Eliminar(dgvProducto, servicios.Productos.Eliminar); }
    private void btnPapelera_Click(object sender, EventArgs e)
    { using (PapeleraForm papelera = new PapeleraForm(servicios)) { papelera.ShowDialog(this); Refrescar(); } }
    private void btnCerrarSesion_Click(object sender, EventArgs e) { CerrarSesion = true; Close(); }
    private void dgvProducto_SelectionChanged(object sender, EventArgs e) { MostrarFotoProducto(); }
    private void Tabla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        // al abrir una pestana la tabla puede crear las columnas despues de cargar los datos
        TablasUI.Preparar((DataGridView)sender);
    }
    private void MostrarFotoProducto()
    {
        if (cargando) return;
        Image anterior = picProducto.Image;
        picProducto.Image = null;
        if (anterior != null) anterior.Dispose();
        ProductoListado seleccionado = dgvProducto.CurrentRow == null ? null : dgvProducto.CurrentRow.DataBoundItem as ProductoListado;
        lblFotoProducto.Text = seleccionado == null ? "Selecciona un producto" : seleccionado.Nombre;
        if (seleccionado == null || seleccionado.Foto == null) return;
        // la foto ya viene en el listado y asi no tiene que buscarla otra vez al cambiar de fila
        try
        {
            using (MemoryStream archivo = new MemoryStream(seleccionado.Foto))
            using (Image imagen = Image.FromStream(archivo)) picProducto.Image = new Bitmap(imagen);
        }
        catch (ArgumentException ex) { RegistroErrores.Registrar(ex); lblFotoProducto.Text = "No se pudo leer la foto"; }
    }
    /// <summary>
    /// libera los recursos de la pantalla al cerrarse
    /// </summary>
    /// <param name="e">dato que necesita la operacion</param>
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (picProducto.Image != null) { picProducto.Image.Dispose(); picProducto.Image = null; }
        base.OnFormClosed(e);
    }

}
}
