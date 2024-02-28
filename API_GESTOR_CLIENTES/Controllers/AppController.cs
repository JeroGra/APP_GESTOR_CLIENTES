using Microsoft.AspNetCore.Mvc;
using API_GESTOR_CLIENTES.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_GESTOR_CLIENTES.Controllers
{
    [ApiController]
    [Route("api")]
    public class AppController : ControllerBase
    {
        private ConexionSQL cn = new ConexionSQL();
        private Administrador administrador = new Administrador();

        [HttpGet]
        [Route("conexion")]
        public async Task<ActionResult<object>> ProbarConexion()
        {
            return cn.VerificarConexion();
        }

        [HttpGet]
        [Route("administrador/usuarios")]
        public async Task<ActionResult<List<Usuario>>> ListarUsuariosBD()
        {
            return await administrador.ListarUsuarios();
        }

        [HttpGet]
        [Route("administrador/clientes")]
        public async Task<ActionResult<List<Cliente>>> ListarClientesBD()
        {
            return await administrador.ListarClientes();
        }
    }
}
