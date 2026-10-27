namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmAdminPrestamos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblEstado = new Label();
            cboEstado = new ComboBox();
            dgvPrestamos = new DataGridView();
            btnPrestar = new Button();
            btnDevolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(35, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE PRÉSTAMOS";
            // 
            // lblEstado
            // 
            lblEstado.Location = new Point(40, 85);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(160, 28);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Filtrar estado:";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Location = new Point(206, 82);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(279, 23);
            cboEstado.TabIndex = 2;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvPrestamos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 55, 72);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPrestamos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPrestamos.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPrestamos.EnableHeadersVisualStyles = false;
            dgvPrestamos.Location = new Point(40, 138);
            dgvPrestamos.MultiSelect = false;
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.RowHeadersVisible = false;
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.Size = new Size(990, 380);
            dgvPrestamos.TabIndex = 3;
            // 
            // btnPrestar
            // 
            btnPrestar.Location = new Point(210, 546);
            btnPrestar.Name = "btnPrestar";
            btnPrestar.Size = new Size(220, 36);
            btnPrestar.TabIndex = 4;
            btnPrestar.Text = "Prestar libro";
            btnPrestar.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(585, 546);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(240, 36);
            btnDevolver.TabIndex = 5;
            btnDevolver.Text = "Registrar devolución";
            btnDevolver.UseVisualStyleBackColor = true;
            // 
            // frmAdminPrestamos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 630);
            Controls.Add(lblTitulo);
            Controls.Add(lblEstado);
            Controls.Add(cboEstado);
            Controls.Add(dgvPrestamos);
            Controls.Add(btnPrestar);
            Controls.Add(btnDevolver);
            Font = new Font("Segoe UI", 9F);
            Name = "frmAdminPrestamos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestionar préstamos y devoluciones";
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.Button btnDevolver;
    }
}
