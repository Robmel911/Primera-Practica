using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Interfaz que obliga a todas las clases de datos a implementar el método de consulta general.
    /// </summary>
    public interface IMostrarTabla
    {
        // TODO: MostrarT - Sin parámetros, retorna un DataTable con todos los registros de la entidad correspondiente
        DataTable MostrarT();
    }

    public class Conexion
    {
        private string cadenaConexion = "Server=.;Database=SistemaColmado;Integrated Security=True";

        // TODO: ObtenerConexion - Sin parámetros, crea y abre una SqlConnection usando la cadena de conexión, retorna SqlConnection activa
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

        // TODO: ObtenerConexionAsync - Sin parámetros, abre la conexión de forma asíncrona y retorna Task<SqlConnection>
        public async Task<SqlConnection> ObtenerConexionAsync()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            await conexion.OpenAsync();
            return conexion;
        }

        // TODO: CerrarConexion - Sin parámetros, verifica si la conexión está abierta y la cierra, retorna SqlConnection
        public SqlConnection CerrarConexion()
        {
            if (ObtenerConexion().State == System.Data.ConnectionState.Open)
            {
                ObtenerConexion().Close();
            }
            return ObtenerConexion();
        }

        // TODO: ProbarConexion - Sin parámetros, intenta abrir la conexión para verificar disponibilidad, retorna bool
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

    public abstract class CD_Base : IMostrarTabla
    {
        SqlCommand cmd = new SqlCommand();
        Conexion conexion = new Conexion();
        DataTable tabla = new DataTable();
        SqlDataReader leer;

        // TODO: MostrarT - Sin parámetros, método abstracto que cada clase hija implementa para retornar su DataTable completo
        public abstract DataTable MostrarT();

        // TODO: MostrarTabla - Recibe el nombre del procedimiento almacenado como string, lo ejecuta y retorna DataTable con los resultados
        public virtual DataTable MostrarTabla(string Procedimiento)
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

        // TODO: MostrarTablaDesactivada - Recibe nombre del procedimiento almacenado, lo ejecuta y retorna DataTable con registros desactivados
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
