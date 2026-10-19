namespace SistemaInventario.Presentacion
{
    partial class LoginForm
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
            this.grpAcceso = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.chkMostrarClave = new System.Windows.Forms.CheckBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errores)).BeginInit();
            this.grpAcceso.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // grpAcceso
            //
            this.grpAcceso.Location = new System.Drawing.Point(24, 98);
            this.grpAcceso.Size = new System.Drawing.Size(412, 146);
            this.grpAcceso.Text = "Datos de acceso";
            this.grpAcceso.Name = "grpAcceso";
            this.grpAcceso.TabIndex = 0;
            this.grpAcceso.Controls.Add(this.lblUsuario);
            this.grpAcceso.Controls.Add(this.txtUsuario);
            this.grpAcceso.Controls.Add(this.lblClave);
            this.grpAcceso.Controls.Add(this.txtClave);
            this.grpAcceso.Controls.Add(this.chkMostrarClave);
            //
            // lblUsuario
            //
            this.lblUsuario.Location = new System.Drawing.Point(18, 31);
            this.lblUsuario.Size = new System.Drawing.Size(94, 22);
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TabIndex = 1;
            //
            // txtUsuario
            //
            this.txtUsuario.Location = new System.Drawing.Point(122, 28);
            this.txtUsuario.Size = new System.Drawing.Size(258, 23);
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            //
            // lblClave
            //
            this.lblClave.Location = new System.Drawing.Point(18, 71);
            this.lblClave.Size = new System.Drawing.Size(94, 22);
            this.lblClave.Text = "Contraseña:";
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblClave.Name = "lblClave";
            this.lblClave.TabIndex = 3;
            //
            // txtClave
            //
            this.txtClave.Location = new System.Drawing.Point(122, 68);
            this.txtClave.Size = new System.Drawing.Size(258, 23);
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtClave.TabIndex = 1;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.MaxLength = 200;
            this.txtClave.Name = "txtClave";
            //
            // chkMostrarClave
            //
            this.chkMostrarClave.Location = new System.Drawing.Point(122, 106);
            this.chkMostrarClave.Size = new System.Drawing.Size(258, 24);
            this.chkMostrarClave.Text = "Mostrar contraseña";
            this.chkMostrarClave.TabIndex = 2;
            this.chkMostrarClave.Name = "chkMostrarClave";
            this.chkMostrarClave.CheckedChanged += new System.EventHandler(this.chkMostrarClave_CheckedChanged);
            //
            // btnIngresar
            //
            this.btnIngresar.Location = new System.Drawing.Point(208, 264);
            this.btnIngresar.Size = new System.Drawing.Size(108, 34);
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(57, 114, 165);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            //
            // btnSalir
            //
            this.btnSalir.Location = new System.Drawing.Point(330, 264);
            this.btnSalir.Size = new System.Drawing.Size(106, 34);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Name = "btnSalir";
            //
            // lblMensaje
            //
            this.lblMensaje.Location = new System.Drawing.Point(26, 312);
            this.lblMensaje.Size = new System.Drawing.Size(410, 38);
            this.lblMensaje.Text = "";
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblMensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.TabIndex = 9;
            //
            // panelEncabezado
            //
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Size = new System.Drawing.Size(460, 80);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(223, 235, 247);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.TabIndex = 10;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblAyuda);
            //
            // lblTitulo
            //
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Size = new System.Drawing.Size(424, 32);
            this.lblTitulo.Text = "Sistema de inventario";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 11;
            //
            // lblAyuda
            //
            this.lblAyuda.Location = new System.Drawing.Point(21, 51);
            this.lblAyuda.Size = new System.Drawing.Size(418, 22);
            this.lblAyuda.Text = "Categorías, suplidores y productos";
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.TabIndex = 12;
            this.errores.ContainerControl = this;
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ClientSize = new System.Drawing.Size(460, 364);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Text = "Inicio de sesión";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.AcceptButton = this.btnIngresar;
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.grpAcceso);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.panelEncabezado);
            ((System.ComponentModel.ISupportInitialize)(this.errores)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.grpAcceso.ResumeLayout(false);
            this.grpAcceso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.GroupBox grpAcceso;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.CheckBox chkMostrarClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda;
    }
}
