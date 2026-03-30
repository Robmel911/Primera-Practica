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
    
    public partial class Login : Form
    {
        private CN_Usuarios CNUsuarios = new CN_Usuarios();
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
                var (existe, rol) = await CNUsuarios.LoginAsync(txtUsuario.Text, txtContrasena.Text);
                // Si el usuario existe, cierra el formulario con DialogResult.OK
                if (existe)
                {
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
        // Permite presionar Enter para iniciar sesión
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnIngresar_Click(sender, e);
        }

    }
}
