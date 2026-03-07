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
        public void Eliminar_Clientes(int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"delete from Clientes WHERE IdCliente={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
    }
}
