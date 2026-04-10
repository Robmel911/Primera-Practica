using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: Implementar encriptación de contraseña (hash SHA-256) antes de guardar y validar
    public class CD_Usuarios : CD_Base
    {
        private Conexion con = new Conexion();
        SqlCommand cmd = new SqlCommand();

        // Valida si el usuario existe — retorna bool
        // TODO: Agregar bloqueo de cuenta tras N intentos fallidos de login
        public async Task<bool> ValidarUsuarioAsync(string usuario, string contrasena)
        {
            try
            {
                // Utiliza una consulta parametrizada para llamadas asíncronas
                using (SqlConnection sqlCon = await con.ObtenerConexionAsync())
                {
                    string query = @"SELECT COUNT(*) FROM Usuarios 
                             WHERE Usuario = @usuario 
                             AND Contrasena = @contrasena";

                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    // Ejecuta la consulta de forma asíncrona y obtiene el resultado
                    var resultado = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(resultado) > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }
        // Obtiene el rol del usuario — retorna string
        public async Task<string> ObtenerRolAsync(string usuario)
        {
            try
            {
                using (SqlConnection sqlCon = await con.ObtenerConexionAsync())
                {
                    string query = "SELECT Rol FROM Usuarios WHERE Usuario = @usuario";
                    
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    // Ejecuta la consulta de forma asíncrona y obtiene el resultado
                    object resultado = await cmd.ExecuteScalarAsync();
                    return resultado != null ? resultado.ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener rol: " + ex.Message);
            }
        }
        public async Task<int> ObtenerIdAsync(string usuario)
        {
            try
            {
                using (SqlConnection sqlCon = await con.ObtenerConexionAsync())
                {
                    string query = "SELECT IdUsuario FROM Usuarios WHERE Usuario = @usuario";
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    object resultado = await cmd.ExecuteScalarAsync();
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener id: " + ex.Message);
            }
        }
        // TODO: Agregar paginación al resultado para sistemas con muchos usuarios
        public override DataTable MostrarT()
        {
            return MostrarTabla("MostrarUsuario");
        }
        // TODO: Validar que el nombre de usuario no contenga caracteres especiales
        public void Insertar(string Usuario,string Contrasena, string Rol)
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
        public virtual void EditarUsuario(string Usuario, string Rol, int IdUsuario)
        {
            cmd.Connection = con.ObtenerConexion();
            cmd.CommandText = "EditarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", Usuario);
            cmd.Parameters.AddWithValue("@Rol", Rol);
            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }
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

