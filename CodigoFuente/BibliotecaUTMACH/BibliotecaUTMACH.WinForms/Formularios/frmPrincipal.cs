using System;
using System.Windows.Forms;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            btnUsuarios.Click += btnUsuarios_Click;
            btnLibros.Click += btnLibros_Click;
            btnPrestamos.Click += btnPrestamos_Click;
            btnReportes.Click += btnReportes_Click;
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmAdminUsuarios formulario;
            formulario = new frmAdminUsuarios();
            formulario.ShowDialog(this);
        }
        private void btnLibros_Click(object sender, EventArgs e)
        {
            frmAdminLibros formulario;
            formulario = new frmAdminLibros();
            formulario.ShowDialog(this);
        }
        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            frmAdminPrestamos formulario;
            formulario = new frmAdminPrestamos();
            formulario.ShowDialog(this);
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReportes formulario;
            formulario = new frmReportes();
            formulario.ShowDialog(this);
        }
    }
}
