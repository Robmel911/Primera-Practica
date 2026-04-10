using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class CN_Colmado
    {
        private CD_Productos CDproductos = new CD_Productos();
        private CD_Ventas CDventas = new CD_Ventas();

       

        #region Funciones de Ventas

        // TODO: ObtenerProductos_Venta - Sin parámetros, obtiene los productos activos para cargarlos en el módulo de ventas y retorna DataTable
        public DataTable ObtenerProductos_Venta()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.MostrarT();
            return tabla;
        }

        // TODO: RegistrarVenta - Recibe IdCliente (nullable), carrito (DataTable), total y estado, los envía a la capa de datos para registrar la venta y retorna bool
        public bool RegistrarVenta(int? idCliente, DataTable carrito, decimal total, string estado)
        {
            return CDventas.RegistrarVenta(idCliente, carrito, total, estado);
        }

        // TODO: HistorialVentas - Sin parámetros, obtiene todas las ventas registradas desde la capa de datos y retorna DataTable
        public DataTable HistorialVentas()
        {
            return CDventas.MostrarT();
        }

        // TODO: AnularVenta - Recibe IdVenta como string, lo convierte a int y lo envía a la capa de datos para anular la venta y restaurar el stock
        public void AnularVenta(string idVenta)
        {
            CDventas.AnularVenta(Convert.ToInt32(idVenta));
        }

        // TODO: BuscarProducto - Recibe criterio de búsqueda como string, consulta productos por código o nombre y retorna DataTable
        public DataTable BuscarProducto(string criterio)
        {
            return CDproductos.BuscarPorCodigo(criterio);
        }

        // TODO: CompletarVenta - Recibe IdVenta como string, lo convierte a int y lo envía a la capa de datos para marcar la venta como completada
        public void CompletarVenta(string idVenta)
        {
            CDventas.CompletarVenta(Convert.ToInt32(idVenta));
        }

        // TODO: ObtenerDetalleVenta - Recibe IdVenta como string, lo convierte a int, obtiene los productos del detalle de esa venta y retorna DataTable
        public DataTable ObtenerDetalleVenta(string idVenta)
        {
            return CDventas.ObtenerDetalleVenta(Convert.ToInt32(idVenta));
        }

        #endregion

        #region Funciones de Reportes

        // TODO: ReporteVentas - Sin parámetros, obtiene las ventas realizadas en el día actual desde la capa de datos y retorna DataTable
        public DataTable ReporteVentas()
        {
            return CDventas.VentasDelDia();
        }

        // TODO: Top5Productos - Sin parámetros, obtiene los 5 productos más vendidos (excluyendo anuladas) desde la capa de datos y retorna DataTable
        public DataTable Top5Productos()
        {
            return CDventas.Top5Productos();
        }

        #endregion
    }
}
