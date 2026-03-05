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
        private string cadenaConexion = "Server=.;Database=SistemaColmado;Integrated Security=True";

        // Propiedad para obtener la conexión
        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public SqlConnection CerrarConexion()
        {
            if (ObtenerConexion().State == System.Data.ConnectionState.Open)
            {
                ObtenerConexion().Close();
            }
            return ObtenerConexion();

        }
        // 3Método para probar la conexión
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

