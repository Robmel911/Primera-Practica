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
        private CD_Productos Obj_Producto = new CD_Productos();
        public bool Prueba()
        {
            Conexion Conexion = new Conexion();
            bool exito = Conexion.ProbarConexion();
            if (exito) { return true; }
            else { return false; }
            
        }
      

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = Obj_Producto.Mostrar();
            return tabla;
        }
    }
}
