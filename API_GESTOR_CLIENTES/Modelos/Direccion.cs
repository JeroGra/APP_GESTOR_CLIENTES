using System.Numerics;

namespace API_GESTOR_CLIENTES.Modelos
{
    public class Direccion
    {
        public int id {  get; set; }
        public string provincia { get; set; } = string.Empty;
        public string localidad { get; set; } = string.Empty;
        public string calle {  get; set; } = string.Empty;
        public int numero { get; set; }
        public int codigoPostal { get; set; }
        public Int64 numeroTelefono { get; set; }

        public Direccion(int id, string provincia, string localidad, string calle, int numero, int codigoPostal, Int64 numeroTelefono)
        {
            this.id = id;
            this.provincia = provincia;
            this.localidad = localidad;
            this.calle = calle;
            this.numero = numero;
            this.codigoPostal = codigoPostal;
            this.numeroTelefono = numeroTelefono;
        }

        public Direccion() {
        }

    }
}
