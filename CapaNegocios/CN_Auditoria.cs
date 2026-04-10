using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Auditoria
    {
        private CD_Auditoria auditoriaCD = new CD_Auditoria();

        // TODO: RegistrarAuditoria - Recibe IdUsuario (int) y Accion (string), los envía a la capa de datos para guardar el registro de la acción realizada en el sistema
        public void RegistrarAuditoria(int IdUsuario, string Accion)
        {
            auditoriaCD.Insertar(IdUsuario, Accion);
        }

        // TODO: MostrarAuditoria - Sin parámetros, obtiene todos los registros de auditoría desde la capa de datos y retorna DataTable
        public DataTable MostrarAuditoria()
        {
            DataTable tabla = new DataTable();
            tabla = auditoriaCD.MostrarT();
            return tabla;
        }
    }
}
