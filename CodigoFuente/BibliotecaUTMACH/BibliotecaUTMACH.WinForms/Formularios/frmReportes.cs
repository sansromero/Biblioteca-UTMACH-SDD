using System;
using System.Windows.Forms;
using BibliotecaUTMACH.Core.Controlador;
using BibliotecaUTMACH.Core.Servicios;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmReportes : Form
    {
        private readonly ServicioReportes servicio;
        public frmReportes()
        {
            InitializeComponent();
            servicio = new ServicioReportes(TLista.listaUsuarios, TLista.listaLibros, TLista.listaPrestamos);
            cboReporte.Items.AddRange(new object[] { "Disponibilidad de libros", "Préstamos activos", "Préstamos vencidos", "Préstamos por tipo de usuario", "Resumen general" });
            cboReporte.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            btnConsultar.Click += btnConsultar_Click;
            Consultar();
        }
        public void Consultar()
        {
            string tipo;
            DateTime desde;
            DateTime hasta;
            if (cboReporte.SelectedItem != null)
            {
                tipo = cboReporte.SelectedItem.ToString();
            }
            else
            {
                tipo = "Resumen general";
            }
            desde = dtpDesde.Value.Date;
            hasta = dtpHasta.Value.Date;
            if (hasta >= desde)
            {
                dgvResultados.DataSource = null;
                dgvResultados.DataSource = servicio.Generar(tipo, desde, hasta, DateTime.Today);
            }
            else
            {
                MessageBox.Show("La fecha final debe ser posterior o igual a la inicial.");
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }
    }
}
