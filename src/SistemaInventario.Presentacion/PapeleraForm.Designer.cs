namespace SistemaInventario.Presentacion
{
    partial class PapeleraForm
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
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.dgvEliminados = new System.Windows.Forms.DataGridView();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminados)).BeginInit();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // cmbTipo
            //
            this.cmbTipo.Location = new System.Drawing.Point(18, 102);
            this.cmbTipo.Size = new System.Drawing.Size(198, 23);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.TabIndex = 0;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            this.cmbTipo.Items.AddRange(new object[] { "Categorías", "Suplidores", "Productos" });
            //
            // lblBuscar
            //
            this.lblBuscar.Location = new System.Drawing.Point(232, 105);
            this.lblBuscar.Size = new System.Drawing.Size(56, 22);
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.TabIndex = 1;
            //
            // txtBuscar
            //
            this.txtBuscar.Location = new System.Drawing.Point(292, 102);
            this.txtBuscar.Size = new System.Drawing.Size(366, 23);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //
            // btnRestaurar
            //
            this.btnRestaurar.Location = new System.Drawing.Point(678, 97);
            this.btnRestaurar.Size = new System.Drawing.Size(164, 32);
            this.btnRestaurar.Text = "Restaurar seleccionado";
            this.btnRestaurar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(57, 114, 165);
            this.btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            //
            // dgvEliminados
            //
            this.dgvEliminados.Location = new System.Drawing.Point(18, 146);
            this.dgvEliminados.Size = new System.Drawing.Size(824, 344);
            this.dgvEliminados.ReadOnly = true;
            this.dgvEliminados.AllowUserToAddRows = false;
            this.dgvEliminados.AllowUserToDeleteRows = false;
            this.dgvEliminados.AllowUserToResizeRows = false;
            this.dgvEliminados.MultiSelect = false;
            this.dgvEliminados.RowHeadersVisible = false;
            this.dgvEliminados.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEliminados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEliminados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEliminados.RowTemplate.Height = 28;
            this.dgvEliminados.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvEliminados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dgvEliminados.Name = "dgvEliminados";
            this.dgvEliminados.TabIndex = 4;
            //
            // lblNota
            //
            this.lblNota.Location = new System.Drawing.Point(20, 514);
            this.lblNota.Size = new System.Drawing.Size(680, 26);
            this.lblNota.Text = "Para restaurar productos, su categoría y suplidor deben estar activos.";
            this.lblNota.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.lblNota.Name = "lblNota";
            this.lblNota.TabIndex = 5;
            //
            // btnCerrar
            //
            this.btnCerrar.Location = new System.Drawing.Point(728, 508);
            this.btnCerrar.Size = new System.Drawing.Size(112, 32);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.TabIndex = 6;
            //
            // panelEncabezado
            //
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Size = new System.Drawing.Size(860, 80);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(223, 235, 247);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.TabIndex = 7;
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblAyuda);
            //
            // lblTitulo
            //
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Size = new System.Drawing.Size(824, 32);
            this.lblTitulo.Text = "Papelera";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 8;
            //
            // lblAyuda
            //
            this.lblAyuda.Location = new System.Drawing.Point(21, 51);
            this.lblAyuda.Size = new System.Drawing.Size(818, 22);
            this.lblAyuda.Text = "Registros eliminados. Solo el administrador puede restaurarlos.";
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.TabIndex = 9;
            this.errores.ContainerControl = this;
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ClientSize = new System.Drawing.Size(860, 562);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "PapeleraForm";
            this.Text = "Papelera";
            this.Text = "Papelera";
            this.MinimumSize = new System.Drawing.Size(876, 601);
            this.CancelButton = this.btnCerrar;
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.dgvEliminados);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelEncabezado);
            ((System.ComponentModel.ISupportInitialize)(this.errores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminados)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.DataGridView dgvEliminados;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda;
    }
}
