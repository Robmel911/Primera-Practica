using CapaDatos;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Ventas
    {
        private CD_Ventas CDventas = new CD_Ventas();
        private CD_Productos CDproductos = new CD_Productos();
        private CD_Clientes CDclientes = new CD_Clientes();

        public DataTable ObtenerProductos_Venta()
        {
            return CDproductos.ObtenerProductos();
        }

        public DataTable ObtenerClientes_Venta()
        {
            return CDclientes.MostrarTabla();
        }

        public bool RegistrarVenta(int? idCliente, DataTable carrito, decimal total, string estado)
        {
            return CDventas.RegistrarVenta(idCliente, carrito, total, estado);
        }

        public async Task<DataTable> HistorialVentas()
        {
            return await CDventas.HistorialVentas();
        }

        public void AnularVenta(string idVenta)
        {
            CDventas.AnularVenta(Convert.ToInt32(idVenta));
        }

        public DataTable BuscarProducto(string criterio)
        {
            return CDproductos.BuscarPorCodigo(criterio);
        }

        public void CompletarVenta(string idVenta)
        {
            CDventas.CompletarVenta(Convert.ToInt32(idVenta));
        }

        public DataTable ObtenerDetalleVenta(string idVenta)
        {
            return CDventas.ObtenerDetalleVenta(Convert.ToInt32(idVenta));
        }

        public async Task<DataTable> ReporteVentas()
        {
            return await CDventas.VentasDelDia();
        }

        public DataTable Top5Productos()
        {
            return CDventas.Top5Productos();
        }
    }
}