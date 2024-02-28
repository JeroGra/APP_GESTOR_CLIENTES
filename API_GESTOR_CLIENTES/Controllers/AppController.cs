using Microsoft.AspNetCore.Mvc;
using API_GESTOR_CLIENTES.Modelos;

namespace API_GESTOR_CLIENTES.Controllers
{
    [ApiController]
    [Route("api")]
    public class AppController : ControllerBase
    {
        private ConexionSQL cn = new ConexionSQL();

        [HttpGet]
        [Route("conexion")]
        public async Task<ActionResult<Object>> ProbarConexion()
        {
            return cn.VerificarConexion();
        }
    }
}
