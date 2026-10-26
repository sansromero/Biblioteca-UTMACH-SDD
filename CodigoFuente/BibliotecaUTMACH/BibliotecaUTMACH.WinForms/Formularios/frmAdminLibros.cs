using System;
using System.Linq;
using System.Windows.Forms;
using BibliotecaUTMACH.Core.Controlador;
using BibliotecaUTMACH.Core.Entidades;
using BibliotecaUTMACH.Core.Servicios;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmAdminLibros : Form
    {
        private readonly ServicioLibros servicio;
        public frmAdminLibros()
        {
            InitializeComponent();
            servicio = new ServicioLibros(TLista.listaLibros, TLista.listaPrestamos);
            cboDisponibilidad.Items.AddRange(new object[] { "Todos", "Disponibles", "Agotados" });
            cboDisponibilidad.SelectedIndex = 0;
            txtBuscar.TextChanged += FiltroCambiado;
            cboDisponibilidad.SelectedIndexChanged += FiltroCambiado;
            Listar();
        }
        public void Listar()
        {
            string busqueda;
            string disponibilidad;
            busqueda = txtBuscar.Text;
            if (cboDisponibilidad.SelectedItem != null)
            {
                disponibilidad = cboDisponibilidad.SelectedItem.ToString();
            }
            else
            {
                disponibilidad = "Todos";
            }
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = servicio.Listar(busqueda, disponibilidad);
        }
        private int ObtenerIdSeleccionado()
        {
            LibroVista fila;
            int id;
            fila = null;
            id = -1;
            if (dgvLibros.CurrentRow != null)
            {
                fila = dgvLibros.CurrentRow.DataBoundItem as LibroVista;
                if (fila != null)
                {
                    id = fila.IdLibro;
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


        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            frmEditLibro formulario;
            DialogResult respuesta;
            ResultadoOperacion resultado;
            formulario = new frmEditLibro();
            formulario.PrepararNuevo(servicio.SiguienteId());
            respuesta = formulario.ShowDialog(this);
            if (respuesta == DialogResult.OK)
            {
                resultado = servicio.Agregar(formulario.CrearObjeto());
                MessageBox.Show(resultado.Mensaje);
                Listar();
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            int id;
            Libro libro;
            frmEditLibro formulario;
            DialogResult respuesta;
            ResultadoOperacion resultado;
            id = ObtenerIdSeleccionado();
            libro = servicio.BuscarPorId(id);
            formulario = null;
            respuesta = DialogResult.Cancel;
            if (libro != null)
            {
                formulario = new frmEditLibro();
                formulario.setDatos(libro);
                respuesta = formulario.ShowDialog(this);
                if (respuesta == DialogResult.OK)
                {
                    resultado = servicio.Modificar(id, formulario.CrearObjeto());
                    MessageBox.Show(resultado.Mensaje);
                    Listar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un libro válido.");
            }
        }

        private void btnDesactivar_Click_1(object sender, EventArgs e)
        {
            int id;
            DialogResult respuesta;
            ResultadoOperacion resultado;
            id = ObtenerIdSeleccionado();
            respuesta = DialogResult.No;
            if (id >= 0)
            {
                respuesta = MessageBox.Show("¿Desactivar este libro? Su historial se conservará.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    resultado = servicio.Desactivar(id);
                    MessageBox.Show(resultado.Mensaje);
                    Listar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un libro.");
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
