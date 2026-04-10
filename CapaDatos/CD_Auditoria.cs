using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: Agregar campo de nivel de severidad (Info, Advertencia, Error) en la tabla Auditoria
    public class CD_Auditoria : CD_Base
    {
        SqlCommand cmd = new SqlCommand();
        Conexion conexion = new Conexion();
        DataTable tabla = new DataTable();

        // TODO: Agregar sobrecarga que acepte dirección IP del usuario para trazabilidad
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

        // TODO: Agregar filtro por usuario y rango de fechas para consultas de auditoría
        public override DataTable MostrarT()
        {
            return MostrarTabla("MostrarAuditoria");
        }
    }
}
