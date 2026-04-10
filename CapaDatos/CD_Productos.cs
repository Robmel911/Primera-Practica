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

        // TODO: MostrarT - Sin parámetros, llama al SP MostrarProductosActivos y retorna DataTable con los productos activos
        public override DataTable MostrarT()
        {
            try
            {
                return MostrarTabla("MostrarProductosActivos");
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puedo obtener los productos: " + ex.Message);
            }
        }

        // TODO: ObtenerProductosDesactivados - Sin parámetros, llama al SP MostrarProductosDESACTIVADOS y retorna DataTable con productos inactivos
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

        // TODO: Insertar_Productos - Recibe nombre, descripcion, marca, precio, stock y codigo, inserta un nuevo producto en la tabla Productos de la BD
        public void Insertar_Productos(string nombre, string desc, string marca, double precio, int stock, string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "InsertarProducto";
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", desc);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar productos :" + ex.Message);
            }
        }

        // TODO: Editar_Productos - Recibe nombre, descripcion, marca, precio, stock, IdProducto y codigo, actualiza el registro del producto en la BD
        public void Editar_Productos(string nombre, string desc, string marca, double precio, int stock, int id, string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader Leer;
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "EditarProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", desc);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Activo", 1);
                Leer = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar los productos :" + ex.Message);
            }
        }

        // TODO: Eliminar_Productos - Recibe IdProducto como int, cambia el campo Activo a 0 para realizar una eliminación lógica del producto
        public void Eliminar_Productos(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "EliminarProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar los productos :" + ex.Message);
            }
        }
        // TODO: Reactivar_Productos - Recibe IdProducto como int, cambia el campo Activo a 1 para volver a habilitar el producto en la BD
        public void Reactivar_Productos(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "ReactivarProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Connection = Conector.CerrarConexion();
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo reactivar los productos :" + ex.Message);
            }
        }
        // TODO: ExisteProducto - Recibe nombre y marca del producto, consulta la BD y retorna bool indicando si ya existe esa combinación
        public bool ExisteProducto(string nombre, string marca)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "ExisteProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Marca", marca);
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
        // TODO: ExisteProductoEditar - Recibe nombre, marca e IdProducto, verifica si existe un duplicado excluyendo el registro actual y retorna bool
        public bool ExisteProductoEditar(string nombre, string marca, int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "ExisteProductoEditar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@IdProducto", id);
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
        // TODO: ObtenerMarcas - Sin parámetros, consulta las marcas distintas de productos activos en la BD y retorna DataTable
        public DataTable ObtenerMarcas()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            cmd.Connection = Conector.ObtenerConexion();
            cmd.CommandText = "ObtenerMarcas";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cmd.Parameters.Clear();
            cmd.Connection = Conector.CerrarConexion();
            return tabla;
        }
        // TODO: BuscarPorCodigo - Recibe criterio de búsqueda como string, busca por código o nombre en productos activos y retorna DataTable
        public DataTable BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conector.ObtenerConexion();
                cmd.CommandText = "BuscarProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Criterio", codigo);
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
