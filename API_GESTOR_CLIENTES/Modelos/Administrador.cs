using API_GESTOR_CLIENTES.Data;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;

namespace API_GESTOR_CLIENTES.Modelos
{
    public class Administrador : Usuario, IAdministrar 
    {
        public int id_adm {  get; set; }

        public string clave { get; set; }

        ConexionSQL conexion  = new ConexionSQL();

        /// <summary>
        /// Se conecta a la base de datos y a travez de un Procedimiento Almacenado trae la lista de usuarios
        /// </summary>
        /// <returns>lista de usuarios **si en la bd hay usuarios y la trae vacia quiere decir que ocurrio un error, ver en consola**</returns>
        public async Task<List<Usuario>> ListarUsuarios()
        {
            var lista = new List<Usuario>();

            try
            {

                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {

                    using (var cmd = new SqlCommand("listarUsuarios", sql))
                    {

                        //Se procede a abrir la conexion utilizando await
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            while (await item.ReadAsync())
                            {
                                var usuario = new Usuario();
                                usuario.id = (int)item["id"];
                                usuario.nombre = (string)item["nombre"];
                                usuario.apellido = (string)item["apellido"];
                                usuario.fechaNacimiento = (DateTime)item["fechaNacimiento"];
                                usuario.dni = (int)item["dni"];
                                usuario.correo = (string)item["correo"];

                                lista.Add(usuario);
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception e) { Console.WriteLine(e); return lista; }
        }

        /// <summary>
        /// Se conecta a la base de datos y a travez de un Procedimiento Almacenado trae una lista con toda la informacion
        /// de los usuarios clientes y sus direccioes
        /// </summary>
        /// <returns>lista de clientes **si en la bd hay clientes y la trae vacia quiere decir que ocurrio un error, ver en consola**</returns>
        public async Task<List<Cliente>> ListarClientes()
        {
            var lista = new List<Cliente>();

            try
            {
                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {

                    using (var cmd = new SqlCommand("listarClientes", sql))
                    {

                        //Se procede a abrir la conexion utilizando await
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            while (await item.ReadAsync())
                            {
                                var cliente = new Cliente();
                                var direccion = new Direccion();
                                cliente.id_cli = (int)item["id_cli"];
                                cliente.id = (int)item["id_usuario"];
                                direccion.id = (int)item["id_direccion"];
                                cliente.estado = (Boolean)item["estado"];
                                cliente.nombre = (string)item["nombre"];
                                cliente.apellido = (string)item["apellido"];
                                cliente.fechaNacimiento = (DateTime)item["fechaNacimiento"];
                                cliente.dni = (int)item["dni"];
                                cliente.correo = (string)item["correo"];
                                direccion.provincia = (string)item["provincia"];
                                direccion.localidad = (string)item["localidad"];
                                direccion.calle = (string)item["calle"];
                                direccion.numero = (int)item["numero"];
                                direccion.codigoPostal = (int)item["codigo_postal"];
                                direccion.numeroTelefono = (Int64)item["numero_telefono"];

                                cliente.direccion = direccion;
                                lista.Add(cliente);
                            }
                        }
                    }
                }

                return lista;
            }

            catch(Exception e) { Console.WriteLine(e); return lista; }
        }
    }
}
