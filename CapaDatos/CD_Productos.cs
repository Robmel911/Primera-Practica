using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace CapaDatos
{
    public class CD_Productos
    {
        private Conexion Conector = new Conexion();

        SqlDataReader Leer;
        DataTable Tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        //metodo para mostrar la tabla 
        public DataTable Mostrar()
        {
            cmd.Connection= Conector.ObtenerConexion();
            cmd.CommandText = "select *from Productos";
            Leer = cmd.ExecuteReader();
            Tabla.Load(Leer);
            cmd.Connection=Conector.CerrarConexion();
            return Tabla;
        }
    }
}
