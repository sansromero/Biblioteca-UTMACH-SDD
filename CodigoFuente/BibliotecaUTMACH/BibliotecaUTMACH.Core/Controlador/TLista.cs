using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaUTMACH.Core.Entidades;

namespace BibliotecaUTMACH.Core.Controlador
{
    public class TLista
    {
        // En los siguientes módulos se agregarán listaUsuarios y listaPrestamos.
        public static List<Libro> listaLibros = new List<Libro>();
        public static List<Persona> listaUsuarios = new List<Persona>();
        public static List<Prestamo> listaPrestamos = new List<Prestamo>();
    }

}
