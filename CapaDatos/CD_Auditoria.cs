using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    // TODO: Clase de datos para el módulo de Auditoría
    public class CD_Auditoria
    {
        private Conexion Conector = new Conexion();

        // TODO: Insertar un registro de auditoría
        public void InsertarAuditoria(int idUsuario, string accion, string tabla)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = $"INSERT INTO Auditoria (IdUsuario, Accion, Tabla, Fecha) " +
                              $"VALUES ({idUsuario}, '{accion}', '{tabla}', GETDATE())";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }

        // TODO: Obtener todos los registros de auditoría
        public DataTable ObtenerAuditoria()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader Leer;
            DataTable Tabla = new DataTable();
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = "SELECT a.IdAuditoria, u.Usuario, a.Accion, a.Tabla, a.Fecha " +
                              "FROM Auditoria a INNER JOIN Usuarios u ON a.IdUsuario = u.IdUsuario " +
                              "ORDER BY a.Fecha DESC";
            Leer = cmd.ExecuteReader();
            Tabla.Load(Leer);
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
            return Tabla;
        }

        // TODO: Filtrar por usuario
        public DataTable FiltrarPorUsuario(string usuario)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader Leer;
            DataTable Tabla = new DataTable();
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = "SELECT a.IdAuditoria, u.Usuario, a.Accion, a.Tabla, a.Fecha " +
                              "FROM Auditoria a INNER JOIN Usuarios u ON a.IdUsuario = u.IdUsuario " +
                              $"WHERE u.Usuario LIKE '%{usuario}%' ORDER BY a.Fecha DESC";
            Leer = cmd.ExecuteReader();
            Tabla.Load(Leer);
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
            return Tabla;
        }

        // TODO: Filtrar por rango de fechas
        public DataTable FiltrarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader Leer;
            DataTable Tabla = new DataTable();
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = "SELECT a.IdAuditoria, u.Usuario, a.Accion, a.Tabla, a.Fecha " +
                              "FROM Auditoria a INNER JOIN Usuarios u ON a.IdUsuario = u.IdUsuario " +
                              "WHERE a.Fecha BETWEEN @inicio AND @fin ORDER BY a.Fecha DESC";
            cmd.Parameters.AddWithValue("@inicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fin", fechaFin.AddDays(1));
            SqlDataReader leer = cmd.ExecuteReader();
            Tabla.Load(leer);
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
            return Tabla;
        }
    }
}
