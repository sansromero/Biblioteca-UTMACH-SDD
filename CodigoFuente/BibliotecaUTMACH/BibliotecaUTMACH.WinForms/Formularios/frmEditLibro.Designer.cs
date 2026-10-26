namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmEditLibro
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
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            lblNombre = new Label();
            txtTitulo = new TextBox();
            lblAutor = new Label();
            txtAutor = new TextBox();
            lblCategoria = new Label();
            txtCategoria = new TextBox();
            lblAnio = new Label();
            nudAnio = new NumericUpDown();
            lblEjemplares = new Label();
            nudEjemplares = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEjemplares).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(171, 31);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(162, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE LIBRO";
            // 
            // lblCodigo
            // 
            lblCodigo.Location = new Point(80, 92);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(52, 28);
            lblCodigo.TabIndex = 1;
            lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(191, 89);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(259, 23);
            txtCodigo.TabIndex = 2;
            // 
            // lblIsbn
            // 
            lblIsbn.Location = new Point(35, 137);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(97, 28);
            lblIsbn.TabIndex = 3;
            lblIsbn.Text = "ISBN (opcional):";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(191, 134);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(259, 23);
            txtIsbn.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(80, 182);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(52, 28);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(191, 179);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(259, 23);
            txtTitulo.TabIndex = 6;
            // 
            // lblAutor
            // 
            lblAutor.Location = new Point(80, 227);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(52, 28);
            lblAutor.TabIndex = 7;
            lblAutor.Text = "Autor:";
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(191, 224);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(259, 23);
            txtAutor.TabIndex = 8;
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(62, 272);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(70, 28);
            lblCategoria.TabIndex = 9;
            lblCategoria.Text = "Categoría:";
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(191, 269);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(259, 23);
            txtCategoria.TabIndex = 10;
            // 
            // lblAnio
            // 
            lblAnio.Location = new Point(80, 317);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(52, 28);
            lblAnio.TabIndex = 11;
            lblAnio.Text = "Año:";
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(191, 315);
            nudAnio.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(155, 23);
            nudAnio.TabIndex = 12;
            // 
            // lblEjemplares
            // 
            lblEjemplares.Location = new Point(62, 362);
            lblEjemplares.Name = "lblEjemplares";
            lblEjemplares.Size = new Size(70, 28);
            lblEjemplares.TabIndex = 13;
            lblEjemplares.Text = "Ejemplares:";
            // 
            // nudEjemplares
            // 
            nudEjemplares.Location = new Point(191, 360);
            nudEjemplares.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudEjemplares.Name = "nudEjemplares";
            nudEjemplares.Size = new Size(155, 23);
            nudEjemplares.TabIndex = 14;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(84, 435);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(135, 36);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(274, 435);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(135, 36);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmEditLibro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 515);
            Controls.Add(lblTitulo);
            Controls.Add(lblCodigo);
            Controls.Add(txtCodigo);
            Controls.Add(lblIsbn);
            Controls.Add(txtIsbn);
            Controls.Add(lblNombre);
            Controls.Add(txtTitulo);
            Controls.Add(lblAutor);
            Controls.Add(txtAutor);
            Controls.Add(lblCategoria);
            Controls.Add(txtCategoria);
            Controls.Add(lblAnio);
            Controls.Add(nudAnio);
            Controls.Add(lblEjemplares);
            Controls.Add(nudEjemplares);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 9F);
            Name = "frmEditLibro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos del libro";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEjemplares).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Label lblEjemplares;
        private System.Windows.Forms.NumericUpDown nudEjemplares;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
