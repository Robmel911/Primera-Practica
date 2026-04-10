using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class CN_Usuarios
    {
        private CD_Usuarios CDUsuarios = new CD_Usuarios();
        // Valida el login del usuario y obtiene su rol
        public async Task<(bool Existe, string Rol, int IdUsuario)> LoginAsync(string usuario, string contrasena)
        {
            try
            {
                bool existe = await CDUsuarios.ValidarUsuarioAsync(usuario, contrasena);
                string rol;
                int id = 0;

                if (existe)
                {
                    rol = await CDUsuarios.ObtenerRolAsync(usuario);
                    id = await CDUsuarios.ObtenerIdAsync(usuario);
                }
                else
                    rol = string.Empty;

                return (existe, rol, id);
            }
            catch (Exception)
            {
                return (false, string.Empty, 0);
            }
        }

        public DataTable MostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = CDUsuarios.MostrarT();
            return tabla;
        }

        public void InsertarUsuario(string usuario, string Contrasena, string Rol)
        {
            CDUsuarios.Insertar(usuario, Contrasena, Rol);
        }

        public void EditarUsuario(string  Usuario, string rol, string IdUsuario)
        {
            CDUsuarios.EditarUsuario(Usuario, rol, Convert.ToInt32(IdUsuario));
        }

        public void EliminarUsuario(int IdUsuario)
        {
            CDUsuarios.EliminarUsuario(IdUsuario);
        }
    }
    public static class Sesion
    {
        public static int IdUsuario { get; set; }

    }


}
