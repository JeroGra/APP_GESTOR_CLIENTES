namespace API_GESTOR_CLIENTES.Modelos
{
    public class Cliente : Usuario
    {
        public Direccion direccion { get; set; } 

        public Boolean estado { get; set; }
    }
}
