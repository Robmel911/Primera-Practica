using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

    namespace CapaDatos
    {
        public class Conexion
        {
        private string textoconexion = "Server=.;Database=SistemaColmado;Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(textoconexion); conexion.Open(); return conexion;
            }
            catch (Exception ex)
            { throw new Exception("Error al conectar: " + ex.Message); }
        }
        // 3. Método para probar la conexión
        public bool ProbarConexion()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                { return con.State == System.Data.ConnectionState.Open; }
            }
            catch { return false; }
        }
    }
    }

