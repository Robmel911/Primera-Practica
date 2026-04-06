using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Auditoria : Conexion
    {
        SqlCommand cmd = new SqlCommand();
        Conexion conexion = new Conexion();
        DataTable tabla = new DataTable();
        SqlDataReader leer;
        public void Insertar(int IdUsuario, string Accion)
        {
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = "InsertarAuditoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuarioID", IdUsuario);
            cmd.Parameters.AddWithValue("@Accion", Accion);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public DataTable MostrarTabla()
        {
            tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = "MostrarAuditoria";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
