using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Producto : CN_Colmado
    {
        private CD_Productos CDproductos = new CD_Productos();

        // TODO: Obtenerdatos_Producto - Sin parámetros, obtiene todos los productos activos desde la capa de datos y retorna DataTable
        public DataTable Obtenerdatos_Producto()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.MostrarT();
            return tabla;
        }

        // TODO: Obtenermarcas - Sin parámetros, obtiene las marcas distintas de productos activos desde la capa de datos y retorna DataTable
        public DataTable Obtenermarcas()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.ObtenerMarcas();
            return tabla;
        }

        // TODO: Insertar_producto - Recibe nombre, descripcion, marca, precio, codigo y stock como string, convierte precio y stock y los envía a la capa de datos para insertar el producto
        public void Insertar_producto(string nombre, string desc, string marca, string precio, string codigo, string stock)
        {
            CDproductos.Insertar_Productos(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), codigo);
        }

        // TODO: Editar_producto - Recibe nombre, descripcion, marca, precio, stock, codigo e id como string, convierte los tipos necesarios y envía los datos a la capa de datos para actualizar el producto
        public void Editar_producto(string nombre, string desc, string marca, string precio, string stock, string codigo, string id)
        {
            CDproductos.Editar_Productos(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id), codigo);
        }

        // TODO: Eliminar_Producto - Recibe IdProducto como string, lo convierte a int y lo envía a la capa de datos para desactivar el producto en la BD
        public void Eliminar_Producto(string id)
        {
            CDproductos.Eliminar_Productos(Convert.ToInt32(id));
        }

        // TODO: Reactivar_Producto - Recibe IdProducto como string, lo convierte a int y lo envía a la capa de datos para volver a activar el producto en la BD
        public void Reactivar_Producto(string id)
        {
            CDproductos.Reactivar_Productos(Convert.ToInt32(id));
        }

        // TODO: ObtenerProductosdesactivados - Sin parámetros, obtiene todos los productos con Activo=0 desde la capa de datos y retorna DataTable
        public DataTable ObtenerProductosdesactivados()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.ObtenerProductosDesactivados();
            return tabla;
        }
    }
}
