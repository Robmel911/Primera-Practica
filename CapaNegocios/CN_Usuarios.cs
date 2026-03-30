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
        public async Task<(bool Existe, string Rol)> LoginAsync(string usuario, string contrasena)
        {
            try
            {
                // Valida si el usuario existe
                bool existe = await CDUsuarios.ValidarUsuarioAsync(usuario, contrasena);
                // Si existe, obtiene el rol del usuario
                string rol;
                if (existe)
                    rol = await CDUsuarios.ObtenerRolAsync(usuario);
                else
                    rol = string.Empty;

                return (existe, rol);
            }
            catch (Exception)
            {
                return (false, string.Empty);
            }
        
        }
    }
}
