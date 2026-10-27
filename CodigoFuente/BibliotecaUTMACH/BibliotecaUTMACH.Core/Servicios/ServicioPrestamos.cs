using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaUTMACH.Core.Entidades;
namespace BibliotecaUTMACH.Core.Servicios
{
    public class ServicioPrestamos
    {
        private readonly List<Libro> listaLibros;
        private readonly List<Persona> listaUsuarios;
        private readonly List<Prestamo> listaPrestamos;
        public ServicioPrestamos(List<Libro> libros, List<Persona> usuarios, List<Prestamo> prestamos)
        {
            listaLibros = libros ?? new List<Libro>();
            listaUsuarios = usuarios ?? new List<Persona>();
            listaPrestamos = prestamos ?? new List<Prestamo>();
        }
        public Prestamo BuscarPorId(int idPrestamo)
        {
            Prestamo prestamo;
            prestamo = listaPrestamos.FirstOrDefault(actual => actual != null && actual.IdPrestamo == idPrestamo);
            return prestamo;
        }
        public ResultadoOperacion Registrar(int idUsuario, int idLibro, DateTime fechaPrestamo)
        {
            ResultadoOperacion resultado;
            Persona usuario;
            Libro libro;
            int noDevueltosUsuario;
            int noDevueltosLibro;
            int siguienteId;
            bool duplicado;
            bool vencido;
            Prestamo prestamo;
            usuario = listaUsuarios.FirstOrDefault(actual => actual != null && actual.IdUsuario == idUsuario);
            libro = listaLibros.FirstOrDefault(actual => actual != null && actual.IdLibro == idLibro);
            noDevueltosUsuario = listaPrestamos.Count(actual => actual != null && actual.Usuario != null && actual.Usuario.IdUsuario == idUsuario && !actual.FechaDevolucion.HasValue);
            noDevueltosLibro = listaPrestamos.Count(actual => actual != null && actual.LibroPrestado != null && actual.LibroPrestado.IdLibro == idLibro && !actual.FechaDevolucion.HasValue);
            duplicado = listaPrestamos.Any(actual => actual != null && actual.Usuario != null && actual.LibroPrestado != null && actual.Usuario.IdUsuario == idUsuario && actual.LibroPrestado.IdLibro == idLibro && !actual.FechaDevolucion.HasValue);
            vencido = listaPrestamos.Any(actual => actual != null && actual.Usuario != null && actual.Usuario.IdUsuario == idUsuario && !actual.FechaDevolucion.HasValue && actual.FechaVencimiento.Date < fechaPrestamo.Date);
            siguienteId = listaPrestamos.Where(actual => actual != null).Select(actual => actual.IdPrestamo).DefaultIfEmpty(0).Max() + 1;
            prestamo = null;
            if (usuario == null || libro == null)
            {
                resultado = ResultadoOperacion.Crear(false, "Seleccione un usuario y libro registrados.");
            }
            else if (!usuario.Activo || !libro.Activo)
            {
                resultado = ResultadoOperacion.Crear(false, "El usuario o el libro están inactivos.");
            }
            else if (fechaPrestamo.Date > DateTime.Today)
            {
                resultado = ResultadoOperacion.Crear(false, "No registre préstamos con fecha futura.");
            }
            else if (libro.EjemplaresTotales <= noDevueltosLibro)
            {
                resultado = ResultadoOperacion.Crear(false, "No hay ejemplares disponibles.");
            }
            else if (noDevueltosUsuario >= usuario.LimitePrestamos)
            {
                resultado = ResultadoOperacion.Crear(false, "El usuario alcanzó su límite de préstamos.");
            }
            else if (duplicado)
            {
                resultado = ResultadoOperacion.Crear(false, "El usuario ya tiene este libro sin devolver.");
            }
            else if (vencido)
            {
                resultado = ResultadoOperacion.Crear(false, "El usuario tiene préstamos vencidos sin devolver.");
            }
            else
            {
                prestamo = new Prestamo();
                prestamo.IdPrestamo = siguienteId;
                prestamo.Usuario = usuario;
                prestamo.LibroPrestado = libro;
                prestamo.FechaPrestamo = fechaPrestamo.Date;
                prestamo.FechaVencimiento = fechaPrestamo.Date.AddDays(usuario.PlazoDias);
                prestamo.FechaDevolucion = null;
                listaPrestamos.Add(prestamo);
                resultado = ResultadoOperacion.Crear(true, "Préstamo registrado. Vence: " + prestamo.FechaVencimiento.ToShortDateString());
            }
            return resultado;
        }
        public ResultadoOperacion Devolver(int idPrestamo, DateTime fechaDevolucion)
        {
            ResultadoOperacion resultado;
            Prestamo prestamo;
            prestamo = BuscarPorId(idPrestamo);
            if (prestamo == null)
            {
                resultado = ResultadoOperacion.Crear(false, "No se encontró el préstamo.");
            }
            else if (prestamo.FechaDevolucion.HasValue)
            {
                resultado = ResultadoOperacion.Crear(false, "Este préstamo ya fue devuelto.");
            }
            else if (fechaDevolucion.Date < prestamo.FechaPrestamo.Date || fechaDevolucion.Date > DateTime.Today)
            {
                resultado = ResultadoOperacion.Crear(false, "La fecha de devolución no es válida.");
            }
            else
            {
                prestamo.FechaDevolucion = fechaDevolucion.Date;
                resultado = ResultadoOperacion.Crear(true, "Devolución registrada correctamente.");
            }
            return resultado;
        }
        public List<PrestamoVista> Listar(string estado, DateTime fechaConsulta)
        {
            List<PrestamoVista> resultados;
            IEnumerable<Prestamo> consulta;
            consulta = listaPrestamos.Where(actual => actual != null && actual.Usuario != null && actual.LibroPrestado != null);
            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                consulta = consulta.Where(actual => actual.ObtenerEstado(fechaConsulta) == estado);
            }
            else
            {
                // Todos los registros.
            }
            resultados = consulta.OrderByDescending(actual => actual.FechaPrestamo).Select(actual => new PrestamoVista
            {
                IdPrestamo = actual.IdPrestamo, Usuario = actual.Usuario.NombreCompleto, Tipo = actual.Usuario.TipoUsuario,
                Libro = actual.LibroPrestado.Titulo, FechaPrestamo = actual.FechaPrestamo,
                FechaVencimiento = actual.FechaVencimiento, FechaDevolucion = actual.FechaDevolucion,
                Estado = actual.ObtenerEstado(fechaConsulta)
            }).ToList();
            return resultados;
        }
    }
}
