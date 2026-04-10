using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Ventas : CD_Base
    {
        SqlCommand cmd = new SqlCommand();

        // TODO: RegistrarVenta - Recibe IdCliente (nullable), carrito (DataTable), total y estado; registra la venta con sus detalles en una transacción y retorna bool
        public bool RegistrarVenta(int? idCliente, DataTable carrito, decimal total, string estado)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.ObtenerConexion();
            SqlTransaction transaccion = con.BeginTransaction();

            try
            {
                cmd.Connection = con;
                cmd.Transaction = transaccion;

                // 1 — Insertar cabecera de venta
                cmd.CommandText = "InsertarVenta";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdCliente", (object)idCliente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@MontoTotal", total);
                cmd.Parameters.AddWithValue("@Estado", estado);

                int idVenta = Convert.ToInt32(cmd.ExecuteScalar());

                // 2 — Insertar cada línea del carrito
                foreach (DataRow fila in carrito.Rows)
                {
                    int idProducto = Convert.ToInt32(fila["IdProducto"]);
                    int cantidad = Convert.ToInt32(fila["Cantidad"]);
                    decimal precio = Convert.ToDecimal(fila["Precio"]);

                    // Insertar detalle usando SP
                    cmd.CommandText = "InsertarVentaDetalle";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", precio);
                    cmd.ExecuteNonQuery();

                    // Nota: El descuento de stock se maneja mediante el SP o manteniendo el UPDATE parametrizado aquí
                    cmd.CommandText = "UPDATE Productos SET Stock = Stock - @cantidad WHERE IdProducto = @idProducto";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.ExecuteNonQuery();
                }

                if (estado == "Pendiente" && idCliente != null)
                {
                    cmd.CommandText = "AgregarSaldoCliente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("@Monto", -total); // Restar saldo (o sumar deuda)
                    cmd.ExecuteNonQuery();
                }

                transaccion.Commit();
                conexion.CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                conexion.CerrarConexion();
                throw new Exception(ex.Message);
            }
        }

        // TODO: MostrarT - Sin parámetros, consulta todas las ventas con nombre de cliente (LEFT JOIN) y retorna DataTable ordenado por fecha descendente
        public override DataTable MostrarT()
        {
            try
            {
                Conexion conexion = new Conexion();
                DataTable tabla = new DataTable();
                cmd.Connection = conexion.ObtenerConexion();
                cmd.CommandText = "MostrarHistorialVentas";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader leer = cmd.ExecuteReader();
                tabla.Load(leer);
                cmd.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // TODO: AnularVenta - Recibe IdVenta como int, restaura el stock de los productos del detalle y cambia el estado de la venta a "Anulada" en una transacción
        public void AnularVenta(int idVenta)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.ObtenerConexion();
            SqlTransaction transaccion = con.BeginTransaction();

            try
            {
                cmd.Connection = con;
                cmd.Transaction = transaccion;

                cmd.CommandText = "AnularVenta";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                cmd.ExecuteNonQuery();

                transaccion.Commit();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                conexion.CerrarConexion();
                throw new Exception(ex.Message);
            }
        }

        // TODO: CompletarVenta - Recibe IdVenta como int, actualiza el estado de la venta a "Completada" en la BD
        public void CompletarVenta(int idVenta)
        {
            try
            {
                Conexion conexion = new Conexion();
                cmd.Connection = conexion.ObtenerConexion();
                cmd.CommandText = "CompletarVenta";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                cmd.ExecuteNonQuery();
                cmd.Connection = conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // TODO: ObtenerDetalleVenta - Recibe IdVenta como int, consulta los productos del detalle con cantidades y precios y retorna DataTable
        public DataTable ObtenerDetalleVenta(int idVenta)
        {
            try
            {
                Conexion conexion = new Conexion();
                DataTable tabla = new DataTable();
                cmd.Connection = conexion.ObtenerConexion();
                cmd.CommandText = "MostrarVentaDetalle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                SqlDataReader leer = cmd.ExecuteReader();
                tabla.Load(leer);
                cmd.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // TODO: VentasDelDia - Sin parámetros, consulta las ventas del día actual excluyendo las anuladas y retorna DataTable
        public DataTable VentasDelDia()
        {
            try
            {
                Conexion conexion = new Conexion();
                DataTable tabla = new DataTable();
                cmd.Connection = conexion.ObtenerConexion();
                cmd.CommandText = "ReporteVentasDelDia";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader leer = cmd.ExecuteReader();
                tabla.Load(leer);
                cmd.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // TODO: Top5Productos - Sin parámetros, consulta los 5 productos con mayor cantidad vendida (excluye ventas anuladas) y retorna DataTable
        public DataTable Top5Productos()
        {
            try
            {
                Conexion conexion = new Conexion();
                DataTable tabla = new DataTable();
                cmd.Connection = conexion.ObtenerConexion();
                cmd.CommandText = "Top5ProductosMasVendidos";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader leer = cmd.ExecuteReader();
                tabla.Load(leer);
                cmd.Connection = conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
