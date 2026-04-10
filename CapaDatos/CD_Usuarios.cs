using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuarios : CD_Base
    {
        private Conexion con = new Conexion();
        SqlCommand cmd = new SqlCommand();

        // TODO: ValidarUsuarioAsync - Recibe usuario y contraseña, consulta la BD de forma asíncrona y retorna bool indicando si las credenciales son correctas
        public async Task<bool> ValidarUsuarioAsync(string usuario, string contrasena)
        {
            try
            {
                using (SqlConnection sqlCon = await con.ObtenerConexionAsync())
                {
                    SqlCommand cmd = new SqlCommand("ValidarLogin", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);
                    var resultado = await cmd.ExecuteScalarAsync();
                    return resultado != null; // El SP devuelve las columnas IdUsuario y Rol si es exitoso
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }

        // TODO: ObtenerRolAsync - Recibe el nombre de usuario, consulta la BD de forma asíncrona y retorna el Rol como string
        public async Task<string> ObtenerRolAsync(string usuario)
        {
            try
            {
                using (SqlConnection sqlCon = await con.ObtenerConexionAsync())
                {
                    SqlCommand cmd = new SqlCommand("ObtenerDetalleUsuario", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    SqlDataReader leer = await cmd.ExecuteReaderAsync();
                    if (await leer.ReadAsync())
                    {
                        return leer["Rol"].ToString();
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener rol: " + ex.Message);
            }
        }

        // TODO: ObtenerIdAsync - Recibe el nombre de usuario, consulta la BD de forma asíncrona y retorna el IdUsuario como int
        public async Task<int> ObtenerIdAsync(string usuario)
        {
            try
            {
                using (SqlConnection sqlCon = await con.ObtenerConexionAsync())
                {
                    SqlCommand cmd = new SqlCommand("ObtenerDetalleUsuario", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    SqlDataReader leer = await cmd.ExecuteReaderAsync();
                    if (await leer.ReadAsync())
                    {
                        return Convert.ToInt32(leer["IdUsuario"]);
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener id: " + ex.Message);
            }
        }


        // TODO: MostrarT - Sin parámetros, llama al SP MostrarUsuario y retorna DataTable con todos los usuarios registrados
        public override DataTable MostrarT()
        {
            return MostrarTabla("MostrarUsuarios");
        }

        // TODO: Insertar - Recibe Usuario, Contraseña y Rol, llama al SP InsertarUsuario para guardar el nuevo usuario en la BD
        public void Insertar(string Usuario, string Contrasena, string Rol)
        {
            cmd.Connection = con.ObtenerConexion();
            cmd.CommandText = "InsertarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", Usuario);
            cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
            cmd.Parameters.AddWithValue("@Rol", Rol);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        // TODO: EditarUsuario - Recibe Usuario, Rol e IdUsuario, llama al SP EditarUsuario para actualizar los datos del usuario en la BD
        public virtual void EditarUsuario(string Usuario, string Contrasena, string Rol, int IdUsuario)
        {
            cmd.Connection = con.ObtenerConexion();
            cmd.CommandText = "EditarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            cmd.Parameters.AddWithValue("@Usuario", Usuario);
            cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
            cmd.Parameters.AddWithValue("@Rol", Rol);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        // TODO: EliminarUsuario - Recibe IdUsuario como int, llama al SP EliminarUsuario para eliminar el registro de la BD
        public virtual void EliminarUsuario(int IdUsuario)
        {
            cmd.Connection = con.ObtenerConexion();
            cmd.CommandText = "EliminarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
