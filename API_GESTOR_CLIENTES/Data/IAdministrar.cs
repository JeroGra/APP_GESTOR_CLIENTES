using API_GESTOR_CLIENTES.Modelos;

namespace API_GESTOR_CLIENTES.Data
{
    public interface IAdministrar
    {
        public Task<List<Usuario>> ListarUsuarios();

        public Task<List<Cliente>> ListarClientes();
    }
}
