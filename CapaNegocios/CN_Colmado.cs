using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class CN_Colmado
    {
        public bool Prueba()
        {
            Conexion Conexion = new Conexion();
            bool exito = Conexion.ProbarConexion();
            if (exito) { return true; }
            else { return false; }
            
        }
    }
}
