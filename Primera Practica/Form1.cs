using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        private CN_Colmado CNcolmado = new CN_Colmado();
        private const int MENU_COLAPSADO = 35;
        private const int MENU_EXPANDIDO = 200;
        private const int VELOCIDAD_ANIM = 30;
        private bool menuExpandiendo = false;
        private bool Editar = false;
        private string ID;
        
        public Form1()
        {
            InitializeComponent();
            MostrarPanel(panelInicio);
            MarcarBotonActivo(btnInicio);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Tablaproductos();
            Tablaclientes();

        }
        
        #region Funcion del panel lateral
        private void MostrarPanel(Panel panelActivo)
        {
            panelInicio.Visible = false;
            panelProductos.Visible = false;
            panelVentas.Visible = false;
            panelClientes.Visible = false;
            panelAux_Productos.Visible = false;

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
        #region Panel Productos
        private void Limpiartextos_Productos()
        {
            textNombreProd.Clear(); textDescProd.Clear(); textMarcaProd.Text = ""; textPrecioProd.Clear(); textStockProd.Text = "0";
        }
        private void Tablaproductos()
        {
            dataGrid_Productos.DataSource = CNcolmado.Mostrartabla_Producto();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            panelAux_Productos.Visible = false;
            
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //Cuando se agrega
            if (Editar == false)
            {
                try
                {
                    CNcolmado.Insertar_producto(textNombreProd.Text, textDescProd.Text, textMarcaProd.Text, textPrecioProd.Text, textStockProd.Text);
                    MessageBox.Show("El producto fue guardado correctamente");
                    Tablaproductos();
                    panelAux_Productos.Visible = false;
                }
                catch (Exception ex) { MessageBox.Show("No se agrego correctamente porque" + ex); }
            }
            // Cuando se edita
            else
            {
                try
                {
                    CNcolmado.Editar_producto(textNombreProd.Text, textDescProd.Text, textMarcaProd.Text, textPrecioProd.Text, textStockProd.Text,ID);
                    MessageBox.Show("El producto fue editado correctamente");
                    Tablaproductos();
                    panelAux_Productos.Visible = false;
                    Editar = false;
                }
                catch (Exception ex) { MessageBox.Show("No se edito correctamente porque" + ex); }
            }
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            Editar = false;
            panelAux_Productos.Visible = true;
            label_panelAux.Text = "Agregar Producto";
            //lim[iar todas las text box
            Limpiartextos_Productos();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGrid_Productos.SelectedRows.Count > 0) 
            {
                Editar = true;
                panelAux_Productos.Visible = true;
                label_panelAux.Text = "Editar Producto";
                textNombreProd.Text = dataGrid_Productos.CurrentRow.Cells["Nombre"].Value.ToString();
                textDescProd.Text = dataGrid_Productos.CurrentRow.Cells["Descripcion"].Value.ToString();
                textMarcaProd.Text = dataGrid_Productos.CurrentRow.Cells["Marca"].Value.ToString();
                textPrecioProd.Text = dataGrid_Productos.CurrentRow.Cells["Precio"].Value.ToString();
                textStockProd.Text = dataGrid_Productos.CurrentRow.Cells["Stock"].Value.ToString();
                ID = dataGrid_Productos.CurrentRow.Cells["IdProducto"].Value.ToString();

            }
            else { MessageBox.Show("Seleccione una fila"); }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if(dataGrid_Productos.SelectedRows.Count > 0)
            {
                
                ID = dataGrid_Productos.CurrentRow.Cells["IdProducto"].Value.ToString();
                MessageBox.Show("Esta seguro");
                CNcolmado.Eliminar_Producto(ID);
                MessageBox.Show("Se ha eliminado el producto");
                Tablaproductos();
            }
            else { MessageBox.Show("Seleccione una fila"); }
        }

        #endregion
        #region Panel Clientes
        private void Tablaclientes()
        {
            dataGrid_Clientes.DataSource = CNcolmado.Mostrartabla("Clientes");
        }
        private void btnregistrar_Cl_Click(object sender, EventArgs e)
        {
            panelAux_Clientes.Visible = true;
            tituloauxCl.Text = "Registrar cliente";
        }

        private void btneditar_Cl_Click(object sender, EventArgs e)
        {
            if (dataGrid_Clientes.SelectedRows.Count > 0)
            {
                Editar = true;
                panelAux_Clientes.Visible = true;
                tituloauxCl.Text = "Editar cliente";
                textNombreCl.Text = dataGrid_Clientes.CurrentRow.Cells["Nombre"].Value.ToString();
                textTelefonoCl.Text= dataGrid_Clientes.CurrentRow.Cells["Telefono"].Value.ToString();
                textInfoCl.Text= dataGrid_Clientes.CurrentRow.Cells["Informacion"].Value.ToString();
                ID = dataGrid_Clientes.CurrentRow.Cells["IdCliente"].Value.ToString();
            }
            else { MessageBox.Show("Seleccione una fila"); }
           
        }
        private void btnguardar_Cl_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    CNcolmado.Registrar_Cliente(textNombreCl.Text, textTelefonoCl.Text, textInfoCl.Text);
                    MessageBox.Show("El cliente fue registro");
                    Tablaclientes();
                    panelAux_Clientes.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se registro correctamente porque" + ex);
                }
            }
            else
            {
                try
                {
                    CNcolmado.Editar_Cliente(textNombreCl.Text, textTelefonoCl.Text, textInfoCl.Text,ID);
                    MessageBox.Show("El cliente fue editado");
                    Tablaclientes();
                    panelAux_Clientes.Visible = false;
                    Editar = false;
                }
                catch (Exception ex) { MessageBox.Show("No se edito correctamente porque" + ex); }
            }
        }

        #endregion


    }
}
