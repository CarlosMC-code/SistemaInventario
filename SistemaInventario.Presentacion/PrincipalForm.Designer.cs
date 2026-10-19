namespace SistemaInventario.Presentacion
{
    partial class PrincipalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ErrorProvider errores;
        // libera los controles cuando se cierra la ventana
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Codigo del disenador de Windows Forms

        // esto se edita desde Ver disenador y los eventos van en el otro archivo
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errores = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabCategoria = new System.Windows.Forms.TabPage();
            this.lblBuscarCategoria = new System.Windows.Forms.Label();
            this.txtBuscarCategoria = new System.Windows.Forms.TextBox();
            this.btnNuevaCategoria = new System.Windows.Forms.Button();
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.btnVerCategoria = new System.Windows.Forms.Button();
            this.dgvCategoria = new System.Windows.Forms.DataGridView();
            this.colCategoriaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaCantidadFotos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaFechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSuplidor = new System.Windows.Forms.TabPage();
            this.lblBuscarSuplidor = new System.Windows.Forms.Label();
            this.txtBuscarSuplidor = new System.Windows.Forms.TextBox();
            this.btnNuevaSuplidor = new System.Windows.Forms.Button();
            this.btnEditarSuplidor = new System.Windows.Forms.Button();
            this.btnEliminarSuplidor = new System.Windows.Forms.Button();
            this.dgvSuplidor = new System.Windows.Forms.DataGridView();
            this.tabProducto = new System.Windows.Forms.TabPage();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.btnNuevaProducto = new System.Windows.Forms.Button();
            this.btnEditarProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.lblFiltroCategoria = new System.Windows.Forms.Label();
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.lblFiltroSuplidor = new System.Windows.Forms.Label();
            this.cmbFiltroSuplidor = new System.Windows.Forms.ComboBox();
            this.chkRango = new System.Windows.Forms.CheckBox();
            this.numMinimo = new System.Windows.Forms.NumericUpDown();
            this.lblHasta = new System.Windows.Forms.Label();
            this.numMaximo = new System.Windows.Forms.NumericUpDown();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.grpFotoProducto = new System.Windows.Forms.GroupBox();
            this.picProducto = new System.Windows.Forms.PictureBox();
            this.lblFotoProducto = new System.Windows.Forms.Label();
            this.tabResumen = new System.Windows.Forms.TabPage();
            this.cmbConsulta = new System.Windows.Forms.ComboBox();
            this.btnActualizarResumen = new System.Windows.Forms.Button();
            this.lblAyudaResumen = new System.Windows.Forms.Label();
            this.dgvResumen = new System.Windows.Forms.DataGridView();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnPapelera = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuplidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            this.grpFotoProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tabCategoria.SuspendLayout();
            this.tabSuplidor.SuspendLayout();
            this.tabProducto.SuspendLayout();
            this.tabResumen.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // tabPrincipal
            //
            this.tabPrincipal.Location = new System.Drawing.Point(12, 104);
            this.tabPrincipal.Size = new System.Drawing.Size(1036, 524);
            this.tabPrincipal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Controls.Add(this.tabCategoria);
            this.tabPrincipal.Controls.Add(this.tabSuplidor);
            this.tabPrincipal.Controls.Add(this.tabProducto);
            this.tabPrincipal.Controls.Add(this.tabResumen);
            //
            // tabCategoria
            //
            this.tabCategoria.Location = new System.Drawing.Point(4, 24);
            this.tabCategoria.Size = new System.Drawing.Size(1024, 500);
            this.tabCategoria.Text = "Categorías";
            this.tabCategoria.UseVisualStyleBackColor = true;
            this.tabCategoria.Name = "tabCategoria";
            this.tabCategoria.TabIndex = 1;
            this.tabCategoria.Controls.Add(this.lblBuscarCategoria);
            this.tabCategoria.Controls.Add(this.txtBuscarCategoria);
            this.tabCategoria.Controls.Add(this.btnNuevaCategoria);
            this.tabCategoria.Controls.Add(this.btnEditarCategoria);
            this.tabCategoria.Controls.Add(this.btnEliminarCategoria);
            this.tabCategoria.Controls.Add(this.btnVerCategoria);
            this.tabCategoria.Controls.Add(this.dgvCategoria);
            //
            // lblBuscarCategoria
            //
            this.lblBuscarCategoria.Location = new System.Drawing.Point(18, 23);
            this.lblBuscarCategoria.Size = new System.Drawing.Size(60, 22);
            this.lblBuscarCategoria.Text = "Buscar:";
            this.lblBuscarCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblBuscarCategoria.Name = "lblBuscarCategoria";
            this.lblBuscarCategoria.TabIndex = 2;
            //
            // txtBuscarCategoria
            //
            this.txtBuscarCategoria.Location = new System.Drawing.Point(82, 20);
            this.txtBuscarCategoria.Size = new System.Drawing.Size(300, 23);
            this.txtBuscarCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtBuscarCategoria.Name = "txtBuscarCategoria";
            this.txtBuscarCategoria.TabIndex = 3;
            this.txtBuscarCategoria.TextChanged += new System.EventHandler(this.Filtros_TextChanged);
            //
            // btnNuevaCategoria
            //
            this.btnNuevaCategoria.Location = new System.Drawing.Point(404, 16);
            this.btnNuevaCategoria.Size = new System.Drawing.Size(110, 32);
            this.btnNuevaCategoria.Text = "Agregar";
            this.btnNuevaCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnNuevaCategoria.UseVisualStyleBackColor = false;
            this.btnNuevaCategoria.BackColor = System.Drawing.Color.FromArgb(57, 114, 165);
            this.btnNuevaCategoria.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCategoria.Name = "btnNuevaCategoria";
            this.btnNuevaCategoria.TabIndex = 4;
            this.btnNuevaCategoria.Click += new System.EventHandler(this.btnNuevaCategoria_Click);
            //
            // btnEditarCategoria
            //
            this.btnEditarCategoria.Location = new System.Drawing.Point(526, 16);
            this.btnEditarCategoria.Size = new System.Drawing.Size(110, 32);
            this.btnEditarCategoria.Text = "Editar";
            this.btnEditarCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnEditarCategoria.UseVisualStyleBackColor = true;
            this.btnEditarCategoria.Name = "btnEditarCategoria";
            this.btnEditarCategoria.TabIndex = 5;
            this.btnEditarCategoria.Click += new System.EventHandler(this.btnEditarCategoria_Click);
            //
            // btnEliminarCategoria
            //
            this.btnEliminarCategoria.Location = new System.Drawing.Point(648, 16);
            this.btnEliminarCategoria.Size = new System.Drawing.Size(110, 32);
            this.btnEliminarCategoria.Text = "Eliminar";
            this.btnEliminarCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.TabIndex = 6;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);
            //
            // btnVerCategoria
            //
            this.btnVerCategoria.Location = new System.Drawing.Point(770, 16);
            this.btnVerCategoria.Size = new System.Drawing.Size(110, 32);
            this.btnVerCategoria.Text = "Ver / fotos";
            this.btnVerCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnVerCategoria.UseVisualStyleBackColor = true;
            this.btnVerCategoria.Name = "btnVerCategoria";
            this.btnVerCategoria.TabIndex = 7;
            this.btnVerCategoria.Click += new System.EventHandler(this.btnVerCategoria_Click);
            //
            // dgvCategoria
            //
            this.dgvCategoria.Location = new System.Drawing.Point(16, 64);
            this.dgvCategoria.Size = new System.Drawing.Size(992, 424);
            this.dgvCategoria.ReadOnly = true;
            // deja fija la columna del contador para que no se mezcle con la lista de fotos
            this.dgvCategoria.AutoGenerateColumns = false;
            this.dgvCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colCategoriaId, this.colCategoriaNombre, this.colCategoriaDescripcion, this.colCategoriaCantidadFotos, this.colCategoriaFechaCreacion, this.colCategoriaFechaModificacion });
            this.colCategoriaId.Name = "Id";
            this.colCategoriaId.DataPropertyName = "Id";
            this.colCategoriaId.HeaderText = "Id";
            this.colCategoriaId.ValueType = typeof(int);
            this.colCategoriaId.ReadOnly = true;
            this.colCategoriaId.FillWeight = 10F;
            this.colCategoriaId.Visible = false;
            this.colCategoriaNombre.Name = "Nombre";
            this.colCategoriaNombre.DataPropertyName = "Nombre";
            this.colCategoriaNombre.HeaderText = "Nombre";
            this.colCategoriaNombre.ValueType = typeof(string);
            this.colCategoriaNombre.ReadOnly = true;
            this.colCategoriaNombre.FillWeight = 24F;
            this.colCategoriaNombre.Visible = true;
            this.colCategoriaDescripcion.Name = "Descripcion";
            this.colCategoriaDescripcion.DataPropertyName = "Descripcion";
            this.colCategoriaDescripcion.HeaderText = "Descripción";
            this.colCategoriaDescripcion.ValueType = typeof(string);
            this.colCategoriaDescripcion.ReadOnly = true;
            this.colCategoriaDescripcion.FillWeight = 36F;
            this.colCategoriaDescripcion.Visible = true;
            this.colCategoriaCantidadFotos.Name = "CantidadFotos";
            this.colCategoriaCantidadFotos.DataPropertyName = "CantidadFotos";
            this.colCategoriaCantidadFotos.HeaderText = "Fotos";
            this.colCategoriaCantidadFotos.ValueType = typeof(int);
            this.colCategoriaCantidadFotos.ReadOnly = true;
            this.colCategoriaCantidadFotos.FillWeight = 10F;
            this.colCategoriaCantidadFotos.Visible = true;
            this.colCategoriaCantidadFotos.DefaultCellStyle.Format = "0";
            this.colCategoriaCantidadFotos.DefaultCellStyle.NullValue = "0";
            this.colCategoriaCantidadFotos.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCategoriaCantidadFotos.ToolTipText = "Cantidad de fotos propias de la categoría (0 a 5).";
            this.colCategoriaFechaCreacion.Name = "FechaCreacion";
            this.colCategoriaFechaCreacion.DataPropertyName = "FechaCreacion";
            this.colCategoriaFechaCreacion.HeaderText = "Creado";
            this.colCategoriaFechaCreacion.ValueType = typeof(System.DateTime);
            this.colCategoriaFechaCreacion.ReadOnly = true;
            this.colCategoriaFechaCreacion.FillWeight = 18F;
            this.colCategoriaFechaCreacion.Visible = true;
            this.colCategoriaFechaModificacion.Name = "FechaModificacion";
            this.colCategoriaFechaModificacion.DataPropertyName = "FechaModificacion";
            this.colCategoriaFechaModificacion.HeaderText = "Modificado";
            this.colCategoriaFechaModificacion.ValueType = typeof(System.DateTime);
            this.colCategoriaFechaModificacion.ReadOnly = true;
            this.colCategoriaFechaModificacion.FillWeight = 18F;
            this.colCategoriaFechaModificacion.Visible = true;
            this.dgvCategoria.AllowUserToAddRows = false;
            this.dgvCategoria.AllowUserToDeleteRows = false;
            this.dgvCategoria.AllowUserToResizeRows = false;
            this.dgvCategoria.MultiSelect = false;
            this.dgvCategoria.RowHeadersVisible = false;
            this.dgvCategoria.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategoria.RowTemplate.Height = 28;
            this.dgvCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dgvCategoria.Name = "dgvCategoria";
            this.dgvCategoria.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Tabla_DataBindingComplete);
            this.dgvCategoria.TabIndex = 8;
            //
            // tabSuplidor
            //
            this.tabSuplidor.Location = new System.Drawing.Point(4, 24);
            this.tabSuplidor.Size = new System.Drawing.Size(1024, 500);
            this.tabSuplidor.Text = "Suplidores";
            this.tabSuplidor.UseVisualStyleBackColor = true;
            this.tabSuplidor.Name = "tabSuplidor";
            this.tabSuplidor.TabIndex = 9;
            this.tabSuplidor.Controls.Add(this.lblBuscarSuplidor);
            this.tabSuplidor.Controls.Add(this.txtBuscarSuplidor);
            this.tabSuplidor.Controls.Add(this.btnNuevaSuplidor);
            this.tabSuplidor.Controls.Add(this.btnEditarSuplidor);
            this.tabSuplidor.Controls.Add(this.btnEliminarSuplidor);
            this.tabSuplidor.Controls.Add(this.dgvSuplidor);
            //
            // lblBuscarSuplidor
            //
            this.lblBuscarSuplidor.Location = new System.Drawing.Point(18, 23);
            this.lblBuscarSuplidor.Size = new System.Drawing.Size(60, 22);
            this.lblBuscarSuplidor.Text = "Buscar:";
            this.lblBuscarSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblBuscarSuplidor.Name = "lblBuscarSuplidor";
            this.lblBuscarSuplidor.TabIndex = 10;
            //
            // txtBuscarSuplidor
            //
            this.txtBuscarSuplidor.Location = new System.Drawing.Point(82, 20);
            this.txtBuscarSuplidor.Size = new System.Drawing.Size(300, 23);
            this.txtBuscarSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtBuscarSuplidor.Name = "txtBuscarSuplidor";
            this.txtBuscarSuplidor.TabIndex = 11;
            this.txtBuscarSuplidor.TextChanged += new System.EventHandler(this.Filtros_TextChanged);
            //
            // btnNuevaSuplidor
            //
            this.btnNuevaSuplidor.Location = new System.Drawing.Point(404, 16);
            this.btnNuevaSuplidor.Size = new System.Drawing.Size(110, 32);
            this.btnNuevaSuplidor.Text = "Agregar";
            this.btnNuevaSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnNuevaSuplidor.UseVisualStyleBackColor = false;
            this.btnNuevaSuplidor.BackColor = System.Drawing.Color.FromArgb(57, 114, 165);
            this.btnNuevaSuplidor.ForeColor = System.Drawing.Color.White;
            this.btnNuevaSuplidor.Name = "btnNuevaSuplidor";
            this.btnNuevaSuplidor.TabIndex = 12;
            this.btnNuevaSuplidor.Click += new System.EventHandler(this.btnNuevaSuplidor_Click);
            //
            // btnEditarSuplidor
            //
            this.btnEditarSuplidor.Location = new System.Drawing.Point(526, 16);
            this.btnEditarSuplidor.Size = new System.Drawing.Size(110, 32);
            this.btnEditarSuplidor.Text = "Editar";
            this.btnEditarSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnEditarSuplidor.UseVisualStyleBackColor = true;
            this.btnEditarSuplidor.Name = "btnEditarSuplidor";
            this.btnEditarSuplidor.TabIndex = 13;
            this.btnEditarSuplidor.Click += new System.EventHandler(this.btnEditarSuplidor_Click);
            //
            // btnEliminarSuplidor
            //
            this.btnEliminarSuplidor.Location = new System.Drawing.Point(648, 16);
            this.btnEliminarSuplidor.Size = new System.Drawing.Size(110, 32);
            this.btnEliminarSuplidor.Text = "Eliminar";
            this.btnEliminarSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnEliminarSuplidor.UseVisualStyleBackColor = true;
            this.btnEliminarSuplidor.Name = "btnEliminarSuplidor";
            this.btnEliminarSuplidor.TabIndex = 14;
            this.btnEliminarSuplidor.Click += new System.EventHandler(this.btnEliminarSuplidor_Click);
            //
            // dgvSuplidor
            //
            this.dgvSuplidor.Location = new System.Drawing.Point(16, 64);
            this.dgvSuplidor.Size = new System.Drawing.Size(992, 424);
            this.dgvSuplidor.ReadOnly = true;
            this.dgvSuplidor.AllowUserToAddRows = false;
            this.dgvSuplidor.AllowUserToDeleteRows = false;
            this.dgvSuplidor.AllowUserToResizeRows = false;
            this.dgvSuplidor.MultiSelect = false;
            this.dgvSuplidor.RowHeadersVisible = false;
            this.dgvSuplidor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSuplidor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuplidor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuplidor.RowTemplate.Height = 28;
            this.dgvSuplidor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dgvSuplidor.Name = "dgvSuplidor";
            this.dgvSuplidor.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Tabla_DataBindingComplete);
            this.dgvSuplidor.TabIndex = 15;
            //
            // tabProducto
            //
            this.tabProducto.Location = new System.Drawing.Point(4, 24);
            this.tabProducto.Size = new System.Drawing.Size(1024, 500);
            this.tabProducto.Text = "Productos";
            this.tabProducto.UseVisualStyleBackColor = true;
            this.tabProducto.Name = "tabProducto";
            this.tabProducto.TabIndex = 16;
            this.tabProducto.Controls.Add(this.lblBuscarProducto);
            this.tabProducto.Controls.Add(this.txtBuscarProducto);
            this.tabProducto.Controls.Add(this.btnNuevaProducto);
            this.tabProducto.Controls.Add(this.btnEditarProducto);
            this.tabProducto.Controls.Add(this.btnEliminarProducto);
            this.tabProducto.Controls.Add(this.btnLimpiarFiltros);
            this.tabProducto.Controls.Add(this.lblFiltroCategoria);
            this.tabProducto.Controls.Add(this.cmbFiltroCategoria);
            this.tabProducto.Controls.Add(this.lblFiltroSuplidor);
            this.tabProducto.Controls.Add(this.cmbFiltroSuplidor);
            this.tabProducto.Controls.Add(this.chkRango);
            this.tabProducto.Controls.Add(this.numMinimo);
            this.tabProducto.Controls.Add(this.lblHasta);
            this.tabProducto.Controls.Add(this.numMaximo);
            this.tabProducto.Controls.Add(this.dgvProducto);
            this.tabProducto.Controls.Add(this.grpFotoProducto);
            //
            // lblBuscarProducto
            //
            this.lblBuscarProducto.Location = new System.Drawing.Point(18, 23);
            this.lblBuscarProducto.Size = new System.Drawing.Size(60, 22);
            this.lblBuscarProducto.Text = "Buscar:";
            this.lblBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.TabIndex = 17;
            //
            // txtBuscarProducto
            //
            this.txtBuscarProducto.Location = new System.Drawing.Point(82, 20);
            this.txtBuscarProducto.Size = new System.Drawing.Size(300, 23);
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.TabIndex = 18;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.Filtros_TextChanged);
            //
            // btnNuevaProducto
            //
            this.btnNuevaProducto.Location = new System.Drawing.Point(404, 16);
            this.btnNuevaProducto.Size = new System.Drawing.Size(110, 32);
            this.btnNuevaProducto.Text = "Agregar";
            this.btnNuevaProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnNuevaProducto.UseVisualStyleBackColor = false;
            this.btnNuevaProducto.BackColor = System.Drawing.Color.FromArgb(57, 114, 165);
            this.btnNuevaProducto.ForeColor = System.Drawing.Color.White;
            this.btnNuevaProducto.Name = "btnNuevaProducto";
            this.btnNuevaProducto.TabIndex = 19;
            this.btnNuevaProducto.Click += new System.EventHandler(this.btnNuevaProducto_Click);
            //
            // btnEditarProducto
            //
            this.btnEditarProducto.Location = new System.Drawing.Point(526, 16);
            this.btnEditarProducto.Size = new System.Drawing.Size(110, 32);
            this.btnEditarProducto.Text = "Editar";
            this.btnEditarProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnEditarProducto.UseVisualStyleBackColor = true;
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.TabIndex = 20;
            this.btnEditarProducto.Click += new System.EventHandler(this.btnEditarProducto_Click);
            //
            // btnEliminarProducto
            //
            this.btnEliminarProducto.Location = new System.Drawing.Point(648, 16);
            this.btnEliminarProducto.Size = new System.Drawing.Size(110, 32);
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.TabIndex = 21;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            //
            // btnLimpiarFiltros
            //
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(770, 16);
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(136, 32);
            this.btnLimpiarFiltros.Text = "Limpiar filtros";
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.TabIndex = 22;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            //
            // lblFiltroCategoria
            //
            this.lblFiltroCategoria.Location = new System.Drawing.Point(18, 73);
            this.lblFiltroCategoria.Size = new System.Drawing.Size(70, 22);
            this.lblFiltroCategoria.Text = "Categoría:";
            this.lblFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFiltroCategoria.Name = "lblFiltroCategoria";
            this.lblFiltroCategoria.TabIndex = 23;
            //
            // cmbFiltroCategoria
            //
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(92, 70);
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(176, 23);
            this.cmbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroCategoria.FormattingEnabled = true;
            this.cmbFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.TabIndex = 24;
            this.cmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.Filtros_TextChanged);
            //
            // lblFiltroSuplidor
            //
            this.lblFiltroSuplidor.Location = new System.Drawing.Point(280, 73);
            this.lblFiltroSuplidor.Size = new System.Drawing.Size(66, 22);
            this.lblFiltroSuplidor.Text = "Suplidor:";
            this.lblFiltroSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFiltroSuplidor.Name = "lblFiltroSuplidor";
            this.lblFiltroSuplidor.TabIndex = 25;
            //
            // cmbFiltroSuplidor
            //
            this.cmbFiltroSuplidor.Location = new System.Drawing.Point(350, 70);
            this.cmbFiltroSuplidor.Size = new System.Drawing.Size(176, 23);
            this.cmbFiltroSuplidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroSuplidor.FormattingEnabled = true;
            this.cmbFiltroSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbFiltroSuplidor.Name = "cmbFiltroSuplidor";
            this.cmbFiltroSuplidor.TabIndex = 26;
            this.cmbFiltroSuplidor.SelectedIndexChanged += new System.EventHandler(this.Filtros_TextChanged);
            //
            // chkRango
            //
            this.chkRango.Location = new System.Drawing.Point(546, 69);
            this.chkRango.Size = new System.Drawing.Size(138, 24);
            this.chkRango.Text = "Filtrar por precio";
            this.chkRango.Name = "chkRango";
            this.chkRango.TabIndex = 27;
            this.chkRango.CheckedChanged += new System.EventHandler(this.chkRango_CheckedChanged);
            //
            // numMinimo
            //
            this.numMinimo.Location = new System.Drawing.Point(692, 70);
            this.numMinimo.Size = new System.Drawing.Size(112, 23);
            this.numMinimo.DecimalPlaces = 2;
            this.numMinimo.Maximum = 9999999999999999.99M;
            this.numMinimo.ThousandsSeparator = true;
            this.numMinimo.Enabled = false;
            this.numMinimo.Name = "numMinimo";
            this.numMinimo.TabIndex = 28;
            this.numMinimo.ValueChanged += new System.EventHandler(this.Filtros_TextChanged);
            //
            // lblHasta
            //
            this.lblHasta.Location = new System.Drawing.Point(812, 73);
            this.lblHasta.Size = new System.Drawing.Size(42, 22);
            this.lblHasta.Text = "hasta";
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.TabIndex = 29;
            //
            // numMaximo
            //
            this.numMaximo.Location = new System.Drawing.Point(858, 70);
            this.numMaximo.Size = new System.Drawing.Size(136, 23);
            this.numMaximo.DecimalPlaces = 2;
            this.numMaximo.Maximum = 9999999999999999.99M;
            this.numMaximo.ThousandsSeparator = true;
            this.numMaximo.Enabled = false;
            this.numMaximo.Value = 1000000M;
            this.numMaximo.Name = "numMaximo";
            this.numMaximo.TabIndex = 30;
            this.numMaximo.ValueChanged += new System.EventHandler(this.Filtros_TextChanged);
            //
            // dgvProducto
            //
            this.dgvProducto.Location = new System.Drawing.Point(16, 116);
            this.dgvProducto.Size = new System.Drawing.Size(744, 372);
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.AllowUserToResizeRows = false;
            this.dgvProducto.MultiSelect = false;
            this.dgvProducto.RowHeadersVisible = false;
            this.dgvProducto.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducto.RowTemplate.Height = 28;
            this.dgvProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Tabla_DataBindingComplete);
            this.dgvProducto.TabIndex = 31;
            this.dgvProducto.SelectionChanged += new System.EventHandler(this.dgvProducto_SelectionChanged);
            this.grpFotoProducto.Location = new System.Drawing.Point(776, 116);
            this.grpFotoProducto.Size = new System.Drawing.Size(232, 282);
            this.grpFotoProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.grpFotoProducto.Name = "grpFotoProducto";
            this.grpFotoProducto.Text = "Foto del producto";
            this.picProducto.Location = new System.Drawing.Point(12, 24);
            this.picProducto.Size = new System.Drawing.Size(208, 202);
            this.picProducto.Name = "picProducto";
            this.picProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblFotoProducto.Location = new System.Drawing.Point(12, 234);
            this.lblFotoProducto.Size = new System.Drawing.Size(208, 40);
            this.lblFotoProducto.Name = "lblFotoProducto";
            this.lblFotoProducto.Text = "Selecciona un producto";
            this.grpFotoProducto.Controls.Add(this.picProducto);
            this.grpFotoProducto.Controls.Add(this.lblFotoProducto);
            //
            // tabResumen
            //
            this.tabResumen.Location = new System.Drawing.Point(4, 24);
            this.tabResumen.Size = new System.Drawing.Size(1024, 500);
            this.tabResumen.Text = "Resumen LINQ";
            this.tabResumen.UseVisualStyleBackColor = true;
            this.tabResumen.Name = "tabResumen";
            this.tabResumen.TabIndex = 32;
            this.tabResumen.Controls.Add(this.cmbConsulta);
            this.tabResumen.Controls.Add(this.btnActualizarResumen);
            this.tabResumen.Controls.Add(this.lblAyudaResumen);
            this.tabResumen.Controls.Add(this.dgvResumen);
            //
            // cmbConsulta
            //
            this.cmbConsulta.Location = new System.Drawing.Point(18, 26);
            this.cmbConsulta.Size = new System.Drawing.Size(456, 23);
            this.cmbConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsulta.FormattingEnabled = true;
            this.cmbConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbConsulta.Name = "cmbConsulta";
            this.cmbConsulta.TabIndex = 33;
            this.cmbConsulta.SelectedIndexChanged += new System.EventHandler(this.cmbConsulta_SelectedIndexChanged);
            this.cmbConsulta.Items.AddRange(new object[] { "Cantidad de productos por categoría", "Top 5 suplidores con más productos", "Promedio, mínimo y máximo por categoría", "Top 5 productos más caros" });
            //
            // btnActualizarResumen
            //
            this.btnActualizarResumen.Location = new System.Drawing.Point(490, 21);
            this.btnActualizarResumen.Size = new System.Drawing.Size(116, 32);
            this.btnActualizarResumen.Text = "Actualizar";
            this.btnActualizarResumen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnActualizarResumen.UseVisualStyleBackColor = true;
            this.btnActualizarResumen.Name = "btnActualizarResumen";
            this.btnActualizarResumen.TabIndex = 34;
            this.btnActualizarResumen.Click += new System.EventHandler(this.btnActualizarResumen_Click);
            //
            // lblAyudaResumen
            //
            this.lblAyudaResumen.Location = new System.Drawing.Point(18, 62);
            this.lblAyudaResumen.Size = new System.Drawing.Size(980, 22);
            this.lblAyudaResumen.Text = "Los cálculos usan los registros activos.";
            this.lblAyudaResumen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAyudaResumen.ForeColor = System.Drawing.Color.DimGray;
            this.lblAyudaResumen.Name = "lblAyudaResumen";
            this.lblAyudaResumen.TabIndex = 35;
            //
            // dgvResumen
            //
            this.dgvResumen.Location = new System.Drawing.Point(16, 96);
            this.dgvResumen.Size = new System.Drawing.Size(992, 392);
            this.dgvResumen.ReadOnly = true;
            this.dgvResumen.AllowUserToAddRows = false;
            this.dgvResumen.AllowUserToDeleteRows = false;
            this.dgvResumen.AllowUserToResizeRows = false;
            this.dgvResumen.MultiSelect = false;
            this.dgvResumen.RowHeadersVisible = false;
            this.dgvResumen.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResumen.RowTemplate.Height = 28;
            this.dgvResumen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvResumen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dgvResumen.Name = "dgvResumen";
            this.dgvResumen.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Tabla_DataBindingComplete);
            this.dgvResumen.TabIndex = 36;
            //
            // panelEncabezado
            //
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Size = new System.Drawing.Size(1060, 90);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(223, 235, 247);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.TabIndex = 37;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblUsuario);
            this.panelEncabezado.Controls.Add(this.btnPapelera);
            this.panelEncabezado.Controls.Add(this.btnCerrarSesion);
            //
            // lblTitulo
            //
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Size = new System.Drawing.Size(850, 34);
            this.lblTitulo.Text = "Inventario de productos";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 38;
            //
            // lblUsuario
            //
            this.lblUsuario.Location = new System.Drawing.Point(21, 56);
            this.lblUsuario.Size = new System.Drawing.Size(840, 24);
            this.lblUsuario.Text = "Usuario conectado";
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TabIndex = 39;
            //
            // btnPapelera
            //
            this.btnPapelera.Location = new System.Drawing.Point(904, 12);
            this.btnPapelera.Size = new System.Drawing.Size(136, 30);
            this.btnPapelera.Text = "Papelera";
            this.btnPapelera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnPapelera.UseVisualStyleBackColor = true;
            this.btnPapelera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnPapelera.Name = "btnPapelera";
            this.btnPapelera.TabIndex = 40;
            this.btnPapelera.Click += new System.EventHandler(this.btnPapelera_Click);
            //
            // btnCerrarSesion
            //
            this.btnCerrarSesion.Location = new System.Drawing.Point(904, 49);
            this.btnCerrarSesion.Size = new System.Drawing.Size(136, 30);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.TabIndex = 41;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            this.errores.ContainerControl = this;
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ClientSize = new System.Drawing.Size(1060, 644);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "PrincipalForm";
            this.Text = "Principal";
            this.Text = "Sistema de inventario";
            this.MinimumSize = new System.Drawing.Size(1076, 683);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.panelEncabezado);
            ((System.ComponentModel.ISupportInitialize)(this.errores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuplidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).EndInit();
            this.grpFotoProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.tabResumen.ResumeLayout(false);
            this.tabResumen.PerformLayout();
            this.tabProducto.ResumeLayout(false);
            this.tabProducto.PerformLayout();
            this.tabSuplidor.ResumeLayout(false);
            this.tabSuplidor.PerformLayout();
            this.tabCategoria.ResumeLayout(false);
            this.tabCategoria.PerformLayout();
            this.tabPrincipal.ResumeLayout(false);
            this.tabPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabCategoria;
        private System.Windows.Forms.Label lblBuscarCategoria;
        private System.Windows.Forms.TextBox txtBuscarCategoria;
        private System.Windows.Forms.Button btnNuevaCategoria;
        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnVerCategoria;
        private System.Windows.Forms.DataGridView dgvCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaCantidadFotos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaFechaModificacion;
        private System.Windows.Forms.TabPage tabSuplidor;
        private System.Windows.Forms.Label lblBuscarSuplidor;
        private System.Windows.Forms.TextBox txtBuscarSuplidor;
        private System.Windows.Forms.Button btnNuevaSuplidor;
        private System.Windows.Forms.Button btnEditarSuplidor;
        private System.Windows.Forms.Button btnEliminarSuplidor;
        private System.Windows.Forms.DataGridView dgvSuplidor;
        private System.Windows.Forms.TabPage tabProducto;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button btnNuevaProducto;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Label lblFiltroCategoria;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.Label lblFiltroSuplidor;
        private System.Windows.Forms.ComboBox cmbFiltroSuplidor;
        private System.Windows.Forms.CheckBox chkRango;
        private System.Windows.Forms.NumericUpDown numMinimo;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.NumericUpDown numMaximo;
        private System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.GroupBox grpFotoProducto;
        private System.Windows.Forms.PictureBox picProducto;
        private System.Windows.Forms.Label lblFotoProducto;
        private System.Windows.Forms.TabPage tabResumen;
        private System.Windows.Forms.ComboBox cmbConsulta;
        private System.Windows.Forms.Button btnActualizarResumen;
        private System.Windows.Forms.Label lblAyudaResumen;
        private System.Windows.Forms.DataGridView dgvResumen;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnPapelera;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
