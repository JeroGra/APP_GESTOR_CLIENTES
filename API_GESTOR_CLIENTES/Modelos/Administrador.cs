using API_GESTOR_CLIENTES.Data;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;


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

        /// <summary>
        /// Inserta un nuevo registro en la tabla Direcciones
        /// </summary>
        /// <param name="d">Datos de la direccion.</param>
        /// <returns>Objeto respuesta, si fue realizado con exito devuelve ok = true y el id del registro, sino ok = false </returns>
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
                                int id = (int)item["id"];
                                res.data = id.ToString();
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

        /// <summary>
        /// Inserta un nuevo registro en la tabla Usuarios.
        /// </summary>
        /// <param name="u">Datos del usuario.</param>
        /// <returns>Objeto respuesta, si fue realizado con exito devuelve ok = true y el id del registro, sino ok = false</returns>
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
                                int id = (int)item["id"];
                                res.data = id.ToString();
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

        /// <summary>
        /// Inserta un nuevo cliente en la base de datos (usuario y direccion).
        /// </summary>
        /// <param name="ud">Datos del cliente (usuario y direccion).</param>
        /// <returns> Retorna un objeto Respuesta, en caso de exito devuelve ok = true, en caso contrario ok = false</returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<Respuesta> InsertarCliente(UsuarioDireccion ud)
        {
            Respuesta res = new Respuesta();

            Usuario usuario = ud.usuario;
            Direccion direccion = ud.direccion;

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
                                cmd.Parameters.AddWithValue("@idUs", Int32.Parse(resUsuario.data));
                                cmd.Parameters.AddWithValue("@idDir", Int32.Parse(resDireccion.data));

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

        /// <summary>
        /// Modifica los datos de un cliente.
        /// </summary>
        /// <param name="ud">Datos del cliente (usuario y direccion).</param>
        /// <returns>Retorna un objeto Respuesta, en caso de exito devuelve ok = true, en caso contrario ok = false</returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<Respuesta> ModificarUsuarioCliente(UsuarioDireccion ud)
        {
            Respuesta res = new Respuesta();

            try
            {

                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {
                    //Setea el comando a ejecutar
                    using (var cmd = new SqlCommand("modificarUsuarioDireccion", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idUs", ud.usuario.id);
                        cmd.Parameters.AddWithValue("@idDir", ud.direccion.id);
                        cmd.Parameters.AddWithValue("@nombre", ud.usuario.nombre);
                        cmd.Parameters.AddWithValue("@apellido", ud.usuario.apellido);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", ud.usuario.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@dni", ud.usuario.dni);
                        cmd.Parameters.AddWithValue("@correo", ud.usuario.correo);
                        cmd.Parameters.AddWithValue("@provincia", ud.direccion.provincia);
                        cmd.Parameters.AddWithValue("@localidad", ud.direccion.localidad);
                        cmd.Parameters.AddWithValue("@calle", ud.direccion.calle);
                        cmd.Parameters.AddWithValue("@numero", ud.direccion.numero);
                        cmd.Parameters.AddWithValue("@codigoPostal", ud.direccion.codigoPostal);
                        cmd.Parameters.AddWithValue("@numeroTelefono", ud.direccion.numeroTelefono);

                        await sql.OpenAsync();

                        //Ejecuta el comando
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            //Captura lo devuelto por el select
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

                                res.data = JsonSerializer.Serialize(cliente);

                            }
                            //Captura si se afecto alguna fila (row)
                            res.ok = item.RecordsAffected > 0;
                            if (res.ok) { res.mensaje = "Cliente Modificado con Exito"; } else { throw new Exception(); }
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
                res.mensaje = "Ocurrio Un error! ";
                return res;
            }

        }

        /// <summary>
        /// Elimina de forma logica un cliente, pasando su estado de true a false en la tabla sql.
        /// </summary>
        /// <param name="id">Id del usuario/cliente.</param>
        /// <returns>Retorna un objeto Respuesta, en caso de exito devuelve ok = true, en caso contrario ok = false</returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<Respuesta> EliminarCLiente(int id)
        {
            Respuesta res = new Respuesta();

            Console.WriteLine(id);

            try
            {
                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {
                    //Setea el comando a ejecutar
                    using (var cmd = new SqlCommand("eliminarCliente", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUs", id);

                        await sql.OpenAsync();

                        //Ejecuta el comando
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            //Captura si se afecto alguna fila (row)
                            res.ok = item.RecordsAffected > 0;
                            if (res.ok) { res.mensaje = "Cliente Eliminado con Exito"; } else { throw new Exception(); }
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
                res.mensaje = "Ocurrio Un error! ";
                return res;
            }

        }


        public async Task<Respuesta> IniciarSesion(Administrador adm)
        {
            Respuesta res = new Respuesta();

            try
            {
                var administrador = new Administrador();

                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {
                    //Setea el comando a ejecutar
                    using (var cmd = new SqlCommand("obtenerAdministradorPorCredenciales", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@correo", adm.correo );
                        cmd.Parameters.AddWithValue("@clave", adm.clave );

                        await sql.OpenAsync();

                        //Ejecuta el comando
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            //Captura lo devuelto por el select
                            while (await item.ReadAsync())
                            {
               
                                administrador.id = (int)item["id"];
                                administrador.nombre = (string)item["nombre"];
                                administrador.apellido = (string)item["apellido"];
                                administrador.fechaNacimiento = (DateTime)item["fechaNacimiento"];
                                administrador.dni = (int)item["dni"];
                                administrador.correo = (string)item["correo"];
                                administrador.clave = (string)item["clave"];


                                res.data = JsonSerializer.Serialize(administrador);

                            }

                            res.ok = res.data != "";
                            if (res.ok) { res.mensaje = "Bienvenido/a "+ administrador.nombre + " " + administrador.apellido; } else { throw new Exception(); }
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
                res.mensaje = "Error! Credenciales invalidas";
                return res;
            }
        }

        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            Respuesta res = new Respuesta();
            var cliente = new Cliente();

            try
            {

                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {
                    //Setea el comando a ejecutar
                    using (var cmd = new SqlCommand("obtenerClientePorId", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", id);

                        await sql.OpenAsync();

                        //Ejecuta el comando
                        using (var item = await cmd.ExecuteReaderAsync())
                        {
                            //Captura lo devuelto por el select
                            while (await item.ReadAsync())
                            {

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

                            }

                        }
                    }
                }

                return cliente;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                res.ok = false;
                res.error = e.ToString();
                res.mensaje = "Error! Credenciales invalidas";
                return cliente;
            }
        }


        public async Task<List<Cliente>> ListarClientesEliminados()
        {
            var lista = new List<Cliente>();

            try
            {
                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {

                    using (var cmd = new SqlCommand("obtenerClientesEliminados", sql))
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

            catch (Exception e) { Console.WriteLine(e); return lista; }
        }


    }
}
