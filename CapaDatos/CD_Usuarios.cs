using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        private Conexion con = new Conexion();

        // Valida si el usuario existe — retorna bool
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

    }
}

