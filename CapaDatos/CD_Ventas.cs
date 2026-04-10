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
                cmd.CommandText = @"INSERT INTO Ventas (IdCliente, Fecha, MontoTotal, Estado)
                    VALUES (@idCliente, GETDATE(), @total, @estado);
                    SELECT SCOPE_IDENTITY();";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idCliente", (object)idCliente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@estado", estado);

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
                if (estado == "Pendiente" && idCliente != null)
                {
                    cmd.CommandText = "UPDATE Clientes SET Saldo = Saldo - @monto WHERE IdCliente = @idCliente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@monto", total);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
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

        // TODO: CompletarVenta - Recibe IdVenta como int, actualiza el estado de la venta a "Completada" en la BD
        public void CompletarVenta(int idVenta)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.ObtenerConexion();
            SqlTransaction transaccion = con.BeginTransaction();

            try
            {
                cmd.Connection = conexion.ObtenerConexion();
                cmd.CommandText = "UPDATE Ventas SET Estado = 'Completada' WHERE IdVenta = @idVenta";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.ExecuteNonQuery();
                cmd.Connection = conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                conexion.CerrarConexion();
                throw new Exception(ex.Message);
            }
        }

        // TODO: ObtenerDetalleVenta - Recibe IdVenta como int, consulta los productos del detalle con cantidades y precios y retorna DataTable
        public DataTable ObtenerDetalleVenta(int idVenta)
        {
            Conexion conexion = new Conexion();
            DataTable tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = @"SELECT p.Nombre, p.Marca,
                        vd.Cantidad, vd.PrecioUnitario, vd.Subtotal
                        FROM VentaDetalle vd
                        INNER JOIN Productos p ON vd.IdProducto = p.IdProducto
                        WHERE vd.IdVenta = @idVenta";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@idVenta", idVenta);
            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cmd.Connection = conexion.CerrarConexion();
            return tabla;
        }

        // TODO: VentasDelDia - Sin parámetros, consulta las ventas del día actual excluyendo las anuladas y retorna DataTable
        public DataTable VentasDelDia()
        {
            Conexion conexion = new Conexion();
            DataTable tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = @"SELECT v.IdVenta,
                        ISNULL(c.Nombre, 'Consumidor Final') AS Cliente,
                        v.Fecha, v.MontoTotal, v.Estado
                        FROM Ventas v
                        LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                        WHERE CAST(v.Fecha AS DATE) = CAST(GETDATE() AS DATE)
                        AND v.Estado != 'Anulada'";
            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cmd.Connection = conexion.CerrarConexion();
            return tabla;
        }

        // TODO: Top5Productos - Sin parámetros, consulta los 5 productos con mayor cantidad vendida (excluye ventas anuladas) y retorna DataTable
        public DataTable Top5Productos()
        {
            Conexion conexion = new Conexion();
            DataTable tabla = new DataTable();
            cmd.Connection = conexion.ObtenerConexion();
            cmd.CommandText = @"SELECT TOP 5 p.Nombre, p.Marca,
                        SUM(vd.Cantidad) AS TotalVendido
                        FROM VentaDetalle vd
                        INNER JOIN Productos p ON vd.IdProducto = p.IdProducto
                        INNER JOIN Ventas v    ON vd.IdVenta    = v.IdVenta
                        WHERE v.Estado != 'Anulada'
                        GROUP BY p.Nombre, p.Marca
                        ORDER BY TotalVendido DESC";
            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cmd.Connection = conexion.CerrarConexion();
            return tabla;
        }
    }
}
