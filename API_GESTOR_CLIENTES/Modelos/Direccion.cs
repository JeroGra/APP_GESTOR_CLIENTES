using System.Numerics;

namespace API_GESTOR_CLIENTES.Modelos
{
    public class Direccion
    {
        public int id {  get; set; }
        public string provincia { get; set; }
        public string localidad { get; set; }
        public string calle {  get; set; }
        public int numero { get; set; }
        public int codigoPostal { get; set; }
        public Int64 numeroTelefono { get; set; }

    }
}
