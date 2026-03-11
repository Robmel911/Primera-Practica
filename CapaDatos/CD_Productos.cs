using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace CapaDatos
{
    public class CD_Productos
    {
        private Conexion Conector = new Conexion();

    
        SqlCommand cmd = new SqlCommand();

        public DataTable ObtenerProductos()
        {
            Conexion conexion = new Conexion();
            SqlDataReader Leer;
            DataTable Tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = "select *from Productos where Activo=1";
            Leer = cmd.ExecuteReader();
            Tabla.Load(Leer);
            cmd.Connection = conexion.CerrarConexion();
            return Tabla;
        }
        public void Insertar_Productos(string nombre,string desc,string marca,double precio,int stock)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para insertar productos a la bd
            cmd.CommandText = $"INSERT INTO Productos (Nombre, Descripcion, Marca, Precio, Stock) VALUES ('{nombre}', '{desc}', '{marca}', {precio}, {stock})";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Editar_Productos(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Productos SET Nombre='{nombre}', Descripcion='{desc}', Marca='{marca}', Precio={precio}, Stock={stock} WHERE IdProducto={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Eliminar_Productos(int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para eliminar productos a la bd
            cmd.CommandText = $"UPDATE Productos SET Activo=0 WHERE IdProducto={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Reactivar_Productos(int id)
        {
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para reactivar productos a la bd
            cmd.CommandText = $"UPDATE Productos SET Activo=1 WHERE IdProducto={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
    }
}
