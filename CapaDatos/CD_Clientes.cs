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
    public class CD_Clientes : CD_Base
    {
        private Conexion Conector = new Conexion();
        SqlCommand cmd = new SqlCommand();

        // TODO: MostrarT - Sin parámetros, llama al SP MostrarClientes y retorna DataTable con todos los clientes activos
        public override DataTable MostrarT()
        {
            return MostrarTabla("MostrarClientes");
        }

        // TODO: Registrar_Clientes - Recibe nombre, telefono e informacion, inserta un nuevo cliente en la tabla Clientes de la BD
        public void Registrar_Clientes(string nombre, string telefono, string informacion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
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

        // TODO: Editar_Clientes - Recibe nombre, telefono, informacion e IdCliente, actualiza los datos del cliente en la BD
        public void Editar_Clientes(string nombre, string telefono, string informacion, int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
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

        // TODO: Agregarsaldo - Recibe saldo (int) e IdCliente (int), suma el monto al campo Saldo del cliente en la BD
        public void Agregarsaldo(int saldo, int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
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

        // TODO: Desactivar_Clientes - Recibe IdCliente como int, cambia el campo Activo a 0 para desactivar el cliente en la BD
        public void Desactivar_Clientes(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
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

        // TODO: Reactivar_Clientes - Recibe IdCliente como int, cambia el campo Activo a 1 para reactivar el cliente en la BD
        public void Reactivar_Clientes(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = $"UPDATE Clientes SET Activo=1 WHERE IdCliente={id}";
                cmd.CommandType = CommandType.Text;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // TODO: ExisteTelefono - Recibe un número de teléfono como string, consulta la BD y retorna bool indicando si ya existe
        public bool ExisteTelefono(string telefono)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "SELECT COUNT(*) FROM Clientes WHERE Telefono = @telefono";
                cmd.Parameters.AddWithValue("@telefono", telefono);
                int cantidad = (int)cmd.ExecuteScalar();
                cmd.Connection = Conector.CerrarConexion();
                return cantidad > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // TODO: ExisteTelefonoEditar - Recibe teléfono e IdCliente, verifica si el teléfono pertenece a otro cliente y retorna bool
        public bool ExisteTelefonoEditar(string telefono, int id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
