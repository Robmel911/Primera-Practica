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
    public class CD_Productos : CD_Base
    {
        private Conexion Conector = new Conexion();


        public override DataTable MostrarT()
        {
            try
            {
                return MostrarTabla("MostrarProductosActivos");
            }
            catch (SqlException ex)
            {
              throw new Exception ("No se puedo obtener los productos: " + ex.Message); 
            }
        }

        public DataTable ObtenerProductosDesactivados()
        {
            try
            {
                return MostrarTablaDesactivada("MostrarProductosDESACTIVADOS");

            }
            catch (SqlException ex)
            {
                throw new Exception("No se puedo obtener los productos desactivados: " + ex.Message);
            }
         
        }
        public void Insertar_Productos(string nombre,string desc,string marca,double precio,int stock, string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                //Linea para insertar productos a la bd
                cmd.CommandText = $"INSERT INTO Productos (Nombre, Descripcion, Marca, Precio, Stock,Codigo) VALUES ('{nombre}', '{desc}', '{marca}', {precio}, {stock}, '{codigo}' )";
                cmd.CommandType = CommandType.Text;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar productos :" + ex.Message);
            }
           
        }
        public void Editar_Productos(string nombre, string desc, string marca, double precio, int stock, int id,string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                //Linea para editar productos a la bd
                cmd.CommandText = $"UPDATE Productos SET Nombre='{nombre}', Descripcion='{desc}', Marca='{marca}', Precio={precio}, Stock={stock}, Codigo='{codigo}'  WHERE IdProducto={id}";
                cmd.CommandType = CommandType.Text;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();

            }
            catch (SqlException ex)
            {
             throw new Exception("No se pudo editar los productos :" + ex.Message);
            }
        }
        public void Eliminar_Productos(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                //Linea para eliminar productos a la bd
                cmd.CommandText = $"UPDATE Productos SET Activo=0 WHERE IdProducto={id}";
                cmd.CommandType = CommandType.Text;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar los productos :" + ex.Message);
            }

        }
        public void Reactivar_Productos(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                //Linea para reactivar productos a la bd
                cmd.CommandText = $"UPDATE Productos SET Activo=1 WHERE IdProducto={id}";
                cmd.CommandType = CommandType.Text;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo reactivar los productos :" + ex.Message);
            }
        }
        public bool ExisteProducto(string nombre, string marca)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(); // local
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = $"SELECT COUNT(*) FROM Productos WHERE Nombre='{nombre}' AND Marca='{marca}'";
                int cantidad = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
                return cantidad > 0;

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo verificar si existe el producto :" + ex.Message);
            
            }
        }
        public bool ExisteProductoEditar(string nombre, string marca, int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = $"SELECT COUNT(*) FROM Productos WHERE Nombre='{nombre}' AND Marca='{marca}' AND IdProducto != {id}";
                int cantidad = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
                return cantidad > 0;

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar producto existente :" + ex.Message);
            }

        }
        public DataTable ObtenerMarcas()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = "SELECT DISTINCT Marca FROM Productos WHERE Activo=1";
            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
            return tabla;
        }
        public DataTable BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = @"SELECT IdProducto, Nombre, Codigo, Precio, Stock 
                        FROM Productos 
                        WHERE Activo = 1 
                        AND (Codigo LIKE @codigo OR Nombre LIKE @nombre)";
                cmd.Parameters.AddWithValue("@codigo", "%" + codigo + "%");
                cmd.Parameters.AddWithValue("@nombre", "%" + codigo + "%");
                SqlDataReader leer = cmd.ExecuteReader();
                DataTable tabla = new DataTable();
                tabla.Load(leer);
                cmd.Connection = Conector.CerrarConexion();
                return tabla;

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar por codigo :" + ex.Message);
            }
        }
    }
}
