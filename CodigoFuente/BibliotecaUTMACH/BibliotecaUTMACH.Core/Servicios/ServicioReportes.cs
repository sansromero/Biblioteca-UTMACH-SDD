using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaUTMACH.Core.Entidades;
namespace BibliotecaUTMACH.Core.Servicios
{
    public class ServicioReportes
    {
        private readonly List<Persona> usuarios;
        private readonly List<Libro> libros;
        private readonly List<Prestamo> prestamos;
        public ServicioReportes(List<Persona> listaUsuarios, List<Libro> listaLibros, List<Prestamo> listaPrestamos)
        {
            usuarios = listaUsuarios ?? new List<Persona>();
            libros = listaLibros ?? new List<Libro>();
            prestamos = listaPrestamos ?? new List<Prestamo>();
        }
        private string ObtenerEstadoLibro(Libro libro)
        {
            string estado;
            estado = "Inactivo";
            if (libro != null && libro.Activo)
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }
            return estado;
        }
        public List<ReporteFila> Generar(string tipo, DateTime desde, DateTime hasta, DateTime hoy)
        {
            List<ReporteFila> filas;
            IEnumerable<Prestamo> consultaPeriodo;
            ServicioLibros servicioLibros;
            int cantidad;
            filas = new List<ReporteFila>();
            servicioLibros = new ServicioLibros(libros, prestamos);
            consultaPeriodo = prestamos.Where(prestamo => prestamo != null && prestamo.Usuario != null && prestamo.LibroPrestado != null && prestamo.FechaPrestamo.Date >= desde.Date && prestamo.FechaPrestamo.Date <= hasta.Date);
            cantidad = 0;
            if (tipo == "Disponibilidad de libros")
            {
                filas = libros.Where(libro => libro != null).Select(libro => new ReporteFila
                {
                    Concepto = libro.CodigoLibro + " - " + libro.Titulo,
                    Detalle = ObtenerEstadoLibro(libro),
                    Cantidad = servicioLibros.ObtenerDisponibles(libro)
                }).ToList();
            }
            else if (tipo == "Préstamos activos")
            {
                filas = consultaPeriodo.Where(prestamo => prestamo.ObtenerEstado(hoy) == "Activo").Select(prestamo => new ReporteFila
                {
                    Concepto = prestamo.Usuario.NombreCompleto,
                    Detalle = prestamo.LibroPrestado.Titulo + " / Vence " + prestamo.FechaVencimiento.ToShortDateString(),
                    Cantidad = 1
                }).ToList();
            }
            else if (tipo == "Préstamos vencidos")
            {
                filas = consultaPeriodo.Where(prestamo => prestamo.ObtenerEstado(hoy) == "Vencido").Select(prestamo => new ReporteFila
                {
                    Concepto = prestamo.Usuario.NombreCompleto,
                    Detalle = prestamo.LibroPrestado.Titulo + " / Venció " + prestamo.FechaVencimiento.ToShortDateString(),
                    Cantidad = 1
                }).ToList();
            }
            else if (tipo == "Préstamos por tipo de usuario")
            {
                filas = consultaPeriodo.GroupBy(prestamo => prestamo.Usuario.TipoUsuario).Select(grupo => new ReporteFila
                {
                    Concepto = grupo.Key, Detalle = "Préstamos del período", Cantidad = grupo.Count()
                }).ToList();
                if (!filas.Any(fila => fila.Concepto == "Estudiante"))
                {
                    filas.Add(new ReporteFila { Concepto = "Estudiante", Detalle = "Préstamos del período", Cantidad = 0 });
                }
                else
                {
                    // Ya existe la categoría Estudiante.
                }
                if (!filas.Any(fila => fila.Concepto == "Docente"))
                {
                    filas.Add(new ReporteFila { Concepto = "Docente", Detalle = "Préstamos del período", Cantidad = 0 });
                }
                else
                {
                    // Ya existe la categoría Docente.
                }
            }
            else
            {
                cantidad = libros.Where(libro => libro != null && libro.Activo).Sum(libro => servicioLibros.ObtenerDisponibles(libro));
                filas.Add(new ReporteFila { Concepto = "Usuarios activos", Detalle = "Estudiantes y docentes", Cantidad = usuarios.Count(usuario => usuario != null && usuario.Activo) });
                filas.Add(new ReporteFila { Concepto = "Títulos activos", Detalle = "Libros habilitados", Cantidad = libros.Count(libro => libro != null && libro.Activo) });
                filas.Add(new ReporteFila { Concepto = "Ejemplares disponibles", Detalle = "En libros activos", Cantidad = cantidad });
                filas.Add(new ReporteFila { Concepto = "Préstamos no devueltos", Detalle = "Activos y vencidos", Cantidad = prestamos.Count(prestamo => prestamo != null && !prestamo.FechaDevolucion.HasValue) });
            }
            return filas;
        }
    }
}
