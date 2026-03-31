using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // TODO: Clase de negocios para el módulo de Auditoría
    public class CN_Auditoria
    {
        private CD_Auditoria datos = new CD_Auditoria();

        // TODO: Registrar acción en auditoría de forma asíncrona
        public async Task RegistrarAsync(int idUsuario, string accion, string tabla)
        {
            await Task.Run(() =>
            {
                try
                {
                    datos.InsertarAuditoria(idUsuario, accion, tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar auditoría: " + ex.Message);
                }
            });
        }

        // TODO: Obtener todos los registros
        public DataTable ObtenerTodos()
        {
            try
            {
                return datos.ObtenerAuditoria();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener auditoría: " + ex.Message);
            }
        }

        // TODO: Filtrar por usuario
        public DataTable FiltrarPorUsuario(string usuario)
        {
            try
            {
                return datos.FiltrarPorUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar: " + ex.Message);
            }
        }

        // TODO: Filtrar por rango de fechas
        public DataTable FiltrarPorFecha(DateTime inicio, DateTime fin)
        {
            try
            {
                return datos.FiltrarPorFecha(inicio, fin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar por fecha: " + ex.Message);
            }
        }
    }
}
