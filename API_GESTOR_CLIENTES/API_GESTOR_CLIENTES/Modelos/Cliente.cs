using System.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace API_GESTOR_CLIENTES.Modelos
{
    public class Cliente : Usuario
    {
        public Direccion direccion { get; set; } 

        public Boolean estado { get; set; }

        ConexionSQL conexion = new ConexionSQL();

        public async Task<Respuesta> IniciarSesion(Cliente cli)
        {
            Respuesta res = new Respuesta();

            try
            {
                var cliente = new Cliente();

                using (var sql = new SqlConnection(conexion.CadenaConexion()))
                {
                    //Setea el comando a ejecutar
                    using (var cmd = new SqlCommand("obtenerClientePorCredenciales", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@correo", cli.correo);
                        cmd.Parameters.AddWithValue("@dni", cli.dni);

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


                                res.data = JsonSerializer.Serialize(cliente);

                            }

                            res.ok = res.data != "";
                            if (res.ok) { res.mensaje = "Bienvenido/a " + cliente.nombre + " " + cliente.apellido; } else { throw new Exception(); }
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

    }
}
