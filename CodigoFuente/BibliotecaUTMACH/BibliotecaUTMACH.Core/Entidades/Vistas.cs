using System;
namespace BibliotecaUTMACH.Core.Entidades
{
    public class LibroVista
    {
        public int IdLibro { get; set; }
        public string Codigo { get; set; } = "";
        public string ISBN { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string Autor { get; set; } = "";
        public string Categoria { get; set; } = "";
        public int Año { get; set; }
        public int Totales { get; set; }
        public int Disponibles { get; set; }
        public bool Activo { get; set; }
    }
    public class UsuarioVista
    {
        public int IdUsuario { get; set; }
        public string Cedula { get; set; } = "";
        public string Nombres { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string Tipo { get; set; } = "";
        public string Codigo { get; set; } = "";
        public string CarreraFacultad { get; set; } = "";
        public bool Activo { get; set; }
    }
    public class PrestamoVista
    {
        public int IdPrestamo { get; set; }
        public string Usuario { get; set; } = "";
        public string Tipo { get; set; } = "";
        public string Libro { get; set; } = "";
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } = "";
    }
    public class ReporteFila
    {
        public string Concepto { get; set; } = "";
        public string Detalle { get; set; } = "";
        public int Cantidad { get; set; }
    }
}
