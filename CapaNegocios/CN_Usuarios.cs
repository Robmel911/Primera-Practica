using System;
using System.Collections.Generic;
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



    }
    public static class Sesion
    {
        public static int IdUsuario { get; set; }

    }
}
