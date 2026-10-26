using System;
using System.Linq;
using System.Windows.Forms;
using BibliotecaUTMACH.Core.Controlador;
using BibliotecaUTMACH.Core.Entidades;
using BibliotecaUTMACH.Core.Servicios;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmEditPrestamo : Form
    {
        private readonly ServicioLibros servicioLibros;
        public frmEditPrestamo()
        {
            InitializeComponent();
            servicioLibros = new ServicioLibros(TLista.listaLibros, TLista.listaPrestamos);
            cboUsuario.DisplayMember = "NombreCompleto";
            cboUsuario.ValueMember = "IdUsuario";
            cboUsuario.DataSource = TLista.listaUsuarios.Where(usuario => usuario != null && usuario.Activo).ToList();
            cboLibro.DisplayMember = "Descripcion";
            cboLibro.ValueMember = "IdLibro";
            cboLibro.DataSource = TLista.listaLibros.Where(libro => libro != null && libro.Activo && servicioLibros.ObtenerDisponibles(libro) > 0).ToList();
            cboUsuario.SelectedIndex = -1;
            cboLibro.SelectedIndex = -1;
            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaPrestamo.MaxDate = DateTime.Today;
            cboUsuario.SelectedIndexChanged += ActualizarVencimiento;
            dtpFechaPrestamo.ValueChanged += ActualizarVencimiento;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
            ActualizarVencimiento(this, EventArgs.Empty);
        }
        public int IdUsuarioSeleccionado
        {
            get
            {
                int id;
                Persona usuario;
                usuario = cboUsuario.SelectedItem as Persona;
                if (usuario != null)
                {
                    id = usuario.IdUsuario;
                }
                else
                {
                    id = -1;
                }
                return id;
            }
        }
        public int IdLibroSeleccionado
        {
            get
            {
                int id;
                Libro libro;
                libro = cboLibro.SelectedItem as Libro;
                if (libro != null)
                {
                    id = libro.IdLibro;
                }
                else
                {
                    id = -1;
                }
                return id;
            }
        }
        public DateTime FechaSeleccionada
        {
            get
            {
                DateTime fecha;
                fecha = dtpFechaPrestamo.Value.Date;
                return fecha;
            }
        }
        private void ActualizarVencimiento(object sender, EventArgs e)
        {
            Persona usuario;
            DateTime vencimiento;
            usuario = cboUsuario.SelectedItem as Persona;
            vencimiento = DateTime.Today;
            if (usuario != null)
            {
                vencimiento = dtpFechaPrestamo.Value.Date.AddDays(usuario.PlazoDias);
                lblVencimiento.Text = "Vencimiento: " + vencimiento.ToShortDateString();
            }
            else
            {
                lblVencimiento.Text = "Vencimiento: seleccione un usuario";
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool valido;
            valido = IdUsuarioSeleccionado > 0 && IdLibroSeleccionado > 0;
            if (valido)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Seleccione un usuario y un libro disponibles.");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
