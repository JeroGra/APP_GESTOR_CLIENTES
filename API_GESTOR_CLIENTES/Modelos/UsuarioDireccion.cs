namespace API_GESTOR_CLIENTES.Modelos
{
    public class UsuarioDireccion
    {
        public int idUs { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public DateTime fechaNacimiento { get; set; }
        public int dni { get; set; }
        public string correo { get; set; } = string.Empty;
        public int idDir { get; set; }
        public string provincia { get; set; } = string.Empty;
        public string localidad { get; set; } = string.Empty;
        public string calle { get; set; } = string.Empty;
        public int numero { get; set; }
        public int codigoPostal { get; set; }
        public Int64 numeroTelefono { get; set; }
    }
}
