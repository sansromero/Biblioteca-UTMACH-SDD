namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmPrincipal
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
            btnUsuarios = new Button();
            btnLibros = new Button();
            btnPrestamos = new Button();
            btnReportes = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(139, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(367, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "BIBLIOTECA UTMACH — SISTEMA DE GESTIÓN";
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(90, 115);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(215, 36);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnLibros
            // 
            btnLibros.Location = new Point(340, 115);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(215, 36);
            btnLibros.TabIndex = 2;
            btnLibros.Text = "Libros";
            btnLibros.UseVisualStyleBackColor = true;
            // 
            // btnPrestamos
            // 
            btnPrestamos.Location = new Point(90, 205);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(215, 36);
            btnPrestamos.TabIndex = 3;
            btnPrestamos.Text = "Préstamos";
            btnPrestamos.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(340, 205);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(215, 36);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 405);
            Controls.Add(lblTitulo);
            Controls.Add(btnUsuarios);
            Controls.Add(btnLibros);
            Controls.Add(btnPrestamos);
            Controls.Add(btnReportes);
            Font = new Font("Segoe UI", 9F);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Biblioteca UTMACH — Menú principal";
            ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnLibros;
        private System.Windows.Forms.Button btnPrestamos;
        private System.Windows.Forms.Button btnReportes;
    }
}
