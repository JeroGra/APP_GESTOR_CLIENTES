namespace API_GESTOR_CLIENTES.Modelos
{
    public class Usuario
    {
        public int id {  get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public DateTime fechaNacimiento { get; set; } 
        public int dni {  get; set; }
        public string correo { get; set; } = string.Empty;

        public Usuario(int id,string nombre, string apellido, DateTime fechaNacimiento, int dni, string correo) {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.dni = dni;
            this.correo = correo;
        }

        public Usuario() { }

    }
}
