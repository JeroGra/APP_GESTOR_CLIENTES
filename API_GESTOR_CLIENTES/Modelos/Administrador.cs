using API_GESTOR_CLIENTES.Data;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using Newtonsoft.Json;

namespace API_GESTOR_CLIENTES.Modelos
{
    public class Administrador : Usuario, IAdministrar 
    {
        public string clave { get; set; } = string.Empty;

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


        private async Task<Respuesta> InsertarDireccion(Direccion d)
        {
            Respuesta res = new Respuesta();

            try
            {

                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {
                    //Setea el comando a ejecutar
                    using (var cmd = new SqlCommand("insertarTraerDireccion", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@provincia", d.provincia);
                        cmd.Parameters.AddWithValue("@localidad", d.localidad);
                        cmd.Parameters.AddWithValue("@calle", d.calle);
                        cmd.Parameters.AddWithValue("@numero", d.numero);
                        cmd.Parameters.AddWithValue("@codigo_postal", d.codigoPostal);
                        cmd.Parameters.AddWithValue("@numero_telefono", d.numeroTelefono);

                        await sql.OpenAsync();
                     
                        //Ejecuta el comando
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            //Captura lo devuelto por el select
                            while (await item.ReadAsync())
                            {
                             res.id = (int)item["id"];
                            }
                            //Captura si se afecto alguna fila (row)
                           res.ok = item.RecordsAffected > 0;
                        }       
                    }
                }

                return res;
            }
            catch(Exception e) { Console.WriteLine(e);
                res.ok = false;
                res.error = e.ToString();
                return res; }
        }


        private async Task<Respuesta> InsertarUsuario(Usuario u)
        {
            Respuesta res = new Respuesta();

            try
            {

                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {
                    //Setea el comando a ejecutar
                    using (var cmd = new SqlCommand("insertarUsuario", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", u.nombre);
                        cmd.Parameters.AddWithValue("@apellido", u.apellido);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", u.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@dni", u.dni);
                        cmd.Parameters.AddWithValue("@correo", u.correo);

                        await sql.OpenAsync();

                        //Ejecuta el comando
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            //Captura lo devuelto por el select
                            while (await item.ReadAsync())
                            {
                                res.id = (int)item["id"];
                            }
                            //Captura si se afecto alguna fila (row)
                            res.ok = item.RecordsAffected > 0;
                        }
                    }
                }

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                res.ok = false;
                res.error = e.ToString();
                res.mensaje = "Usuario ya existente";
                return res;
            }
        }


        public async Task<Respuesta> InsertarCliente(UsuarioDireccion ud)
        {
            Respuesta res = new Respuesta();
            Usuario usuario = new Usuario(ud.idUs,ud.nombre,ud.apellido,ud.fechaNacimiento,ud.dni,ud.correo);
            Direccion direccion = new Direccion(ud.idDir, ud.provincia, ud.localidad, ud.calle, ud.numero, ud.codigoPostal, ud.numeroTelefono);
            Respuesta resUsuario = new Respuesta();
            Respuesta resDireccion = new Respuesta();
            try
            {
                resUsuario = await this.InsertarUsuario(usuario);
                if (resUsuario.ok)
                {
                     resDireccion = await this.InsertarDireccion(direccion);
                    if (resDireccion.ok)
                    {
                        using (var sql = new SqlConnection(conexion.CadenaConexion()))
                        {
                            //Setea el comando a ejecutar
                            using (var cmd = new SqlCommand("insertarCliente", sql))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idUs", resUsuario.id);
                                cmd.Parameters.AddWithValue("@idDir", resDireccion.id);

                                await sql.OpenAsync();

                                //Ejecuta el comando
                                using (var item = await cmd.ExecuteReaderAsync())
                                {
                                    //Captura si se afecto alguna fila (row)
                                    res.ok = item.RecordsAffected > 0;
                                    if (res.ok) { res.mensaje = "Cliente Agregado con Exito"; } else { throw new Exception(); }
                                }
                            }
                        }


                        return res;
                    }
                    else
                    {
                        throw new Exception(resUsuario.mensaje);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                res.ok = false;
                res.error = e.ToString();
                res.mensaje = "Ocurrio Un error! " + resUsuario.mensaje ;
                return res;
            }

        }


    }
}
