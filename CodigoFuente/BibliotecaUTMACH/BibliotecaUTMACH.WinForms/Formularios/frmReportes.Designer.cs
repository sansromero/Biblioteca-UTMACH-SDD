namespace BibliotecaUTMACH.WinForms.Formularios
{
    partial class frmReportes
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblReporte = new Label();
            cboReporte = new ComboBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnConsultar = new Button();
            dgvResultados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(465, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(209, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REPORTES DE BIBLIOTECA";
            // 
            // lblReporte
            // 
            lblReporte.Location = new Point(40, 88);
            lblReporte.Name = "lblReporte";
            lblReporte.Size = new Size(52, 28);
            lblReporte.TabIndex = 1;
            lblReporte.Text = "Reporte:";
            // 
            // cboReporte
            // 
            cboReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboReporte.Location = new Point(98, 88);
            cboReporte.Name = "cboReporte";
            cboReporte.Size = new Size(300, 23);
            cboReporte.TabIndex = 2;
            // 
            // lblDesde
            // 
            lblDesde.Location = new Point(465, 88);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(47, 28);
            lblDesde.TabIndex = 3;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(535, 85);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(170, 23);
            dtpDesde.TabIndex = 4;
            // 
            // lblHasta
            // 
            lblHasta.Location = new Point(720, 88);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(44, 28);
            lblHasta.TabIndex = 5;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(785, 85);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(170, 23);
            dtpHasta.TabIndex = 6;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(40, 145);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(155, 36);
            btnConsultar.TabIndex = 7;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dgvResultados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(45, 55, 72);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvResultados.DefaultCellStyle = dataGridViewCellStyle6;
            dgvResultados.EnableHeadersVisualStyles = false;
            dgvResultados.Location = new Point(40, 205);
            dgvResultados.MultiSelect = false;
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(1010, 405);
            dgvResultados.TabIndex = 8;
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 673);
            Controls.Add(lblTitulo);
            Controls.Add(lblReporte);
            Controls.Add(cboReporte);
            Controls.Add(lblDesde);
            Controls.Add(dtpDesde);
            Controls.Add(lblHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnConsultar);
            Controls.Add(dgvResultados);
            Font = new Font("Segoe UI", 9F);
            Name = "frmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes de biblioteca";
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.ComboBox cboReporte;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvResultados;
    }
}
