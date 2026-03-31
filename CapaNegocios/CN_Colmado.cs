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
        private CD_Clientes CDclientes = new CD_Clientes();
        private CD_Ventas CDventas = new CD_Ventas();


        #region Funciones de Productos
        public DataTable Obtenerdatos_Producto()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.ObtenerProductos();
            return tabla;
        }
        public DataTable Obtenermarcas()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.ObtenerMarcas();
            return tabla;
        }
        public void Insertar_producto(string nombre, string desc, string marca, string precio, string codigo,string stock)
        {
            CDproductos.Insertar_Productos(nombre, desc, marca, Convert.ToDouble(precio),Convert.ToInt32(stock), codigo);   
        }
        public void Editar_producto(string nombre, string desc, string marca, string precio,string stock, string codigo, string id)
        {
            CDproductos.Editar_Productos(nombre, desc, marca, Convert.ToDouble(precio),Convert.ToInt32(stock),Convert.ToInt32(id), codigo);

        }
        public void Eliminar_Producto(string id)
        {
            CDproductos.Eliminar_Productos(Convert.ToInt32(id));

        }
        public void Reactivar_Producto(string id)
        {
            CDproductos.Reactivar_Productos(Convert.ToInt32(id));
        }
        public DataTable ObtenerProductosdesactivados()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.ObtenerProductosDesactivados();
            return tabla;
        }

        #endregion

        #region Funciones de Ventas
        public DataTable ObtenerProductos_Venta()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.ObtenerProductos();
            return tabla;
        }

        public DataTable ObtenerClientes_Venta()
        {
            DataTable tabla = new DataTable();
            tabla = CDclientes.MostrarTabla();
            return tabla;
        }

        public bool RegistrarVenta(int? idCliente, DataTable carrito, decimal total, string estado)
        {
            return CDventas.RegistrarVenta(idCliente, carrito, total, estado);
        }
        public DataTable HistorialVentas()
        {
            return CDventas.HistorialVentas();
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
        #endregion
        #region Funciones de Reportes
        public DataTable ReporteVentas()
        {
            return CDventas.VentasDelDia();
        }
        public DataTable Top5Productos()
        {
            return CDventas.Top5Productos();
        }
        #endregion
    }
}
