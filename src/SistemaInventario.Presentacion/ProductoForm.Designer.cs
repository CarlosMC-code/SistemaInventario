namespace SistemaInventario.Presentacion
{
    partial class ProductoForm
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
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.grpFoto = new System.Windows.Forms.GroupBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnElegirFoto = new System.Windows.Forms.Button();
            this.btnQuitarFoto = new System.Windows.Forms.Button();
            this.lblArchivoFoto = new System.Windows.Forms.Label();
            this.lblFormatoFoto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblEjemploPrecio = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblSuplidor = new System.Windows.Forms.Label();
            this.cmbSuplidor = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errores)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.grpFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // grpDatos
            //
            this.grpDatos.Location = new System.Drawing.Point(18, 96);
            this.grpDatos.Size = new System.Drawing.Size(844, 226);
            this.grpDatos.Text = "Datos del producto";
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.TabIndex = 0;
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblPrecio);
            this.grpDatos.Controls.Add(this.txtPrecio);
            this.grpDatos.Controls.Add(this.lblEjemploPrecio);
            this.grpDatos.Controls.Add(this.lblCategoria);
            this.grpDatos.Controls.Add(this.cmbCategoria);
            this.grpDatos.Controls.Add(this.lblSuplidor);
            this.grpDatos.Controls.Add(this.cmbSuplidor);
            //
            // lblNombre
            //
            this.lblNombre.Location = new System.Drawing.Point(18, 32);
            this.lblNombre.Size = new System.Drawing.Size(134, 22);
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 1;
            //
            // txtNombre
            //
            this.txtNombre.Location = new System.Drawing.Point(166, 29);
            this.txtNombre.Size = new System.Drawing.Size(650, 23);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Name = "txtNombre";
            //
            // lblPrecio
            //
            this.lblPrecio.Location = new System.Drawing.Point(18, 76);
            this.lblPrecio.Size = new System.Drawing.Size(134, 22);
            this.lblPrecio.Text = "Precio unitario:";
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.TabIndex = 3;
            //
            // txtPrecio
            //
            this.txtPrecio.Location = new System.Drawing.Point(166, 73);
            this.txtPrecio.Size = new System.Drawing.Size(200, 23);
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtPrecio.TabIndex = 1;
            this.txtPrecio.Name = "txtPrecio";
            //
            // lblEjemploPrecio
            //
            this.lblEjemploPrecio.Location = new System.Drawing.Point(382, 76);
            this.lblEjemploPrecio.Size = new System.Drawing.Size(274, 22);
            this.lblEjemploPrecio.Text = "Ejemplo: 1500.50";
            this.lblEjemploPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblEjemploPrecio.ForeColor = System.Drawing.Color.DimGray;
            this.lblEjemploPrecio.Name = "lblEjemploPrecio";
            this.lblEjemploPrecio.TabIndex = 5;
            //
            // lblCategoria
            //
            this.lblCategoria.Location = new System.Drawing.Point(18, 120);
            this.lblCategoria.Size = new System.Drawing.Size(134, 22);
            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.TabIndex = 6;
            //
            // cmbCategoria
            //
            this.cmbCategoria.Location = new System.Drawing.Point(166, 117);
            this.cmbCategoria.Size = new System.Drawing.Size(650, 23);
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.TabIndex = 7;
            //
            // lblSuplidor
            //
            this.lblSuplidor.Location = new System.Drawing.Point(18, 164);
            this.lblSuplidor.Size = new System.Drawing.Size(134, 22);
            this.lblSuplidor.Text = "Suplidor:";
            this.lblSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblSuplidor.Name = "lblSuplidor";
            this.lblSuplidor.TabIndex = 8;
            //
            // cmbSuplidor
            //
            this.cmbSuplidor.Location = new System.Drawing.Point(166, 161);
            this.cmbSuplidor.Size = new System.Drawing.Size(650, 23);
            this.cmbSuplidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuplidor.FormattingEnabled = true;
            this.cmbSuplidor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbSuplidor.Name = "cmbSuplidor";
            this.cmbSuplidor.TabIndex = 9;
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(630, 546);
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(57, 114, 165);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(744, 546);
            this.btnCancelar.Size = new System.Drawing.Size(116, 34);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.TabIndex = 11;
            //
            // panelEncabezado
            //
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Size = new System.Drawing.Size(720, 80);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(223, 235, 247);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.TabIndex = 12;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblAyuda);
            //
            // lblTitulo
            //
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Size = new System.Drawing.Size(684, 32);
            this.lblTitulo.Text = "Producto";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 13;
            //
            // lblAyuda
            //
            this.lblAyuda.Location = new System.Drawing.Point(21, 51);
            this.lblAyuda.Size = new System.Drawing.Size(678, 22);
            this.lblAyuda.Text = "Elige una categoría y un suplidor activos.";
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.TabIndex = 14;
            this.errores.ContainerControl = this;
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ClientSize = new System.Drawing.Size(880, 604);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "ProductoForm";
            this.Text = "Producto";
            this.Text = "Producto";
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.CancelButton = this.btnCancelar;
            // la foto se ve aqui y se guarda junto con el producto
            this.grpFoto.Location = new System.Drawing.Point(18, 336);
            this.grpFoto.Size = new System.Drawing.Size(844, 188);
            this.grpFoto.Name = "grpFoto";
            this.grpFoto.Text = "Foto del producto";
            this.grpFoto.TabIndex = 10;
            this.picFoto.Location = new System.Drawing.Point(16, 25);
            this.picFoto.Size = new System.Drawing.Size(208, 148);
            this.picFoto.Name = "picFoto";
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnElegirFoto.Location = new System.Drawing.Point(248, 30);
            this.btnElegirFoto.Size = new System.Drawing.Size(130, 32);
            this.btnElegirFoto.Name = "btnElegirFoto";
            this.btnElegirFoto.Text = "Elegir foto";
            this.btnElegirFoto.TabIndex = 0;
            this.btnElegirFoto.Click += new System.EventHandler(this.btnElegirFoto_Click);
            this.btnQuitarFoto.Location = new System.Drawing.Point(394, 30);
            this.btnQuitarFoto.Size = new System.Drawing.Size(130, 32);
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.Text = "Quitar foto";
            this.btnQuitarFoto.TabIndex = 1;
            this.btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);
            this.lblArchivoFoto.Location = new System.Drawing.Point(248, 80);
            this.lblArchivoFoto.Size = new System.Drawing.Size(568, 44);
            this.lblArchivoFoto.Name = "lblArchivoFoto";
            this.lblArchivoFoto.Text = "Sin foto seleccionada";
            this.lblFormatoFoto.Location = new System.Drawing.Point(248, 138);
            this.lblFormatoFoto.Size = new System.Drawing.Size(568, 26);
            this.lblFormatoFoto.Name = "lblFormatoFoto";
            this.lblFormatoFoto.Text = "JPG, JPEG o PNG. Hasta 2 MB. Foto opcional.";
            this.grpFoto.Controls.Add(this.picFoto);
            this.grpFoto.Controls.Add(this.btnElegirFoto);
            this.grpFoto.Controls.Add(this.btnQuitarFoto);
            this.grpFoto.Controls.Add(this.lblArchivoFoto);
            this.grpFoto.Controls.Add(this.lblFormatoFoto);
            this.Controls.Add(this.grpFoto);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panelEncabezado);
            ((System.ComponentModel.ISupportInitialize)(this.errores)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.grpFoto.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.GroupBox grpFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnElegirFoto;
        private System.Windows.Forms.Button btnQuitarFoto;
        private System.Windows.Forms.Label lblArchivoFoto;
        private System.Windows.Forms.Label lblFormatoFoto;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblEjemploPrecio;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblSuplidor;
        private System.Windows.Forms.ComboBox cmbSuplidor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda;
    }
}
