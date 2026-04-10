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
        // Método asíncrono Para tareas asincronas
        public async Task<SqlConnection> ObtenerConexionAsync()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            await conexion.OpenAsync();
            return conexion;
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
        // Método para probar la conexión
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

    public abstract class CD_Base
    {
        SqlCommand cmd = new SqlCommand();
        Conexion conexion = new Conexion();
        DataTable tabla = new DataTable();
        SqlDataReader leer;
        public abstract DataTable MostrarT();
        protected virtual DataTable MostrarTabla(string Procedimiento)
        {
            tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = Procedimiento;
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        protected virtual DataTable MostrarTablaDesactivada(string Procedimiento)
        {
            tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = Procedimiento;
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }

}    
    

