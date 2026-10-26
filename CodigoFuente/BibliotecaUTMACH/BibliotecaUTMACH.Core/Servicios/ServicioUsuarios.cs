using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaUTMACH.Core.Entidades;
namespace BibliotecaUTMACH.Core.Servicios
{
    public class ServicioUsuarios
    {
        private readonly List<Persona> listaUsuarios;
        private readonly List<Prestamo> listaPrestamos;
        public ServicioUsuarios(List<Persona> usuarios, List<Prestamo> prestamos)
        {
            listaUsuarios = usuarios ?? new List<Persona>();
            listaPrestamos = prestamos ?? new List<Prestamo>();
        }
        public Persona BuscarPorId(int idUsuario)
        {
            Persona persona;
            persona = listaUsuarios.FirstOrDefault(actual => actual != null && actual.IdUsuario == idUsuario);
            return persona;
        }
        public int SiguienteId()
        {
            int id;
            id = listaUsuarios.Where(usuario => usuario != null).Select(usuario => usuario.IdUsuario).DefaultIfEmpty(0).Max() + 1;
            return id;
        }
        private string ValidarPersona(Persona persona, int idAnterior)
        {
            string error;
            string cedula;
            bool cedulaRepetida;
            bool codigoRepetido;
            Estudiante estudiante;
            Docente docente;
            error = "";
            cedula = "";
            cedulaRepetida = false;
            codigoRepetido = false;
            estudiante = null;
            docente = null;
            if (persona == null)
            {
                error = "No se recibió un usuario válido.";
            }
            else
            {
                cedula = (persona.Cedula ?? "").Trim();
                cedulaRepetida = listaUsuarios.Any(usuario => usuario != null && usuario.IdUsuario != idAnterior && usuario.Cedula == cedula);
                if (persona is Estudiante)
                {
                    estudiante = (Estudiante)persona;
                    codigoRepetido = listaUsuarios.OfType<Estudiante>().Any(usuario => usuario.IdUsuario != idAnterior && string.Equals(usuario.Matricula, estudiante.Matricula, StringComparison.OrdinalIgnoreCase));
                    if (string.IsNullOrWhiteSpace(estudiante.Matricula) || string.IsNullOrWhiteSpace(estudiante.Carrera))
                    {
                        error = "Matrícula y carrera son obligatorias.";
                    }
                    else
                    {
                        // Datos específicos correctos.
                    }
                }
                else if (persona is Docente)
                {
                    docente = (Docente)persona;
                    codigoRepetido = listaUsuarios.OfType<Docente>().Any(usuario => usuario.IdUsuario != idAnterior && string.Equals(usuario.CodigoDocente, docente.CodigoDocente, StringComparison.OrdinalIgnoreCase));
                    if (string.IsNullOrWhiteSpace(docente.CodigoDocente) || string.IsNullOrWhiteSpace(docente.Facultad))
                    {
                        error = "Código docente y facultad son obligatorios.";
                    }
                    else
                    {
                        // Datos específicos correctos.
                    }
                }
                else
                {
                    error = "El tipo de usuario no es válido.";
                }
                if (persona.IdUsuario <= 0 || cedula.Length != 10 || !cedula.All(char.IsDigit))
                {
                    error = "La cédula debe tener exactamente 10 dígitos y el ID debe ser positivo.";
                }
                else if (string.IsNullOrWhiteSpace(persona.Nombres) || string.IsNullOrWhiteSpace(persona.Apellidos))
                {
                    error = "Nombres y apellidos son obligatorios.";
                }
                else if (!string.IsNullOrWhiteSpace(persona.Correo) && (!persona.Correo.Contains('@') || !persona.Correo.Contains('.')))
                {
                    error = "El correo no tiene un formato válido.";
                }
                else if (cedulaRepetida || codigoRepetido || listaUsuarios.Any(usuario => usuario != null && usuario.IdUsuario == persona.IdUsuario && usuario.IdUsuario != idAnterior))
                {
                    error = "La cédula, matrícula, código o identificador está repetido.";
                }
                else
                {
                    // Se conserva cualquier error detectado en datos específicos.
                }
            }
            return error;
        }
        public ResultadoOperacion Agregar(Persona persona)
        {
            ResultadoOperacion resultado;
            string error;
            error = ValidarPersona(persona, 0);
            if (string.IsNullOrWhiteSpace(error))
            {
                listaUsuarios.Add(persona);
                resultado = ResultadoOperacion.Crear(true, "Usuario registrado correctamente.");
            }
            else
            {
                resultado = ResultadoOperacion.Crear(false, error);
            }
            return resultado;
        }
        public ResultadoOperacion Modificar(int idUsuario, Persona datos)
        {
            ResultadoOperacion resultado;
            Persona original;
            string error;
            bool tieneHistorial;
            int indice;
            indice = -1;
            original = BuscarPorId(idUsuario);
            error = "";
            tieneHistorial = listaPrestamos.Any(prestamo => prestamo != null && prestamo.Usuario != null && prestamo.Usuario.IdUsuario == idUsuario);
            if (original == null || datos == null)
            {
                resultado = ResultadoOperacion.Crear(false, "No se encontró el usuario.");
            }
            else if (original.TipoUsuario != datos.TipoUsuario && tieneHistorial)
            {
                resultado = ResultadoOperacion.Crear(false, "No se puede cambiar el tipo de un usuario con historial de préstamos.");
            }
            else
            {
                datos.IdUsuario = idUsuario;
                error = ValidarPersona(datos, idUsuario);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    resultado = ResultadoOperacion.Crear(false, error);
                }
                else
                {
                    // Si cambió de tipo sin historial, se reemplaza en la lista.
                    if (original.TipoUsuario != datos.TipoUsuario)
                    {
                        indice = listaUsuarios.IndexOf(original);
                        listaUsuarios[indice] = datos;
                    }
                    else
                    {
                        original.Cedula = datos.Cedula;
                        original.Nombres = datos.Nombres;
                        original.Apellidos = datos.Apellidos;
                        original.Correo = datos.Correo;
                        if (original is Estudiante && datos is Estudiante)
                        {
                            ((Estudiante)original).Matricula = ((Estudiante)datos).Matricula;
                            ((Estudiante)original).Carrera = ((Estudiante)datos).Carrera;
                        }
                        else if (original is Docente && datos is Docente)
                        {
                            ((Docente)original).CodigoDocente = ((Docente)datos).CodigoDocente;
                            ((Docente)original).Facultad = ((Docente)datos).Facultad;
                        }
                        else
                        {
                            // No hay otros tipos admitidos.
                        }
                    }
                    resultado = ResultadoOperacion.Crear(true, "Usuario modificado correctamente.");
                }
            }
            return resultado;
        }
        public ResultadoOperacion Desactivar(int idUsuario)
        {
            ResultadoOperacion resultado;
            Persona usuario;
            usuario = BuscarPorId(idUsuario);
            if (usuario != null && usuario.Activo)
            {
                usuario.Activo = false;
                resultado = ResultadoOperacion.Crear(true, "Usuario desactivado; se mantiene el historial.");
            }
            else
            {
                resultado = ResultadoOperacion.Crear(false, "Usuario no encontrado o inactivo.");
            }
            return resultado;
        }
        private string ObtenerCodigo(Persona persona)
        {
            string codigo;
            codigo = "";
            if (persona is Estudiante)
            {
                codigo = ((Estudiante)persona).Matricula;
            }
            else if (persona is Docente)
            {
                codigo = ((Docente)persona).CodigoDocente;
            }
            else
            {
                codigo = "";
            }
            return codigo;
        }
        private string ObtenerCarreraFacultad(Persona persona)
        {
            string lugar;
            lugar = "";
            if (persona is Estudiante)
            {
                lugar = ((Estudiante)persona).Carrera;
            }
            else if (persona is Docente)
            {
                lugar = ((Docente)persona).Facultad;
            }
            else
            {
                lugar = "";
            }
            return lugar;
        }
        public List<UsuarioVista> Listar(string busqueda, string tipo)
        {
            List<UsuarioVista> resultados;
            IEnumerable<Persona> consulta;
            string texto;
            texto = (busqueda ?? "").Trim();
            consulta = listaUsuarios.Where(persona => persona != null);
            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(persona => (persona.Cedula ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) || persona.NombreCompleto.Contains(texto, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                // Sin filtro de texto.
            }
            if (tipo == "Estudiantes" || tipo == "Docentes")
            {
                string tipoReal;
                if (tipo == "Estudiantes")
                {
                    tipoReal = "Estudiante";
                }
                else
                {
                    tipoReal = "Docente";
                }
                consulta = consulta.Where(persona => persona.TipoUsuario == tipoReal);
            }
            else
            {
                // Incluye ambos tipos.
            }
            resultados = consulta.OrderBy(persona => persona.Nombres).Select(persona => new UsuarioVista
            {
                IdUsuario = persona.IdUsuario, Cedula = persona.Cedula, Nombres = persona.Nombres,
                Apellidos = persona.Apellidos, Tipo = persona.TipoUsuario, Activo = persona.Activo,
                Codigo = ObtenerCodigo(persona),
                CarreraFacultad = ObtenerCarreraFacultad(persona)
            }).ToList();
            return resultados;
        }
    }
}
