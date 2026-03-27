using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primera_Practica
{
    
    public partial class Login : Form
    {
        private Principal inicio = new Principal();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Bienvenido " + txtUsuario.Text);
            inicio.FormClosed += (s, args) => Application.Exit();
            inicio.Show();
            this.Hide();

        }
    }
}
