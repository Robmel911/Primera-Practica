using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    // TODO: Agregar importación masiva de productos desde archivo CSV o Excel
    public class CN_Producto : CN_Colmado
    {
        private CD_Productos CDproductos = new CD_Productos();
        // TODO: Agregar parámetro de ordenamiento (por nombre, marca, precio, stock)
        public DataTable Obtenerdatos_Producto()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.MostrarT();
            return tabla;
        }
        public DataTable Obtenermarcas()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.ObtenerMarcas();
            return tabla;
        }
        public void Insertar_producto(string nombre, string desc, string marca, string precio, string codigo, string stock)
        {
            CDproductos.Insertar_Productos(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), codigo);
        }
        public void Editar_producto(string nombre, string desc, string marca, string precio, string stock, string codigo, string id)
        {
            CDproductos.Editar_Productos(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id), codigo);

        }
        public void Eliminar_Producto(string id)
        {
            CDproductos.Eliminar_Productos(Convert.ToInt32(id));

        }
        // TODO: Enviar notificación cuando un producto sea reactivado
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
    }
}
