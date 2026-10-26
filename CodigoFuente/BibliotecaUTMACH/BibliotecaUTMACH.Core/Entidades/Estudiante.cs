namespace BibliotecaUTMACH.Core.Entidades
{
    public class Estudiante : Persona
    {
        public string Matricula { get; set; } = "";
        public string Carrera { get; set; } = "";
        public override string TipoUsuario { get { return "Estudiante"; } }
        public override int LimitePrestamos { get { return 2; } }
        public override int PlazoDias { get { return 7; } }
    }
}
