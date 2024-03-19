using API_GESTOR_CLIENTES.Modelos;

namespace API_GESTOR_CLIENTES.Data
{
    public interface IAdministrar
    {
        public Task<List<Usuario>> ListarUsuarios();

        public Task<List<Cliente>> ListarClientes();

        public Task<Respuesta> InsertarCliente(UsuarioDireccion ud);

        public Task<Respuesta> ModificarUsuarioCliente(UsuarioDireccion ud);

        public Task<Respuesta> EliminarCLiente(int id);
    }
}
