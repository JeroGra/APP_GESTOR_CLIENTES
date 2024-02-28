namespace API_GESTOR_CLIENTES.Modelos
{
    public class Usuario
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }  
        public int dni {  get; set; }
        public string correo { get; set; }

    }
}
