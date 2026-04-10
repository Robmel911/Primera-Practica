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

        // TODO: LoginAsync - Recibe usuario y contraseña, valida credenciales de forma asíncrona y retorna tupla (bool Existe, string Rol, int IdUsuario)
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

        // TODO: MostrarUsuario - Sin parámetros, obtiene todos los usuarios desde la capa de datos y retorna DataTable
        public DataTable MostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = CDUsuarios.MostrarT();
            return tabla;
        }

        // TODO: InsertarUsuario - Recibe usuario, Contrasena y Rol como string, los envía a la capa de datos para insertar el nuevo usuario en la BD
        public void InsertarUsuario(string usuario, string Contrasena, string Rol)
        {
            CDUsuarios.Insertar(usuario, Contrasena, Rol);
        }

        // TODO: EditarUsuario - Recibe Usuario, rol e IdUsuario como string, convierte IdUsuario a int y envía los datos a la capa de datos para actualizar
        public void EditarUsuario(string Usuario, string Contrasena, string Rol, string IdUsuario)
        {
            CDUsuarios.EditarUsuario(Usuario, Contrasena, Rol, Convert.ToInt32(IdUsuario));
        }

        // TODO: EliminarUsuario - Recibe IdUsuario como int y lo envía a la capa de datos para eliminar el registro del usuario en la BD
        public void EliminarUsuario(int IdUsuario)
        {
            CDUsuarios.EliminarUsuario(IdUsuario);
        }
    }

    // TODO: IdUsuario - Propiedad estática que almacena el Id del usuario autenticado durante toda la sesión activa
    public static class Sesion
    {
        public static int IdUsuario { get; set; }
    }
}
