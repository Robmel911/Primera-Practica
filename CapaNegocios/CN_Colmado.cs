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
        private TablasDB tablasdb = new TablasDB();
      
        public DataTable Mostrartabla(string Datagrid)
        {
            DataTable tabla = new DataTable();
            tabla = tablasdb.MostrarTabla(Datagrid);
            return tabla;
        }
        public DataTable Mostrartabla_Producto()
        {
            DataTable tabla = new DataTable();
            tabla = CDproductos.MostrarTabla();
            return tabla;
        }
        public void Insertar_producto(string nombre, string desc, string marca, string precio, string stock)
        {
            CDproductos.Insertar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
            
        }
        public void Editar_producto(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            CDproductos.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));

        }
        public void Eliminar_Producto(string id)
        {
            CDproductos.Eliminar (Convert.ToInt32(id));

        }

    }
}
