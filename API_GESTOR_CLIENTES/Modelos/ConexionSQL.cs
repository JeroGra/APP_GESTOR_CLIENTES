using System.Data;
using System.Data.SqlClient;

namespace API_GESTOR_CLIENTES.Modelos
{
    public class ConexionSQL
    {
        private static string cadenaConexion = string.Empty;

         public ConexionSQL()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaConexion = constructor.GetSection("ConnectionStrings:sql").Value;
        }

        public object VerificarConexion() {

            var sql = new SqlConnection(cadenaConexion);
            object ok = true;

            try
            {
                sql.Open();
            }
            catch (Exception e)
            {
                ok = e;
            }
            finally
            {
                if (sql.State == ConnectionState.Open)
                {
                    sql.Close();
                }
            }

            return ok;
        }

        public string CadenaConexion()
        {
            return cadenaConexion;
        }

    }
}
