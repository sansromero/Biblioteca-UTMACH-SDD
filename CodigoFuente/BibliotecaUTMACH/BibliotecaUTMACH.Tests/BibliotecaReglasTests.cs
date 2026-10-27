using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaUTMACH.Core.Entidades;
using BibliotecaUTMACH.Core.Servicios;
using Xunit;
namespace BibliotecaUTMACH.Tests
{
    public class BibliotecaReglasTests
    {
        private Libro CrearLibro(int id, string codigo, int ejemplares)
        {
            Libro libro;
            libro = new Libro();
            libro.IdLibro = id;
            libro.CodigoLibro = codigo;
            libro.Titulo = "Libro de prueba " + id;
            libro.Autor = "Autor ficticio";
            libro.Categoria = "Académico";
            libro.AnioPublicacion = 2022;
            libro.EjemplaresTotales = ejemplares;
            libro.Activo = true;
            return libro;
        }
        private Estudiante CrearEstudiante(int id, string cedula)
        {
            Estudiante estudiante;
            estudiante = new Estudiante();
            estudiante.IdUsuario = id;
            estudiante.Cedula = cedula;
            estudiante.Nombres = "Estudiante";
            estudiante.Apellidos = "Prueba";
            estudiante.Matricula = "MAT-" + id;
            estudiante.Carrera = "Informática";
            return estudiante;
        }
        private Docente CrearDocente(int id, string cedula)
        {
            Docente docente;
            docente = new Docente();
            docente.IdUsuario = id;
            docente.Cedula = cedula;
            docente.Nombres = "Docente";
            docente.Apellidos = "Prueba";
            docente.CodigoDocente = "DOC-" + id;
            docente.Facultad = "Ingeniería";
            return docente;
        }
        [Fact]
        public void LibroValido_SeRegistra()
        {
            List<Libro> libros;
            ServicioLibros servicio;
            ResultadoOperacion resultado;
            libros = new List<Libro>();
            servicio = new ServicioLibros(libros, new List<Prestamo>());
            resultado = servicio.Agregar(CrearLibro(1,"LIB-001",3));
            Assert.True(resultado.Exito);
            Assert.Single(libros);
        }
        [Fact]
        public void CodigoDuplicado_SeRechaza()
        {
            List<Libro> libros;
            ServicioLibros servicio;
            ResultadoOperacion primero;
            ResultadoOperacion segundo;
            libros = new List<Libro>();
            servicio = new ServicioLibros(libros,new List<Prestamo>());
            primero = servicio.Agregar(CrearLibro(1,"LIB-001",1));
            segundo = servicio.Agregar(CrearLibro(2,"lib-001",1));
            Assert.True(primero.Exito);
            Assert.False(segundo.Exito);
            Assert.Single(libros);
        }
        [Fact]
        public void EjemplaresNegativos_SeRechazan()
        {
            List<Libro> libros;
            ServicioLibros servicio;
            ResultadoOperacion resultado;
            libros = new List<Libro>();
            servicio = new ServicioLibros(libros,new List<Prestamo>());
            resultado = servicio.Agregar(CrearLibro(1,"LIB-001",-1));
            Assert.False(resultado.Exito);
            Assert.Empty(libros);
        }
        [Fact]
        public void CedulaDuplicadaEntreTipos_SeRechaza()
        {
            List<Persona> usuarios;
            ServicioUsuarios servicio;
            ResultadoOperacion primero;
            ResultadoOperacion segundo;
            usuarios = new List<Persona>();
            servicio = new ServicioUsuarios(usuarios, new List<Prestamo>());
            primero = servicio.Agregar(CrearEstudiante(1,"0700000001"));
            segundo = servicio.Agregar(CrearDocente(2,"0700000001"));
            Assert.True(primero.Exito);
            Assert.False(segundo.Exito);
            Assert.Single(usuarios);
        }
        [Fact]
        public void SinEjemplares_PrestamoRechazado()
        {
            List<Libro> libros;
            List<Persona> usuarios;
            List<Prestamo> prestamos;
            ServicioPrestamos servicio;
            ResultadoOperacion resultado;
            libros = new List<Libro> { CrearLibro(1,"LIB-001",0) };
            usuarios = new List<Persona> { CrearEstudiante(1,"0700000001") };
            prestamos = new List<Prestamo>();
            servicio = new ServicioPrestamos(libros,usuarios,prestamos);
            resultado = servicio.Registrar(1,1,DateTime.Today);
            Assert.False(resultado.Exito);
            Assert.Empty(prestamos);
        }
        [Fact]
        public void EstudianteConDosPrestamos_NoPuedeTercero()
        {
            List<Libro> libros;
            List<Persona> usuarios;
            List<Prestamo> prestamos;
            ServicioPrestamos servicio;
            ResultadoOperacion primero;
            ResultadoOperacion segundo;
            ResultadoOperacion tercero;
            libros = new List<Libro> { CrearLibro(1,"LIB-001",1), CrearLibro(2,"LIB-002",1), CrearLibro(3,"LIB-003",1) };
            usuarios = new List<Persona> { CrearEstudiante(1,"0700000001") };
            prestamos = new List<Prestamo>();
            servicio = new ServicioPrestamos(libros,usuarios,prestamos);
            primero = servicio.Registrar(1,1,DateTime.Today);
            segundo = servicio.Registrar(1,2,DateTime.Today);
            tercero = servicio.Registrar(1,3,DateTime.Today);
            Assert.True(primero.Exito);
            Assert.True(segundo.Exito);
            Assert.False(tercero.Exito);
            Assert.Equal(2,prestamos.Count);
        }
        [Fact]
        public void DocenteConDosPrestamos_PuedeTercero()
        {
            List<Libro> libros;
            List<Persona> usuarios;
            List<Prestamo> prestamos;
            ServicioPrestamos servicio;
            ResultadoOperacion primero;
            ResultadoOperacion segundo;
            ResultadoOperacion tercero;
            libros = new List<Libro> { CrearLibro(1,"LIB-001",1), CrearLibro(2,"LIB-002",1), CrearLibro(3,"LIB-003",1) };
            usuarios = new List<Persona> { CrearDocente(1,"0700000001") };
            prestamos = new List<Prestamo>();
            servicio = new ServicioPrestamos(libros,usuarios,prestamos);
            primero = servicio.Registrar(1,1,DateTime.Today);
            segundo = servicio.Registrar(1,2,DateTime.Today);
            tercero = servicio.Registrar(1,3,DateTime.Today);
            Assert.True(primero.Exito);
            Assert.True(segundo.Exito);
            Assert.True(tercero.Exito);
            Assert.Equal(14,(prestamos[2].FechaVencimiento - prestamos[2].FechaPrestamo).Days);
        }
        [Fact]
        public void PrestamoDuplicadoMismoLibro_SeRechaza()
        {
            List<Libro> libros;
            List<Persona> usuarios;
            List<Prestamo> prestamos;
            ServicioPrestamos servicio;
            ResultadoOperacion primero;
            ResultadoOperacion segundo;
            libros = new List<Libro> { CrearLibro(1,"LIB-001",3) };
            usuarios = new List<Persona> { CrearEstudiante(1,"0700000001") };
            prestamos = new List<Prestamo>();
            servicio = new ServicioPrestamos(libros,usuarios,prestamos);
            primero = servicio.Registrar(1,1,DateTime.Today);
            segundo = servicio.Registrar(1,1,DateTime.Today);
            Assert.True(primero.Exito);
            Assert.False(segundo.Exito);
            Assert.Single(prestamos);
        }
        [Fact]
        public void Devolucion_RecuperaDisponibilidad()
        {
            List<Libro> libros;
            List<Persona> usuarios;
            List<Prestamo> prestamos;
            ServicioPrestamos servicioPrestamos;
            ServicioLibros servicioLibros;
            ResultadoOperacion registro;
            ResultadoOperacion devolucion;
            libros = new List<Libro> { CrearLibro(1,"LIB-001",1) };
            usuarios = new List<Persona> { CrearEstudiante(1,"0700000001") };
            prestamos = new List<Prestamo>();
            servicioPrestamos = new ServicioPrestamos(libros,usuarios,prestamos);
            servicioLibros = new ServicioLibros(libros,prestamos);
            registro = servicioPrestamos.Registrar(1,1,DateTime.Today);
            Assert.True(registro.Exito);
            Assert.Equal(0,servicioLibros.ObtenerDisponibles(libros[0]));
            devolucion = servicioPrestamos.Devolver(1,DateTime.Today);
            Assert.True(devolucion.Exito);
            Assert.Equal(1,servicioLibros.ObtenerDisponibles(libros[0]));
            Assert.Single(prestamos);
        }
        [Fact]
        public void DobleDevolucion_SeRechaza()
        {
            List<Libro> libros;
            List<Persona> usuarios;
            List<Prestamo> prestamos;
            ServicioPrestamos servicio;
            ResultadoOperacion primero;
            ResultadoOperacion segundo;
            libros = new List<Libro> { CrearLibro(1,"LIB-001",1) };
            usuarios = new List<Persona> { CrearEstudiante(1,"0700000001") };
            prestamos = new List<Prestamo>();
            servicio = new ServicioPrestamos(libros,usuarios,prestamos);
            servicio.Registrar(1,1,DateTime.Today);
            primero = servicio.Devolver(1,DateTime.Today);
            segundo = servicio.Devolver(1,DateTime.Today);
            Assert.True(primero.Exito);
            Assert.False(segundo.Exito);
        }
        [Fact]
        public void FechaVencimientoHoy_EstaActivo()
        {
            Prestamo prestamo;
            prestamo = new Prestamo { FechaPrestamo = DateTime.Today.AddDays(-7), FechaVencimiento = DateTime.Today };
            Assert.Equal("Activo",prestamo.ObtenerEstado(DateTime.Today));
            Assert.Equal("Vencido",prestamo.ObtenerEstado(DateTime.Today.AddDays(1)));
        }
        [Fact]
        public void ReducirStockPorDebajoDePrestados_SeRechaza()
        {
            List<Libro> libros;
            List<Prestamo> prestamos;
            Libro libro;
            ServicioLibros servicio;
            ResultadoOperacion resultado;
            libro = CrearLibro(1,"LIB-001",2);
            libros = new List<Libro> { libro };
            prestamos = new List<Prestamo> { new Prestamo { IdPrestamo=1,LibroPrestado=libro,FechaPrestamo=DateTime.Today } , new Prestamo { IdPrestamo=2,LibroPrestado=libro,FechaPrestamo=DateTime.Today } };
            servicio = new ServicioLibros(libros,prestamos);
            resultado = servicio.Modificar(1,CrearLibro(1,"LIB-001",1));
            Assert.False(resultado.Exito);
            Assert.Equal(2,libro.EjemplaresTotales);
        }
        [Fact]
        public void DesactivarLibro_ConservaPrestamos()
        {
            List<Libro> libros;
            List<Prestamo> prestamos;
            Libro libro;
            ServicioLibros servicio;
            ResultadoOperacion resultado;
            libro = CrearLibro(1,"LIB-001",1);
            libros = new List<Libro> { libro };
            prestamos = new List<Prestamo> { new Prestamo { IdPrestamo=1,LibroPrestado=libro,FechaPrestamo=DateTime.Today } };
            servicio = new ServicioLibros(libros,prestamos);
            resultado = servicio.Desactivar(1);
            Assert.True(resultado.Exito);
            Assert.False(libro.Activo);
            Assert.Single(prestamos);
        }
        [Fact]
        public void ReportePorTipo_CuentaCorrectamente()
        {
            List<Libro> libros;
            List<Persona> usuarios;
            List<Prestamo> prestamos;
            ServicioReportes servicio;
            List<ReporteFila> filas;
            Libro libro;
            Estudiante estudiante;
            Docente docente;
            libro = CrearLibro(1,"LIB-001",3);
            estudiante = CrearEstudiante(1,"0700000001");
            docente = CrearDocente(2,"0700000002");
            libros = new List<Libro> { libro };
            usuarios = new List<Persona> { estudiante,docente };
            prestamos = new List<Prestamo> {
                new Prestamo { IdPrestamo=1,LibroPrestado=libro,Usuario=estudiante,FechaPrestamo=DateTime.Today },
                new Prestamo { IdPrestamo=2,LibroPrestado=libro,Usuario=docente,FechaPrestamo=DateTime.Today }
            };
            servicio = new ServicioReportes(usuarios,libros,prestamos);
            filas = servicio.Generar("Préstamos por tipo de usuario",DateTime.Today,DateTime.Today,DateTime.Today);
            Assert.Equal(1,filas.Single(fila => fila.Concepto == "Estudiante").Cantidad);
            Assert.Equal(1,filas.Single(fila => fila.Concepto == "Docente").Cantidad);
        }
    }
}
