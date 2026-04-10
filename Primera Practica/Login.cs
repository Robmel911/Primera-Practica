using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace Primera_Practica
{
    
    // TODO: Agregar opción de "Recordar usuario" guardando el nombre en configuración local
    public partial class Login : Form
    {
        private CN_Auditoria auditoria = new CN_Auditoria();
        private CN_Usuarios CNUsuarios = new CN_Usuarios();
        private string IdUsuario ;
        
        
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario, coloca el foco en el campo de usuario
            txtUsuario.Focus();
        }
        // Maneja el evento de clic en el botón Ingresar
        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            // Valida campos vacíos 
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Ingrese su usuario y contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }
            // Intenta validar el usuario
            // Deshabilitar botón mientras consulta
            btnIngresar.Enabled = false;
            btnIngresar.Text = "Verificando...";
            // Llama al método de login de forma asíncrona
            try
            {
                var (existe, rol, idUsuario) = await CNUsuarios.LoginAsync(txtUsuario.Text, txtContrasena.Text);

                if (existe)
                {
                    Sesion.IdUsuario = idUsuario;                            // guardar en sesión global
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario,"Ingreso al sistema"); // auditar el ingreso
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                // Si no existe, muestra un mensaje de error
                else
                {
                    
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso Denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                    txtContrasena.Clear();
                }
            }
            finally
            {
                // Siempre vuelve a habilitar el botón
                btnIngresar.Enabled = true;
                btnIngresar.Text = "Ingresar";
            }
        }
        // TODO: Implementar límite de intentos fallidos y bloqueo temporal de la cuenta
        // Permite presionar Enter para iniciar sesión
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnIngresar_Click(sender, e);
        }

    }
}
