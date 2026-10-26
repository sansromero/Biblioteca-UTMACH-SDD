namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmEditUsuario
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
            lblCedula = new Label();
            txtCedula = new TextBox();
            lblNombres = new Label();
            txtNombres = new TextBox();
            lblApellidos = new Label();
            txtApellidos = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblTipo = new Label();
            cboTipoUsuario = new ComboBox();
            lblDato1 = new Label();
            txtDatoEspecifico1 = new TextBox();
            lblDato2 = new Label();
            txtDatoEspecifico2 = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(243, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(195, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE USUARIO";
            // 
            // lblCedula
            // 
            lblCedula.Location = new Point(78, 78);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(50, 28);
            lblCedula.TabIndex = 1;
            lblCedula.Text = "Cédula:";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(195, 75);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(420, 23);
            txtCedula.TabIndex = 2;
            // 
            // lblNombres
            // 
            lblNombres.Location = new Point(64, 123);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(64, 28);
            lblNombres.TabIndex = 3;
            lblNombres.Text = "Nombres:";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(195, 120);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(420, 23);
            txtNombres.TabIndex = 4;
            // 
            // lblApellidos
            // 
            lblApellidos.Location = new Point(64, 168);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(64, 28);
            lblApellidos.TabIndex = 5;
            lblApellidos.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(195, 165);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(420, 23);
            txtApellidos.TabIndex = 6;
            // 
            // lblCorreo
            // 
            lblCorreo.Location = new Point(78, 213);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(50, 28);
            lblCorreo.TabIndex = 7;
            lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(195, 210);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(420, 23);
            txtCorreo.TabIndex = 8;
            // 
            // lblTipo
            // 
            lblTipo.Location = new Point(30, 258);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(98, 28);
            lblTipo.TabIndex = 9;
            lblTipo.Text = "Tipo de usuario:";
            // 
            // cboTipoUsuario
            // 
            cboTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoUsuario.Location = new Point(195, 255);
            cboTipoUsuario.Name = "cboTipoUsuario";
            cboTipoUsuario.Size = new Size(420, 23);
            cboTipoUsuario.TabIndex = 10;
            // 
            // lblDato1
            // 
            lblDato1.Location = new Point(21, 305);
            lblDato1.Name = "lblDato1";
            lblDato1.Size = new Size(107, 28);
            lblDato1.TabIndex = 11;
            lblDato1.Text = "Matrícula/Código:";
            // 
            // txtDatoEspecifico1
            // 
            txtDatoEspecifico1.Location = new Point(195, 302);
            txtDatoEspecifico1.Name = "txtDatoEspecifico1";
            txtDatoEspecifico1.Size = new Size(420, 23);
            txtDatoEspecifico1.TabIndex = 12;
            // 
            // lblDato2
            // 
            lblDato2.Location = new Point(30, 350);
            lblDato2.Name = "lblDato2";
            lblDato2.Size = new Size(98, 28);
            lblDato2.TabIndex = 13;
            lblDato2.Text = "Carrera/Facultad:";
            // 
            // txtDatoEspecifico2
            // 
            txtDatoEspecifico2.Location = new Point(195, 347);
            txtDatoEspecifico2.Name = "txtDatoEspecifico2";
            txtDatoEspecifico2.Size = new Size(420, 23);
            txtDatoEspecifico2.TabIndex = 14;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(160, 432);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(135, 36);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(360, 432);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(135, 36);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmEditUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 530);
            Controls.Add(lblTitulo);
            Controls.Add(lblCedula);
            Controls.Add(txtCedula);
            Controls.Add(lblNombres);
            Controls.Add(txtNombres);
            Controls.Add(lblApellidos);
            Controls.Add(txtApellidos);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblTipo);
            Controls.Add(cboTipoUsuario);
            Controls.Add(lblDato1);
            Controls.Add(txtDatoEspecifico1);
            Controls.Add(lblDato2);
            Controls.Add(txtDatoEspecifico2);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 9F);
            Name = "frmEditUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos de estudiante o docente";
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipoUsuario;
        private System.Windows.Forms.Label lblDato1;
        private System.Windows.Forms.TextBox txtDatoEspecifico1;
        private System.Windows.Forms.Label lblDato2;
        private System.Windows.Forms.TextBox txtDatoEspecifico2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
