using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Auditoria : CD_Base
    {
        SqlCommand cmd = new SqlCommand();
        Conexion conexion = new Conexion();
        DataTable tabla = new DataTable();

        // TODO: Insertar - Recibe IdUsuario (int) y Accion (string), llama al SP InsertarAuditoria para registrar la acción del usuario en la BD
        public void Insertar(int IdUsuario, string Accion)
        {
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = "InsertarAuditoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            cmd.Parameters.AddWithValue("@Accion", Accion);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        // TODO: MostrarT - Sin parámetros, llama al SP MostrarAuditoria y retorna DataTable con todos los registros de auditoría del sistema
        public override DataTable MostrarT()
        {
            return MostrarTabla("MostrarAuditoria");
        }
    }
}
