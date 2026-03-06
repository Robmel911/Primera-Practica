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

        SqlDataReader Leer;
        DataTable Tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable MostrarTabla()
        {
            Conexion conexion = new Conexion();

            SqlDataReader Leer;
            DataTable Tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = $"select *from Productos where Activo=1";
            Leer = cmd.ExecuteReader();
            Tabla.Load(Leer);
            cmd.Connection = conexion.CerrarConexion();
            return Tabla;
        }
        public void Insertar(string nombre,string desc,string marca,double precio,int stock)
        {
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para insertar productos a la bd
            cmd.CommandText = $"INSERT INTO Productos (Nombre, Descripcion, Marca, Precio, Stock) VALUES ('{nombre}', '{desc}', '{marca}', {precio}, {stock})";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Productos SET Nombre='{nombre}', Descripcion='{desc}', Marca='{marca}', Precio={precio}, Stock={stock} WHERE IdProducto={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Connection = Conector.CerrarConexion();
        }
        public void Eliminar(int id)
        {
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Productos SET Activo=0 WHERE IdProducto={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Connection = Conector.CerrarConexion();
        }
    }
}
