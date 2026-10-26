namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmEditPrestamo
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            else
            {
                // Los componentes no necesitan liberación adicional.
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblUsuario = new Label();
            cboUsuario = new ComboBox();
            lblLibro = new Label();
            cboLibro = new ComboBox();
            lblFecha = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            lblVencimiento = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(265, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(155, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NUEVO PRÉSTAMO";
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(35, 90);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 28);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // cboUsuario
            // 
            cboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUsuario.Location = new Point(180, 87);
            cboUsuario.Name = "cboUsuario";
            cboUsuario.Size = new Size(450, 23);
            cboUsuario.TabIndex = 2;
            // 
            // lblLibro
            // 
            lblLibro.Location = new Point(35, 135);
            lblLibro.Name = "lblLibro";
            lblLibro.Size = new Size(56, 28);
            lblLibro.TabIndex = 3;
            lblLibro.Text = "Libro:";
            // 
            // cboLibro
            // 
            cboLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLibro.Location = new Point(180, 132);
            cboLibro.Name = "cboLibro";
            cboLibro.Size = new Size(450, 23);
            cboLibro.TabIndex = 4;
            // 
            // lblFecha
            // 
            lblFecha.Location = new Point(26, 176);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(99, 28);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha préstamo:";
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            dtpFechaPrestamo.Location = new Point(180, 176);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(215, 23);
            dtpFechaPrestamo.TabIndex = 6;
            // 
            // lblVencimiento
            // 
            lblVencimiento.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVencimiento.Location = new Point(35, 233);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(515, 28);
            lblVencimiento.TabIndex = 7;
            lblVencimiento.Text = "Vencimiento: -";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(193, 283);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(135, 36);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(334, 283);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(135, 36);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmEditPrestamo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 345);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(cboUsuario);
            Controls.Add(lblLibro);
            Controls.Add(cboLibro);
            Controls.Add(lblFecha);
            Controls.Add(dtpFechaPrestamo);
            Controls.Add(lblVencimiento);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 9F);
            Name = "frmEditPrestamo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar préstamo";
            ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaPrestamo;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
