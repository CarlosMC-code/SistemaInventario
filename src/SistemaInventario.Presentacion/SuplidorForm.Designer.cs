namespace SistemaInventario.Presentacion
{
    partial class SuplidorForm
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
            this.lblNombreEmpresa = new System.Windows.Forms.Label();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.lblNombreContacto = new System.Windows.Forms.Label();
            this.txtNombreContacto = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblSitioWeb = new System.Windows.Forms.Label();
            this.txtSitioWeb = new System.Windows.Forms.TextBox();
            this.lblEjemploTelefono = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errores)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // grpDatos
            //
            this.grpDatos.Location = new System.Drawing.Point(18, 96);
            this.grpDatos.Size = new System.Drawing.Size(684, 292);
            this.grpDatos.Text = "Datos de contacto";
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.TabIndex = 0;
            this.grpDatos.Controls.Add(this.lblNombreEmpresa);
            this.grpDatos.Controls.Add(this.txtNombreEmpresa);
            this.grpDatos.Controls.Add(this.lblNombreContacto);
            this.grpDatos.Controls.Add(this.txtNombreContacto);
            this.grpDatos.Controls.Add(this.lblTelefono);
            this.grpDatos.Controls.Add(this.txtTelefono);
            this.grpDatos.Controls.Add(this.lblCorreo);
            this.grpDatos.Controls.Add(this.txtCorreo);
            this.grpDatos.Controls.Add(this.lblSitioWeb);
            this.grpDatos.Controls.Add(this.txtSitioWeb);
            this.grpDatos.Controls.Add(this.lblEjemploTelefono);
            //
            // lblNombreEmpresa
            //
            this.lblNombreEmpresa.Location = new System.Drawing.Point(18, 32);
            this.lblNombreEmpresa.Size = new System.Drawing.Size(146, 22);
            this.lblNombreEmpresa.Text = "Empresa:";
            this.lblNombreEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.TabIndex = 1;
            //
            // txtNombreEmpresa
            //
            this.txtNombreEmpresa.Location = new System.Drawing.Point(174, 29);
            this.txtNombreEmpresa.Size = new System.Drawing.Size(474, 23);
            this.txtNombreEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtNombreEmpresa.MaxLength = 150;
            this.txtNombreEmpresa.TabIndex = 0;
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            //
            // lblNombreContacto
            //
            this.lblNombreContacto.Location = new System.Drawing.Point(18, 74);
            this.lblNombreContacto.Size = new System.Drawing.Size(146, 22);
            this.lblNombreContacto.Text = "Contacto:";
            this.lblNombreContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNombreContacto.Name = "lblNombreContacto";
            this.lblNombreContacto.TabIndex = 3;
            //
            // txtNombreContacto
            //
            this.txtNombreContacto.Location = new System.Drawing.Point(174, 71);
            this.txtNombreContacto.Size = new System.Drawing.Size(474, 23);
            this.txtNombreContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtNombreContacto.MaxLength = 100;
            this.txtNombreContacto.TabIndex = 1;
            this.txtNombreContacto.Name = "txtNombreContacto";
            //
            // lblTelefono
            //
            this.lblTelefono.Location = new System.Drawing.Point(18, 116);
            this.lblTelefono.Size = new System.Drawing.Size(146, 22);
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.TabIndex = 5;
            //
            // txtTelefono
            //
            this.txtTelefono.Location = new System.Drawing.Point(174, 113);
            this.txtTelefono.Size = new System.Drawing.Size(474, 23);
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtTelefono.MaxLength = 12;
            this.txtTelefono.TabIndex = 2;
            this.txtTelefono.Name = "txtTelefono";
            //
            // lblCorreo
            //
            this.lblCorreo.Location = new System.Drawing.Point(18, 158);
            this.lblCorreo.Size = new System.Drawing.Size(146, 22);
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.TabIndex = 7;
            //
            // txtCorreo
            //
            this.txtCorreo.Location = new System.Drawing.Point(174, 155);
            this.txtCorreo.Size = new System.Drawing.Size(474, 23);
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtCorreo.MaxLength = 150;
            this.txtCorreo.TabIndex = 3;
            this.txtCorreo.Name = "txtCorreo";
            //
            // lblSitioWeb
            //
            this.lblSitioWeb.Location = new System.Drawing.Point(18, 200);
            this.lblSitioWeb.Size = new System.Drawing.Size(146, 22);
            this.lblSitioWeb.Text = "Sitio web (opcional):";
            this.lblSitioWeb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblSitioWeb.Name = "lblSitioWeb";
            this.lblSitioWeb.TabIndex = 9;
            //
            // txtSitioWeb
            //
            this.txtSitioWeb.Location = new System.Drawing.Point(174, 197);
            this.txtSitioWeb.Size = new System.Drawing.Size(474, 23);
            this.txtSitioWeb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtSitioWeb.MaxLength = 250;
            this.txtSitioWeb.TabIndex = 4;
            this.txtSitioWeb.Name = "txtSitioWeb";
            //
            // lblEjemploTelefono
            //
            this.lblEjemploTelefono.Location = new System.Drawing.Point(174, 246);
            this.lblEjemploTelefono.Size = new System.Drawing.Size(474, 22);
            this.lblEjemploTelefono.Text = "Ejemplo de teléfono: 809-555-1234";
            this.lblEjemploTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblEjemploTelefono.ForeColor = System.Drawing.Color.DimGray;
            this.lblEjemploTelefono.Name = "lblEjemploTelefono";
            this.lblEjemploTelefono.TabIndex = 11;
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(470, 414);
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
            this.btnCancelar.Location = new System.Drawing.Point(584, 414);
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
            this.panelEncabezado.Size = new System.Drawing.Size(720, 80);
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
            this.lblTitulo.Size = new System.Drawing.Size(684, 32);
            this.lblTitulo.Text = "Suplidor";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 15;
            //
            // lblAyuda
            //
            this.lblAyuda.Location = new System.Drawing.Point(21, 51);
            this.lblAyuda.Size = new System.Drawing.Size(678, 22);
            this.lblAyuda.Text = "Datos de la empresa y su persona de contacto.";
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.TabIndex = 16;
            this.errores.ContainerControl = this;
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ClientSize = new System.Drawing.Size(720, 470);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "SuplidorForm";
            this.Text = "Suplidor";
            this.Text = "Suplidor";
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.CancelButton = this.btnCancelar;
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panelEncabezado);
            ((System.ComponentModel.ISupportInitialize)(this.errores)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNombreEmpresa;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.Label lblNombreContacto;
        private System.Windows.Forms.TextBox txtNombreContacto;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblSitioWeb;
        private System.Windows.Forms.TextBox txtSitioWeb;
        private System.Windows.Forms.Label lblEjemploTelefono;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda;
    }
}
