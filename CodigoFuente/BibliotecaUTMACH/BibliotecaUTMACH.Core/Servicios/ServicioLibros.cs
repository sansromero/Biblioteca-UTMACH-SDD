using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaUTMACH.Core.Entidades;
namespace BibliotecaUTMACH.Core.Servicios
{
    public class ServicioLibros
    {
        private readonly List<Libro> listaLibros;
        private readonly List<Prestamo> listaPrestamos;

        public ServicioLibros(List<Libro> libros, List<Prestamo> prestamos)
        {
            listaLibros = libros ?? new List<Libro>();
            listaPrestamos = prestamos ?? new List<Prestamo>();
        }

        public Libro BuscarPorId(int idLibro)
        {
            Libro libro;
            libro = listaLibros.FirstOrDefault(actual => actual != null && actual.IdLibro == idLibro);
            return libro;
        }

        public int SiguienteId()
        {
            int siguienteId;
            siguienteId = listaLibros.Where(libro => libro != null).Select(libro => libro.IdLibro).DefaultIfEmpty(0).Max() + 1;
            return siguienteId;
        }

        public int ContarNoDevueltos(int idLibro)
        {
            int cantidad;
            cantidad = listaPrestamos.Count(prestamo => prestamo != null && prestamo.LibroPrestado != null && prestamo.LibroPrestado.IdLibro == idLibro && !prestamo.FechaDevolucion.HasValue);
            return cantidad;
        }

        public int ObtenerDisponibles(Libro libro)
        {
            int disponibles;
            disponibles = 0;
            if (libro != null)
            {
                disponibles = libro.EjemplaresTotales - ContarNoDevueltos(libro.IdLibro);
            }
            else
            {
                disponibles = 0;
            }
            return disponibles;
        }

        private string ValidarLibro(Libro libro, int idActual)
        {
            string error;
            bool codigoDuplicado;
            bool idDuplicado;
            int prestados;
            int idParaContar;
            error = "";
            codigoDuplicado = false;
            idDuplicado = false;
            prestados = 0;
            idParaContar = 0;
            if (libro == null)
            {
                error = "No se recibió un libro válido.";
            }
            else
            {
                codigoDuplicado = listaLibros.Any(actual => actual != null && actual.IdLibro != idActual && string.Equals(actual.CodigoLibro, (libro.CodigoLibro ?? "").Trim(), StringComparison.OrdinalIgnoreCase));
                idDuplicado = listaLibros.Any(actual => actual != null && actual.IdLibro == libro.IdLibro && actual.IdLibro != idActual);
                if (idActual == 0)
                {
                    idParaContar = libro.IdLibro;
                }
                else
                {
                    idParaContar = idActual;
                }
                prestados = ContarNoDevueltos(idParaContar);
                if (libro.IdLibro <= 0)
                {
                    error = "El identificador del libro no es válido.";
                }
                else if (string.IsNullOrWhiteSpace(libro.CodigoLibro) || string.IsNullOrWhiteSpace(libro.Titulo) || string.IsNullOrWhiteSpace(libro.Autor) || string.IsNullOrWhiteSpace(libro.Categoria))
                {
                    error = "Código, título, autor y categoría son obligatorios.";
                }
                else if (libro.AnioPublicacion < 1 || libro.AnioPublicacion > DateTime.Today.Year)
                {
                    error = "El año de publicación no es válido.";
                }
                else if (libro.EjemplaresTotales < 0 || libro.EjemplaresTotales < prestados)
                {
                    error = "Los ejemplares no pueden ser negativos ni menores que los préstamos sin devolver.";
                }
                else if (codigoDuplicado || idDuplicado)
                {
                    error = "El código o identificador del libro ya está registrado.";
                }
                else
                {
                    error = "";
                }
            }
            return error;
        }

        public ResultadoOperacion Agregar(Libro libro)
        {
            ResultadoOperacion resultado;
            string error;
            error = ValidarLibro(libro, 0);
            if (string.IsNullOrEmpty(error))
            {
                listaLibros.Add(libro);
                resultado = ResultadoOperacion.Crear(true, "Libro agregado correctamente.");
            }
            else
            {
                resultado = ResultadoOperacion.Crear(false, error);
            }
            return resultado;
        }

        public ResultadoOperacion Modificar(int idLibro, Libro nuevosDatos)
        {
            ResultadoOperacion resultado;
            Libro original;
            string error;
            original = BuscarPorId(idLibro);
            error = "";
            if (original == null || nuevosDatos == null)
            {
                resultado = ResultadoOperacion.Crear(false, "No se encontró el libro a modificar.");
            }
            else
            {
                nuevosDatos.IdLibro = idLibro;
                error = ValidarLibro(nuevosDatos, idLibro);
                if (string.IsNullOrEmpty(error))
                {
                    original.CodigoLibro = nuevosDatos.CodigoLibro.Trim();
                    original.ISBN = (nuevosDatos.ISBN ?? "").Trim();
                    original.Titulo = nuevosDatos.Titulo.Trim();
                    original.Autor = nuevosDatos.Autor.Trim();
                    original.Categoria = nuevosDatos.Categoria.Trim();
                    original.AnioPublicacion = nuevosDatos.AnioPublicacion;
                    original.EjemplaresTotales = nuevosDatos.EjemplaresTotales;
                    resultado = ResultadoOperacion.Crear(true, "Libro modificado correctamente.");
                }
                else
                {
                    resultado = ResultadoOperacion.Crear(false, error);
                }
            }
            return resultado;
        }

        public ResultadoOperacion Desactivar(int idLibro)
        {
            ResultadoOperacion resultado;
            Libro libro;
            libro = BuscarPorId(idLibro);
            if (libro != null && libro.Activo)
            {
                libro.Activo = false;
                resultado = ResultadoOperacion.Crear(true, "Libro desactivado. Su historial se conserva.");
            }
            else
            {
                resultado = ResultadoOperacion.Crear(false, "El libro no existe o ya está inactivo.");
            }
            return resultado;
        }

        public List<LibroVista> Listar(string texto, string filtro)
        {
            List<LibroVista> resultados;
            IEnumerable<Libro> consulta;
            string busqueda;
            busqueda = (texto ?? "").Trim();
            consulta = listaLibros.Where(libro => libro != null);
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                consulta = consulta.Where(libro => (libro.CodigoLibro ?? "").Contains(busqueda, StringComparison.OrdinalIgnoreCase) || (libro.Titulo ?? "").Contains(busqueda, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                // Se muestran todos los textos.
            }
            if (filtro == "Disponibles")
            {
                consulta = consulta.Where(libro => libro.Activo && ObtenerDisponibles(libro) > 0);
            }
            else if (filtro == "Agotados")
            {
                consulta = consulta.Where(libro => libro.Activo && ObtenerDisponibles(libro) == 0);
            }
            else
            {
                // El filtro Todos incluye libros activos e inactivos.
            }
            resultados = consulta.OrderBy(libro => libro.CodigoLibro).Select(libro => new LibroVista
            {
                IdLibro = libro.IdLibro,
                Codigo = libro.CodigoLibro,
                ISBN = libro.ISBN,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                Categoria = libro.Categoria,
                Año = libro.AnioPublicacion,
                Totales = libro.EjemplaresTotales,
                Disponibles = ObtenerDisponibles(libro),
                Activo = libro.Activo
            }).ToList();
            return resultados;
        }
    }
}
