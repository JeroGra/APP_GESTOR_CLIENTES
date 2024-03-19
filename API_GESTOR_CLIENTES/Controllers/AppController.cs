using Microsoft.AspNetCore.Mvc;
using API_GESTOR_CLIENTES.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;

namespace API_GESTOR_CLIENTES.Controllers
{
    [ApiController]
    [Route("api")]
    public class AppController : ControllerBase
    {
        private ConexionSQL cn = new ConexionSQL();
        private Administrador administrador = new Administrador();
        private Cliente cliente = new Cliente();
        private string key = "1fsko2ldpaldpas2'daspñda´d=Admjaks9adk";

        [HttpGet]
        [Route("conexion")]
        public async Task<ActionResult<object>> ProbarConexion()
        {
            return cn.VerificarConexion();
        }

        [Authorize]
        [HttpGet]
        [Route("administrador/usuarios")]
        public async Task<ActionResult<List<Usuario>>> ListarUsuariosBD()
        {
            return await administrador.ListarUsuarios();
        }

        [Authorize]
        [HttpGet]
        [Route("administrador/clientes")]
        public async Task<ActionResult<List<Cliente>>> ListarClientesBD()
        {
            return await administrador.ListarClientes();
        }

        [Authorize]
        [HttpPost]
        [Route("administrador/cliente")]
        public async Task<ActionResult<Respuesta>> insertarCliente([FromBody] UsuarioDireccion usuario_direccion)
        {
            return await administrador.InsertarCliente(usuario_direccion);
        }

        [Authorize]
        [HttpPost]
        [Route("administrador/cliente/modificar")]
        public async Task<ActionResult<Respuesta>> modificarrCliente([FromBody] UsuarioDireccion usuario_direccion)
        {
            return await administrador.ModificarUsuarioCliente(usuario_direccion);
        }

        [Authorize]
        [HttpDelete("administrador/cliente/{id}")]
        public async Task<ActionResult<Respuesta>> eliminarrCliente(int id)
        {
            return await administrador.EliminarCLiente(id);
        }

        [HttpPost]
        [Route("administrador/ingresar")]
        public async Task<ActionResult<string>> IngresoAdministrador([FromBody] Administrador adm)
        {
            Respuesta respuesta = new Respuesta();

            respuesta = await administrador.IniciarSesion(adm);

            Administrador? admin = JsonSerializer.Deserialize<Administrador>(respuesta.data);

            if (respuesta.ok) 
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var bytekey = Encoding.UTF8.GetBytes(key);
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("ID", admin.id.ToString()),
                        new Claim("Correo",admin.correo)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytekey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDes);

                return tokenHandler.WriteToken(token);
            }
            else
            {
                return respuesta.mensaje;
            }

           
        }


        [HttpPost]
        [Route("cliente/ingresar")]
        public async Task<ActionResult<string>> IngresoCliente([FromBody] Cliente cli)
        {
            Respuesta respuesta = new Respuesta();

            respuesta = await cliente.IniciarSesion(cli);

            Cliente? clien = JsonSerializer.Deserialize<Cliente>(respuesta.data);

            if (respuesta.ok)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var bytekey = Encoding.UTF8.GetBytes(key);
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("ID", clien.id.ToString()),
                        new Claim("Correo",clien.correo)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytekey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDes);

                return tokenHandler.WriteToken(token);
            }
            else
            {
                return respuesta.mensaje;
            }
        }

        [Authorize]
        [HttpGet("administrador/cliente/{id}")]
        public async Task<ActionResult<Cliente>> ClientePorId(int id)
        {
            return await administrador.ObtenerClientePorId(id);
        }

        [Authorize]
        [HttpGet]
        [Route("administrador/cliente/eliminados")]
        public async Task<ActionResult<List<Cliente>>> ListarClientesEliminadosBD()
        {
            return await administrador.ListarClientesEliminados();
        }


    }
}
