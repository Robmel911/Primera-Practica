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


       
        #region Funciones de Clientes
        public DataTable Mostrartabla_Clientes()
        {
            DataTable tabla = new DataTable();
            tabla = CDclientes.MostrarTabla();
            return tabla;
        }
        public void Registrar_Cliente(string nombre,string telefono, string informacion)
        {
            CDclientes.Registrar_Clientes(nombre, telefono, informacion);
        }
        public void Editar_Cliente(string nombre, string telefono, string informacion, string id)
        {
            CDclientes.Editar_Clientes(nombre, telefono, informacion,Convert.ToInt32(id));
        }
        public void Desactivar_Cliente(string id)
        {
            CDclientes.Desactivar_Clientes(Convert.ToInt32(id));
        }
        public void Reactivar_Cliente(string id)
        {
            CDclientes.Reactivar_Clientes(Convert.ToInt32(id));
        }
        public void Agrgarsaldo_Cliente(string saldo,string id)
        {
            CDclientes.Agregarsaldo(Convert.ToInt32(saldo),Convert.ToInt32(id));
        }
        public bool ExisteTelefono(string telefono)
        {
            return CDclientes.ExisteTelefono(telefono);
        }
        public bool ExisteTelefonoEditar(string telefono, string id)
        {
            return CDclientes.ExisteTelefonoEditar(telefono, Convert.ToInt32(id));
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
