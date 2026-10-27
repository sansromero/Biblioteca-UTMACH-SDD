using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaUTMACH.Core.Entidades
{
    public class Libro
    {
        private int idLibro;
        private string codigoLibro;
        private string isbn;
        private string titulo;
        private string autor;
        private string categoria;
        private int anioPublicacion;
        private int ejemplaresTotales;
        private bool activo;

        public Libro()
        {
            codigoLibro = "";
            isbn = "";
            titulo = "";
            autor = "";
            categoria = "";
            activo = true;
        }

        public Libro(int idLibro, string codigoLibro, string isbn,
                     string titulo, string autor, string categoria,
                     int anioPublicacion, int ejemplaresTotales, bool activo)
        {
            this.idLibro = idLibro;
            this.codigoLibro = codigoLibro ?? "";
            this.isbn = isbn ?? "";
            this.titulo = titulo ?? "";
            this.autor = autor ?? "";
            this.categoria = categoria ?? "";
            this.anioPublicacion = anioPublicacion;
            this.ejemplaresTotales = ejemplaresTotales;
            this.activo = activo;
        }

        public int IdLibro { get { return idLibro; } set { idLibro = value; } }
        public string CodigoLibro { get { return codigoLibro; } set { codigoLibro = value; } }
        public string ISBN { get { return isbn; } set { isbn = value; } }
        public string Titulo { get { return titulo; } set { titulo = value; } }
        public string Autor { get { return autor; } set { autor = value; } }
        public string Categoria { get { return categoria; } set { categoria = value; } }
        public int AnioPublicacion { get { return anioPublicacion; } set { anioPublicacion = value; } }
        public int EjemplaresTotales { get { return ejemplaresTotales; } set { ejemplaresTotales = value; } }
        public bool Activo { get { return activo; } set { activo = value; } }
    }


}
