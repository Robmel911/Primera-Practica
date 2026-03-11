using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Ventas
    {
        SqlCommand cmd = new SqlCommand();

        public bool RegistrarVenta(int? idCliente, DataTable carrito, decimal total)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.ObtenerConexion();
            SqlTransaction transaccion = con.BeginTransaction();

            try
            {
                cmd.Connection = con;
                cmd.Transaction = transaccion;

                // 1 — Insertar cabecera de venta
                cmd.CommandText = @"INSERT INTO Ventas (IdCliente, Fecha, MontoTotal, Estado) 
                                    VALUES (@idCliente, GETDATE(), @total, 'Completada');
                                    SELECT SCOPE_IDENTITY();";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idCliente", (object)idCliente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@total", total);

                int idVenta = Convert.ToInt32(cmd.ExecuteScalar());

                // 2 — Insertar cada línea del carrito
                foreach (DataRow fila in carrito.Rows)
                {
                    int idProducto = Convert.ToInt32(fila["IdProducto"]);
                    int cantidad = Convert.ToInt32(fila["Cantidad"]);
                    decimal precio = Convert.ToDecimal(fila["Precio"]);

                    // Verificar stock
                    cmd.CommandText = "SELECT Stock FROM Productos WHERE IdProducto = @idProducto";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    int stockActual = Convert.ToInt32(cmd.ExecuteScalar());

                    if (stockActual < cantidad)
                        throw new Exception($"Stock insuficiente para el producto {fila["Nombre"]}");

                    // Insertar detalle
                    cmd.CommandText = @"INSERT INTO VentaDetalle (IdVenta, IdProducto, Cantidad, PrecioUnitario)
                                        VALUES (@idVenta, @idProducto, @cantidad, @precio)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.ExecuteNonQuery();

                    // Actualizar stock
                    cmd.CommandText = @"UPDATE Productos 
                                        SET Stock = Stock - @cantidad 
                                        WHERE IdProducto = @idProducto";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
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
        public DataTable HistorialVentas()
        {
            Conexion conexion = new Conexion();
            DataTable tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = @"SELECT v.IdVenta, 
                        ISNULL(c.Nombre, 'Consumidor Final') AS Cliente,
                        v.Fecha, v.MontoTotal, v.Estado
                        FROM Ventas v
                        LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                        ORDER BY v.Fecha DESC";
            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cmd.Connection = conexion.CerrarConexion();
            return tabla;
        }

        public void AnularVenta(int idVenta)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.ObtenerConexion();
            SqlTransaction transaccion = con.BeginTransaction();

            try
            {
                cmd.Connection = con;
                cmd.Transaction = transaccion;

                // Restaurar stock de cada producto
                cmd.CommandText = @"UPDATE Productos 
                            SET Stock = Stock + vd.Cantidad
                            FROM Productos p
                            INNER JOIN VentaDetalle vd ON p.IdProducto = vd.IdProducto
                            WHERE vd.IdVenta = @idVenta";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.ExecuteNonQuery();

                // Marcar venta como anulada
                cmd.CommandText = "UPDATE Ventas SET Estado = 'Anulada' WHERE IdVenta = @idVenta";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
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
    }
}
