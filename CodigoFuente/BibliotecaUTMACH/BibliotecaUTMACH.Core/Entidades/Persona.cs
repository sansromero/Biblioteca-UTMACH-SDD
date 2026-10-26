namespace BibliotecaUTMACH.Core.Entidades
{
    public abstract class Persona
    {
        public int IdUsuario { get; set; }
        public string Cedula { get; set; } = "";
        public string Nombres { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string Correo { get; set; } = "";
        public bool Activo { get; set; } = true;
        public string NombreCompleto { get { return (Nombres + " " + Apellidos).Trim(); } }
        public abstract string TipoUsuario { get; }
        public abstract int LimitePrestamos { get; }
        public abstract int PlazoDias { get; }
    }
}
