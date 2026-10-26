namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmAdminLibros
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
            lblEstado = new Label();
            cboDisponibilidad = new ComboBox();
            dgvLibros = new DataGridView();
            btnInsertar = new Button();
            btnModificar = new Button();
            btnDesactivar = new Button();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(35, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ADMINISTRAR LIBROS";
            // 
            // lblBuscar
            // 
            lblBuscar.Location = new Point(40, 88);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(160, 28);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar código/título:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(205, 86);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(440, 23);
            txtBuscar.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.Location = new Point(665, 88);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(115, 28);
            lblEstado.TabIndex = 3;
            lblEstado.Text = "Disponibilidad:";
            // 
            // cboDisponibilidad
            // 
            cboDisponibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDisponibilidad.Location = new Point(790, 86);
            cboDisponibilidad.Name = "cboDisponibilidad";
            cboDisponibilidad.Size = new Size(240, 23);
            cboDisponibilidad.TabIndex = 4;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvLibros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 55, 72);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLibros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLibros.DefaultCellStyle = dataGridViewCellStyle3;
            dgvLibros.EnableHeadersVisualStyles = false;
            dgvLibros.Location = new Point(40, 140);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(990, 370);
            dgvLibros.TabIndex = 5;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(85, 543);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(135, 36);
            btnInsertar.TabIndex = 6;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(285, 543);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(135, 36);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(485, 543);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(135, 36);
            btnDesactivar.TabIndex = 8;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click_1;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(685, 543);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(135, 36);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click_1;
            // 
            // frmAdminLibros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 640);
            Controls.Add(lblTitulo);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblEstado);
            Controls.Add(cboDisponibilidad);
            Controls.Add(dgvLibros);
            Controls.Add(btnInsertar);
            Controls.Add(btnModificar);
            Controls.Add(btnDesactivar);
            Controls.Add(btnActualizar);
            Font = new Font("Segoe UI", 9F);
            Name = "frmAdminLibros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar libros";
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboDisponibilidad;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnActualizar;
    }
}
