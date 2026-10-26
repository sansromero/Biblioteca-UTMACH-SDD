using System;
using System.Windows.Forms;
using BibliotecaUTMACH.Core.Controlador;
using BibliotecaUTMACH.Core.Entidades;
using BibliotecaUTMACH.Core.Servicios;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmAdminUsuarios : Form
    {
        private readonly ServicioUsuarios servicio;
        public frmAdminUsuarios()
        {
            InitializeComponent();
            servicio = new ServicioUsuarios(TLista.listaUsuarios, TLista.listaPrestamos);
            cboTipo.Items.AddRange(new object[] { "Todos", "Estudiantes", "Docentes" });
            cboTipo.SelectedIndex = 0;
            cboTipo.SelectedIndexChanged += FiltroCambiado;
            txtBuscar.TextChanged += FiltroCambiado;
            btnInsertar.Click += btnInsertar_Click;
            btnModificar.Click += btnModificar_Click;
            btnDesactivar.Click += btnDesactivar_Click;
            Listar();
        }
        public void Listar()
        {
            string tipo;
            if (cboTipo.SelectedItem != null)
            {
                tipo = cboTipo.SelectedItem.ToString();
            }
            else
            {
                tipo = "Todos";
            }
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = servicio.Listar(txtBuscar.Text, tipo);
        }
        private int ObtenerIdSeleccionado()
        {
            UsuarioVista vista;
            int id;
            vista = null;
            id = -1;
            if (dgvUsuarios.CurrentRow != null)
            {
                vista = dgvUsuarios.CurrentRow.DataBoundItem as UsuarioVista;
                if (vista != null)
                {
                    id = vista.IdUsuario;
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
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmEditUsuario formulario;
            DialogResult respuesta;
            ResultadoOperacion resultado;
            formulario = new frmEditUsuario();
            formulario.PrepararNuevo(servicio.SiguienteId());
            respuesta = formulario.ShowDialog(this);
            if (respuesta == DialogResult.OK)
            {
                resultado = servicio.Agregar(formulario.CrearObjeto());
                MessageBox.Show(resultado.Mensaje);
                Listar();
            }
            else
            {
                // Cancelado.
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id;
            Persona usuario;
            frmEditUsuario formulario;
            DialogResult respuesta;
            ResultadoOperacion resultado;
            id = ObtenerIdSeleccionado();
            usuario = servicio.BuscarPorId(id);
            formulario = null;
            respuesta = DialogResult.Cancel;
            if (usuario != null)
            {
                formulario = new frmEditUsuario();
                formulario.setDatos(usuario);
                respuesta = formulario.ShowDialog(this);
                if (respuesta == DialogResult.OK)
                {
                    resultado = servicio.Modificar(id, formulario.CrearObjeto());
                    MessageBox.Show(resultado.Mensaje);
                    Listar();
                }
                else
                {
                    // Cancelado.
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario válido.");
            }
        }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int id;
            DialogResult respuesta;
            ResultadoOperacion resultado;
            id = ObtenerIdSeleccionado();
            respuesta = DialogResult.No;
            if (id >= 0)
            {
                respuesta = MessageBox.Show("¿Desactivar al usuario seleccionado?", "Confirmar", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    resultado = servicio.Desactivar(id);
                    MessageBox.Show(resultado.Mensaje);
                    Listar();
                }
                else
                {
                    // Cancelado.
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario.");
            }
        }
    }
}
