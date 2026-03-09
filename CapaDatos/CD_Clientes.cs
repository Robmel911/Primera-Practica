using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private Conexion Conector = new Conexion();


        SqlCommand cmd = new SqlCommand();
        public DataTable MostrarTabla()
        {
            Conexion conexion = new Conexion();
            SqlDataReader Leer;
            DataTable Tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = $"select IdCliente,Nombre,Telefono,Informacion,Saldo from Clientes where Activo=1";
            Leer = cmd.ExecuteReader();
            Tabla.Load(Leer);
            cmd.Connection = conexion.CerrarConexion();
            return Tabla;
        }
        public void Registrar_Clientes(string nombre, string telefono, string informacion)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para insertar productos a la bd
            cmd.CommandText = $"INSERT INTO Clientes (Nombre, Telefono, Informacion) VALUES ('{nombre}', '{telefono}', '{informacion}')";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Editar_Clientes(string nombre, string telefono, string informacion, int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Clientes SET Nombre='{nombre}', Telefono='{telefono}', Informacion='{informacion}' WHERE IdCliente={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Agregarsaldo(int saldo, int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Clientes SET Saldo='{saldo}' WHERE IdCliente={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Desactivar_Clientes(int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Clientes SET Activo=0 WHERE IdCliente={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Reactivar_Clientes(int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Clientes SET Activo=1 WHERE IdCliente={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
    }
}
