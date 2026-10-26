namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmAdminUsuarios
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            dgvUsuarios = new DataGridView();
            btnInsertar = new Button();
            btnModificar = new Button();
            btnDesactivar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(35, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ADMINISTRAR USUARIOS";
            // 
            // lblBuscar
            // 
            lblBuscar.Location = new Point(40, 88);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(51, 28);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(95, 88);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(440, 23);
            txtBuscar.TabIndex = 2;
            // 
            // lblTipo
            // 
            lblTipo.Location = new Point(665, 88);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(45, 28);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Location = new Point(725, 88);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(240, 23);
            cboTipo.TabIndex = 4;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 55, 72);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle3;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.Location = new Point(40, 140);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(990, 370);
            dgvUsuarios.TabIndex = 5;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(324, 549);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(135, 36);
            btnInsertar.TabIndex = 6;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(465, 549);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(135, 36);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(606, 549);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(135, 36);
            btnDesactivar.TabIndex = 8;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            // 
            // frmAdminUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 640);
            Controls.Add(lblTitulo);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblTipo);
            Controls.Add(cboTipo);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnInsertar);
            Controls.Add(btnModificar);
            Controls.Add(btnDesactivar);
            Font = new Font("Segoe UI", 9F);
            Name = "frmAdminUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesactivar;
    }
}
