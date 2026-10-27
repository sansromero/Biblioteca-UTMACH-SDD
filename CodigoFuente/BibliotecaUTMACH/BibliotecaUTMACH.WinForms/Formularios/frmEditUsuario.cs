using System;
using System.Windows.Forms;
using BibliotecaUTMACH.Core.Entidades;
namespace BibliotecaUTMACH.WinForms.Formularios
{
    public partial class frmEditUsuario : Form
    {
        private int idUsuario;
        private bool activo;
        public frmEditUsuario()
        {
            InitializeComponent();
            idUsuario = 0;
            activo = true;
            cboTipoUsuario.Items.AddRange(new object[] { "Estudiante", "Docente" });
            cboTipoUsuario.SelectedIndexChanged += cboTipoUsuario_SelectedIndexChanged;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
            cboTipoUsuario.SelectedIndex = 0;
        }
        public void PrepararNuevo(int nuevoId)
        {
            idUsuario = nuevoId;
            activo = true;
            Limpiar();
            Text = "Insertar usuario";
        }
        public void setDatos(Persona usuario)
        {
            bool usuarioValido;
            Estudiante estudiante;
            Docente docente;
            estudiante = null;
            docente = null;
            usuarioValido = usuario != null;
            if (usuarioValido)
            {
                idUsuario = usuario.IdUsuario;
                activo = usuario.Activo;
                txtCedula.Text = usuario.Cedula;
                txtNombres.Text = usuario.Nombres;
                txtApellidos.Text = usuario.Apellidos;
                txtCorreo.Text = usuario.Correo;
                cboTipoUsuario.SelectedItem = usuario.TipoUsuario;
                if (usuario is Estudiante)
                {
                    estudiante = (Estudiante)usuario;
                    txtDatoEspecifico1.Text = estudiante.Matricula;
                    txtDatoEspecifico2.Text = estudiante.Carrera;
                }
                else if (usuario is Docente)
                {
                    docente = (Docente)usuario;
                    txtDatoEspecifico1.Text = docente.CodigoDocente;
                    txtDatoEspecifico2.Text = docente.Facultad;
                }
                Text = "Modificar usuario";
            }
            else
            {
                Limpiar();
            }
        }
        private void cboTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo;
            if (cboTipoUsuario.SelectedItem != null)
            {
                tipo = cboTipoUsuario.SelectedItem.ToString();
            }
            else
            {
                tipo = "";
            }
            if (tipo == "Estudiante")
            {
                lblDato1.Text = "Matrícula:";
                lblDato2.Text = "Carrera:";
            }
            else
            {
                lblDato1.Text = "Código docente:";
                lblDato2.Text = "Facultad:";
            }
            txtDatoEspecifico1.Clear();
            txtDatoEspecifico2.Clear();
        }
        public void Limpiar()
        {
            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCorreo.Clear();
            cboTipoUsuario.SelectedIndex = 0;
            txtDatoEspecifico1.Clear();
            txtDatoEspecifico2.Clear();
            txtCedula.Focus();
        }
        public bool ValidarDatos()
        {
            bool valido;
            valido = true;
            if (txtCedula.Text.Trim().Length != 10 || !txtCedula.Text.Trim().All(char.IsDigit))
            {
                valido = false;
                MessageBox.Show("La cédula debe tener 10 dígitos.");
            }
            else if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                valido = false;
                MessageBox.Show("Nombres y apellidos son obligatorios.");
            }
            else if (string.IsNullOrWhiteSpace(txtDatoEspecifico1.Text) || string.IsNullOrWhiteSpace(txtDatoEspecifico2.Text))
            {
                valido = false;
                MessageBox.Show("Complete matrícula/código y carrera/facultad.");
            }
            else
            {
                valido = true;
            }
            return valido;
        }
        public Persona CrearObjeto()
        {
            Persona persona;
            Estudiante estudiante;
            Docente docente;
            string tipo;

            persona = null;
            estudiante = null;
            docente = null;
            tipo = "";

            if (cboTipoUsuario.SelectedItem != null)
            {
                tipo = cboTipoUsuario.SelectedItem.ToString() ?? "";
            }
            else
            {
                tipo = "";
            }

            if (tipo == "Estudiante")
            {
                estudiante = new Estudiante();

                estudiante.Matricula =
                    txtDatoEspecifico1.Text.Trim();

                estudiante.Carrera =
                    txtDatoEspecifico2.Text.Trim();

                persona = estudiante;
            }
            else
            {
                if (tipo == "Docente")
                {
                    docente = new Docente();

                    docente.CodigoDocente =
                        txtDatoEspecifico1.Text.Trim();

                    docente.Facultad =
                        txtDatoEspecifico2.Text.Trim();

                    persona = docente;
                }
                else
                {
                    persona = null;
                }
            }

            if (persona != null)
            {
                persona.IdUsuario = idUsuario;
                persona.Cedula = txtCedula.Text.Trim();
                persona.Nombres = txtNombres.Text.Trim();
                persona.Apellidos = txtApellidos.Text.Trim();
                persona.Correo = txtCorreo.Text.Trim();
                persona.Activo = activo;
            }

            return persona;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool valido;
            valido = ValidarDatos();
            if (valido)
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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
