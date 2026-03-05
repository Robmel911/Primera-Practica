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
    public partial class Form1 : Form
    {
        private CN_Colmado Obj_Colmado = new CN_Colmado();
        private const int MENU_COLAPSADO = 60;
        private const int MENU_EXPANDIDO = 200;
        private const int VELOCIDAD_ANIM = 30;
        private bool menuExpandiendo = false;
        
        public Form1()
        {
            InitializeComponent();
            MostrarPanel(panelInicio);
            MarcarBotonActivo(btnInicio);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Tablaproductos();
        }
        private void Tablaproductos()
        {
            dataGridView1.DataSource = Obj_Colmado.MostrarProd();
        }
        #region Funcion del panel
        private void MostrarPanel(Panel panelActivo)
        {
            panelInicio.Visible = false;
            panelProductos.Visible = false;
            panelVentas.Visible = false;
            panelClientes.Visible = false;

            panelActivo.Visible = true;
            panelActivo.BringToFront();
        }

        private void MarcarBotonActivo(Button btnActivo)
        {
            btnInicio.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.Transparent;
            btnVentas.BackColor = Color.Transparent;
            btnClientes.BackColor = Color.Transparent;

            btnActivo.BackColor = Color.FromArgb(46, 125, 50);
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelInicio);
            MarcarBotonActivo(btnInicio);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelProductos);
            MarcarBotonActivo(btnProductos);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelVentas);
            MarcarBotonActivo(btnVentas);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelClientes);
            MarcarBotonActivo(btnClientes);
        }
        private void panelLateral_MouseEnter(object sender, EventArgs e)
        {
            menuExpandiendo = true;
            timerMenu.Start();
        }

        private void panelLateral_MouseLeave(object sender, EventArgs e)
        {
            if (!panelLateral.ClientRectangle.Contains(
                    panelLateral.PointToClient(Cursor.Position)))
            {
                menuExpandiendo = false;
                timerMenu.Start();
            }
        }

        private void timerMenu_Tick(object sender, EventArgs e)
        {
            if (menuExpandiendo)
            {
                if (panelLateral.Width < MENU_EXPANDIDO)
                    panelLateral.Width = Math.Min(panelLateral.Width + VELOCIDAD_ANIM, MENU_EXPANDIDO);
                else
                    timerMenu.Stop();
            }
            else
            {
                if (panelLateral.Width > MENU_COLAPSADO)
                    panelLateral.Width = Math.Max(panelLateral.Width - VELOCIDAD_ANIM, MENU_COLAPSADO);
                else
                    timerMenu.Stop();
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            CN_Colmado prue = new CN_Colmado();
            bool conectado = prue.Prueba();
            if (conectado)
            {
                MessageBox.Show("¡Conexión exitosa a la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

       
    }
}
