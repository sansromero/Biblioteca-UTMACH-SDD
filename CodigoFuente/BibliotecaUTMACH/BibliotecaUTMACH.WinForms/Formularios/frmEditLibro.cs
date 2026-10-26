using System;
using System.Windows.Forms;
using BibliotecaUTMACH.Core.Entidades;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmEditLibro : Form
    {
        private int idLibro;
        private bool activo;
        public frmEditLibro()
        {
            InitializeComponent();
            idLibro = 0;
            activo = true;
            nudAnio.Minimum = 1;
            nudAnio.Maximum = DateTime.Today.Year;
            nudAnio.Value = DateTime.Today.Year;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }
        public void PrepararNuevo(int nuevoId)
        {
            idLibro = nuevoId;
            activo = true;
            Limpiar();
            Text = "Insertar libro";
        }
        public void setDatos(Libro libro)
        {
            bool libroValido;
            libroValido = libro != null;
            if (libroValido)
            {
                idLibro = libro.IdLibro;
                activo = libro.Activo;
                txtCodigo.Text = libro.CodigoLibro;
                txtIsbn.Text = libro.ISBN;
                txtTitulo.Text = libro.Titulo;
                txtAutor.Text = libro.Autor;
                txtCategoria.Text = libro.Categoria;
                nudAnio.Value = Math.Min(nudAnio.Maximum, Math.Max(nudAnio.Minimum, libro.AnioPublicacion));
                nudEjemplares.Value = Math.Min(nudEjemplares.Maximum, Math.Max(nudEjemplares.Minimum, libro.EjemplaresTotales));
                Text = "Modificar libro";
            }
            else
            {
                Limpiar();
            }
        }
        public void Limpiar()
        {
            txtCodigo.Clear();
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtCategoria.Clear();
            nudAnio.Value = DateTime.Today.Year;
            nudEjemplares.Value = 0;
            txtCodigo.Focus();
        }
        public bool ValidarDatos()
        {
            bool datosValidos;
            datosValidos = true;
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                datosValidos = false;
                MessageBox.Show("Ingrese el código del libro.");
            }
            else if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                datosValidos = false;
                MessageBox.Show("Ingrese el título del libro.");
            }
            else if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                datosValidos = false;
                MessageBox.Show("Ingrese el autor del libro.");
            }
            else if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                datosValidos = false;
                MessageBox.Show("Ingrese la categoría del libro.");
            }
            else
            {
                datosValidos = true;
            }
            return datosValidos;
        }
        public Libro CrearObjeto()
        {
            Libro libro;
            libro = new Libro();
            libro.IdLibro = idLibro;
            libro.CodigoLibro = txtCodigo.Text.Trim();
            libro.ISBN = txtIsbn.Text.Trim();
            libro.Titulo = txtTitulo.Text.Trim();
            libro.Autor = txtAutor.Text.Trim();
            libro.Categoria = txtCategoria.Text.Trim();
            libro.AnioPublicacion = (int)nudAnio.Value;
            libro.EjemplaresTotales = (int)nudEjemplares.Value;
            libro.Activo = activo;
            return libro;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool datosValidos;
            datosValidos = ValidarDatos();
            if (datosValidos)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
