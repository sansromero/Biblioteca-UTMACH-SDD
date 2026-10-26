using System;
using System.Windows.Forms;
using BibliotecaUTMACH.Core.Controlador;
using BibliotecaUTMACH.Core.Entidades;
using BibliotecaUTMACH.Core.Servicios;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmAdminPrestamos : Form
    {
        private readonly ServicioPrestamos servicio;
        public frmAdminPrestamos()
        {
            InitializeComponent();
            servicio = new ServicioPrestamos(TLista.listaLibros, TLista.listaUsuarios, TLista.listaPrestamos);
            cboEstado.Items.AddRange(new object[] { "Todos", "Activo", "Vencido", "Devuelto" });
            cboEstado.SelectedIndex = 0;
            cboEstado.SelectedIndexChanged += FiltroCambiado;
            btnPrestar.Click += btnPrestar_Click;
            btnDevolver.Click += btnDevolver_Click;
            Listar();
        }
        public void Listar()
        {
            string estado;
            if (cboEstado.SelectedItem != null)
            {
                estado = cboEstado.SelectedItem.ToString();
            }
            else
            {
                estado = "Todos";
            }
            dgvPrestamos.DataSource = null;
            dgvPrestamos.DataSource = servicio.Listar(estado, DateTime.Today);
        }
        private int ObtenerIdSeleccionado()
        {
            PrestamoVista vista;
            int id;
            vista = null;
            id = -1;
            if (dgvPrestamos.CurrentRow != null)
            {
                vista = dgvPrestamos.CurrentRow.DataBoundItem as PrestamoVista;
                if (vista != null)
                {
                    id = vista.IdPrestamo;
                }
                else
                {
                    id = -1;
                }
            }
            else
            {
                id = -1;
            }
            return id;
        }
        private void FiltroCambiado(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnPrestar_Click(object sender, EventArgs e)
        {
            frmEditPrestamo formulario;
            DialogResult respuesta;
            ResultadoOperacion resultado;
            formulario = new frmEditPrestamo();
            respuesta = formulario.ShowDialog(this);
            if (respuesta == DialogResult.OK)
            {
                resultado = servicio.Registrar(formulario.IdUsuarioSeleccionado, formulario.IdLibroSeleccionado, formulario.FechaSeleccionada);
                MessageBox.Show(resultado.Mensaje);
                Listar();
            }
        }
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            int id;
            DialogResult confirmacion;
            ResultadoOperacion resultado;
            id = ObtenerIdSeleccionado();
            confirmacion = DialogResult.No;
            if (id > 0)
            {
                confirmacion = MessageBox.Show("¿Registrar la devolución con fecha de hoy?", "Confirmación", MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    resultado = servicio.Devolver(id, DateTime.Today);
                    MessageBox.Show(resultado.Mensaje);
                    Listar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un préstamo.");
            }
        }
    }
}
