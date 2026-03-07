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
        private TablasDB tablasdb = new TablasDB();
      
        public DataTable Mostrartabla(string Datagrid)
        {
            DataTable tabla = new DataTable();
            tabla = tablasdb.MostrarTabla(Datagrid);
            return tabla;
        }
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
        #endregion
        public void Registrar_Cliente(string nombre,string telefono, string informacion)
        {
            CDclientes.Registrar_Clientes(nombre, telefono, informacion);
        }
        public void Editar_Cliente(string nombre, string telefono, string informacion, string id)
        {
            CDclientes.Editar_Clientes(nombre, telefono, informacion,Convert.ToInt32(id));
        }
    }
}
