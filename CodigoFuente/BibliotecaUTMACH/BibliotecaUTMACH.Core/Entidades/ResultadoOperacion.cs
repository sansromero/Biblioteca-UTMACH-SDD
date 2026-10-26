namespace BibliotecaUTMACH.Core.Entidades
{
    public class ResultadoOperacion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = "";
        public static ResultadoOperacion Crear(bool exito, string mensaje)
        {
            ResultadoOperacion resultado;
            resultado = new ResultadoOperacion();
            resultado.Exito = exito;
            resultado.Mensaje = mensaje ?? "";
            return resultado;
        }
    }
}
