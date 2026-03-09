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
        
      
        #region Funciones de Productos
        public DataTable Mostrartabla_Producto()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.MostrarTabla();
            return tabla;
        }
        public void Insertar_producto(string nombre, string desc, string marca, string precio, string stock)
        {
            CDproductos.Insertar_Productos(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
            
        }
        public void Editar_producto(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            CDproductos.Editar_Productos(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));

        }
        public void Eliminar_Producto(string id)
        {
            CDproductos.Eliminar_Productos(Convert.ToInt32(id));

        }
        public void Reactivar_Producto(string id)
        {
            CDproductos.Reactivar_Productos(Convert.ToInt32(id));
        }
        #endregion
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
        #endregion
    }
}
