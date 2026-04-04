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


       
        public DataTable MostrarTabla()
        {
            try
            {
                Conexion conexion = new Conexion();
                SqlDataReader Leer;
                DataTable Tabla = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion.ObtenerConexion();
                cmd.CommandText = $"select *from Clientes where Activo=1";
                Leer = cmd.ExecuteReader();
                Tabla.Load(Leer);
                cmd.Parameters.Clear();
                cmd.Connection = conexion.CerrarConexion();
                return Tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los clientes: " + ex.Message);
            }
        }
        public void Registrar_Clientes(string nombre, string telefono, string informacion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                //Linea de productos en la bd
                cmd.CommandText = "INSERT INTO Clientes (Nombre, Telefono, Informacion) VALUES (@nombre, @telefono, @informacion)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@informacion", informacion);
                cmd.ExecuteNonQuery();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el cliente: " + ex.Message);
            }
        }
        public void Editar_Clientes(string nombre, string telefono, string informacion, int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                //Linea para editar productos a la bd
                cmd.CommandText = "UPDATE Clientes SET Nombre=@nombre, Telefono=@telefono, Informacion=@informacion WHERE IdCliente=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@informacion", informacion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el cliente: " + ex.Message);
            } 
        }
        public void Agregarsaldo(int saldo, int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                //Linea para editar productos a la bd
                cmd.CommandText = $"UPDATE Clientes SET Saldo= Saldo + {saldo} WHERE IdCliente={id}";
                cmd.CommandType = CommandType.Text;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar saldo al cliente: " + ex.Message);
            }
        }
        public void Desactivar_Clientes(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                //Linea para editar productos a la bd
                cmd.CommandText = $"UPDATE Clientes SET Activo=0 WHERE IdCliente={id}";
                cmd.CommandType = CommandType.Text;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactivar el cliente: " + ex.Message);
            }
        }
        public void Reactivar_Clientes(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader Leer;
            cmd.Connection = Conector.ObtenerConexion();
            //Linea para editar productos a la bd
            cmd.CommandText = $"UPDATE Clientes SET Activo=1 WHERE IdCliente={id}";
            cmd.CommandType = CommandType.Text;
            Leer = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
        }
        public bool ExisteTelefono(string telefono)
        {
            SqlCommand cmd = new SqlCommand();
           
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = "SELECT COUNT(*) FROM Clientes WHERE Telefono = @telefono";
            cmd.Parameters.AddWithValue("@telefono", telefono);
            int cantidad = (int)cmd.ExecuteScalar();
            cmd.Connection = Conector.CerrarConexion();
            return cantidad > 0;
        }
        public bool ExisteTelefonoEditar(string telefono, int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = "SELECT COUNT(*) FROM Clientes WHERE Telefono = @telefono AND IdCliente != @id";
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@id", id);
            int cantidad = (int)cmd.ExecuteScalar();
            cmd.Connection = Conector.CerrarConexion();
            return cantidad > 0;
        }
    }
}
