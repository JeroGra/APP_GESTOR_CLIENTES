namespace API_GESTOR_CLIENTES.Modelos
{
    public class Respuesta
    {
        public bool ok { get; set; } = true;

        public string data { get; set; } = string.Empty;

        public string mensaje { get; set; } = string.Empty;

        public string error { get; set;} = string.Empty;

        public int id { get; set; }


    }
}
