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
                cmd.CommandText = "InsertarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Informacion", informacion);
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
                cmd.CommandText = "EditarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Informacion", informacion);
                cmd.Parameters.AddWithValue("@Saldo", 0); // Valor por defecto o actual
                cmd.Parameters.AddWithValue("@Activo", 1); // Valor por defecto
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
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "AgregarSaldoCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.Parameters.AddWithValue("@Monto", saldo);
                cmd.ExecuteNonQuery();
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
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "DesactivarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.ExecuteNonQuery();
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
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "ReactivarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.ExecuteNonQuery();
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
                cmd.CommandText = "ExisteTelefono";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Telefono", telefono);
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
                cmd.CommandText = "ExisteTelefonoEditar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@IdCliente", id);
                int cantidad = (int)cmd.ExecuteScalar();
                cmd.Connection = Conector.CerrarConexion();
                return cantidad > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable MostrarClientesDesactivados()
        {
            try
            {
                return MostrarTablaDesactivada("MostrarClientesDesactivados");
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puedo obtener los clientes desactivados: " + ex.Message);
            }
        }
    }

}
