namespace SistemaInventario.Presentacion
{
    partial class CategoriaForm
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.grpFotos = new System.Windows.Forms.GroupBox();
            this.lstFotos = new System.Windows.Forms.ListBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnAgregarFoto = new System.Windows.Forms.Button();
            this.btnQuitarFoto = new System.Windows.Forms.Button();
            this.lblCantidadFotos = new System.Windows.Forms.Label();
            this.lblFormato = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.grpFotos.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // grpDatos
            //
            this.grpDatos.Location = new System.Drawing.Point(18, 96);
            this.grpDatos.Size = new System.Drawing.Size(804, 160);
            this.grpDatos.Text = "Datos de la categoría";
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.TabIndex = 0;
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblDescripcion);
            this.grpDatos.Controls.Add(this.txtDescripcion);
            //
            // lblNombre
            //
            this.lblNombre.Location = new System.Drawing.Point(18, 31);
            this.lblNombre.Size = new System.Drawing.Size(130, 22);
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 1;
            //
            // txtNombre
            //
            this.txtNombre.Location = new System.Drawing.Point(160, 28);
            this.txtNombre.Size = new System.Drawing.Size(616, 23);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            //
            // lblDescripcion
            //
            this.lblDescripcion.Location = new System.Drawing.Point(18, 72);
            this.lblDescripcion.Size = new System.Drawing.Size(130, 22);
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.TabIndex = 3;
            //
            // txtDescripcion
            //
            this.txtDescripcion.Location = new System.Drawing.Point(160, 68);
            this.txtDescripcion.Size = new System.Drawing.Size(616, 66);
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.MaxLength = 500;
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Name = "txtDescripcion";
            //
            // grpFotos
            //
            this.grpFotos.Location = new System.Drawing.Point(18, 272);
            this.grpFotos.Size = new System.Drawing.Size(804, 232);
            this.grpFotos.Text = "Fotos de la categoría";
            this.grpFotos.Name = "grpFotos";
            this.grpFotos.TabIndex = 5;
            this.grpFotos.Controls.Add(this.lstFotos);
            this.grpFotos.Controls.Add(this.picFoto);
            this.grpFotos.Controls.Add(this.btnAgregarFoto);
            this.grpFotos.Controls.Add(this.btnQuitarFoto);
            this.grpFotos.Controls.Add(this.lblCantidadFotos);
            this.grpFotos.Controls.Add(this.lblFormato);
            //
            // lstFotos
            //
            this.lstFotos.Location = new System.Drawing.Point(16, 28);
            this.lstFotos.Size = new System.Drawing.Size(438, 154);
            this.lstFotos.IntegralHeight = false;
            this.lstFotos.Name = "lstFotos";
            this.lstFotos.TabIndex = 6;
            this.lstFotos.SelectedIndexChanged += new System.EventHandler(this.lstFotos_SelectedIndexChanged);
            //
            // picFoto
            //
            this.picFoto.Location = new System.Drawing.Point(482, 28);
            this.picFoto.Size = new System.Drawing.Size(294, 154);
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.Name = "picFoto";
            this.picFoto.TabIndex = 7;
            //
            // btnAgregarFoto
            //
            this.btnAgregarFoto.Location = new System.Drawing.Point(16, 194);
            this.btnAgregarFoto.Size = new System.Drawing.Size(120, 28);
            this.btnAgregarFoto.Text = "Agregar foto";
            this.btnAgregarFoto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnAgregarFoto.UseVisualStyleBackColor = true;
            this.btnAgregarFoto.Name = "btnAgregarFoto";
            this.btnAgregarFoto.TabIndex = 8;
            this.btnAgregarFoto.Click += new System.EventHandler(this.btnAgregarFoto_Click);
            //
            // btnQuitarFoto
            //
            this.btnQuitarFoto.Location = new System.Drawing.Point(150, 194);
            this.btnQuitarFoto.Size = new System.Drawing.Size(120, 28);
            this.btnQuitarFoto.Text = "Quitar foto";
            this.btnQuitarFoto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnQuitarFoto.UseVisualStyleBackColor = true;
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.TabIndex = 9;
            this.btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);
            //
            // lblCantidadFotos
            //
            this.lblCantidadFotos.Location = new System.Drawing.Point(294, 199);
            this.lblCantidadFotos.Size = new System.Drawing.Size(150, 22);
            this.lblCantidadFotos.Text = "0 / 5 fotos";
            this.lblCantidadFotos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblCantidadFotos.Name = "lblCantidadFotos";
            this.lblCantidadFotos.TabIndex = 10;
            //
            // lblFormato
            //
            this.lblFormato.Location = new System.Drawing.Point(482, 199);
            this.lblFormato.Size = new System.Drawing.Size(300, 22);
            this.lblFormato.Text = "JPG, JPEG o PNG. Máximo 2 MB por foto.";
            this.lblFormato.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.TabIndex = 11;
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(574, 532);
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(57, 114, 165);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(688, 532);
            this.btnCancelar.Size = new System.Drawing.Size(116, 34);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.TabIndex = 13;
            //
            // panelEncabezado
            //
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Size = new System.Drawing.Size(840, 80);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(223, 235, 247);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.TabIndex = 14;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblAyuda);
            //
            // lblTitulo
            //
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Size = new System.Drawing.Size(804, 32);
            this.lblTitulo.Text = "Categoría";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 15;
            //
            // lblAyuda
            //
            this.lblAyuda.Location = new System.Drawing.Point(21, 51);
            this.lblAyuda.Size = new System.Drawing.Size(798, 22);
            this.lblAyuda.Text = "Completa los datos y agrega hasta cinco fotos.";
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.TabIndex = 16;
            this.errores.ContainerControl = this;
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ClientSize = new System.Drawing.Size(840, 586);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "CategoriaForm";
            this.Text = "Categoria";
            this.Text = "Categoría";
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.CancelButton = this.btnCancelar;
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.grpFotos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panelEncabezado);
            ((System.ComponentModel.ISupportInitialize)(this.errores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.grpFotos.ResumeLayout(false);
            this.grpFotos.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox grpFotos;
        private System.Windows.Forms.ListBox lstFotos;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnAgregarFoto;
        private System.Windows.Forms.Button btnQuitarFoto;
        private System.Windows.Forms.Label lblCantidadFotos;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda;
    }
}
