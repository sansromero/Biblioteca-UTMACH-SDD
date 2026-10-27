using System;
namespace BibliotecaUTMACH.Core.Entidades
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public Persona Usuario { get; set; }
        public Libro LibroPrestado { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string ObtenerEstado(DateTime fechaConsulta)
        {
            string estado;
            estado = "Activo";
            if (FechaDevolucion.HasValue)
            {
                estado = "Devuelto";
            }
            else
            {
                if (FechaVencimiento.Date < fechaConsulta.Date)
                {
                    estado = "Vencido";
                }
                else
                {
                    estado = "Activo";
                }
            }
            return estado;
        }
    }
}
