using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    // TODO: Agregar método para exportar el historial de auditoría a PDF o CSV
    public class CN_Auditoria
    {
        private CD_Auditoria auditoriaCD = new CD_Auditoria();

        // TODO: Agregar parámetro de nivel de acción (Consulta, Modificación, Eliminación)
        public void RegistrarAuditoria(int IdUsuario, string Accion)
        {
            auditoriaCD.Insertar(IdUsuario, Accion);
        }

        public DataTable MostrarAuditoria()
        {
            DataTable tabla = new DataTable();
            tabla = auditoriaCD.MostrarT();
            return tabla;
        }
    }
}
