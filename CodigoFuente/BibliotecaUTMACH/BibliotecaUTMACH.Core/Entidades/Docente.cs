namespace BibliotecaUTMACH.Core.Entidades
{
    public class Docente : Persona
    {
        public string CodigoDocente { get; set; } = "";
        public string Facultad { get; set; } = "";
        public override string TipoUsuario { get { return "Docente"; } }
        public override int LimitePrestamos { get { return 3; } }
        public override int PlazoDias { get { return 14; } }
    }
}
