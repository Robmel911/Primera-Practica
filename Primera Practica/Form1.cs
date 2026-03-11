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
        private Menu_Ventas menuVentas = new Menu_Ventas();
        private const int MENU_COLAPSADO = 35;
        private const int MENU_EXPANDIDO = 200;
        private const int VELOCIDAD_ANIM = 30;
        private bool menuExpandiendo = false;
        private bool Editar = false;
        private string ID;
        private bool RealizarAct=false;
        
        public Form1()
        {
            InitializeComponent();
            MostrarPanel(panelInicio);
            MarcarBotonActivo(btnInicio);
            Estilotabla_productos();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Tablaproductos();
            Tablaclientes();

        }

        private void VentanaEmergente(string Mensaje,string titulo)
        {
            MessageBox.Show(Mensaje,titulo,MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
        private bool VentanaConfirmacion()
        {
            RealizarAct = false;
           DialogResult Resultado = MessageBox.Show("Esta seguro", "Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado==DialogResult.Yes )
            {
                return true;
            }
            else return false;
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
        // Fuentes de la combobox

        public void Estilotabla_productos()
        {
            // Header verde oscuro
            dataGrid_Productos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dataGrid_Productos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid_Productos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGrid_Productos.EnableHeadersVisualStyles = false;
            dataGrid_Productos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Filas
            dataGrid_Productos.RowsDefaultCellStyle.BackColor = Color.White;
            dataGrid_Productos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dataGrid_Productos.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Bordes y fondo
            dataGrid_Productos.BorderStyle = BorderStyle.None;
            dataGrid_Productos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrid_Productos.GridColor = Color.LightGray;
            dataGrid_Productos.BackgroundColor = Color.White;

            // Selección
            dataGrid_Productos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 214, 167);
            dataGrid_Productos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGrid_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Otros
            dataGrid_Productos.RowHeadersVisible = false;
            dataGrid_Productos.Font = new Font("Segoe UI", 9);
        }
        public void DataCombobox_Productos(string campo)
        {
                CN_Colmado TablaProd = new CN_Colmado();
                textMarcaProd.DataSource = TablaProd.Obtenerdatos_Producto();
                textMarcaProd.DisplayMember = campo;
                textMarcaProd.ValueMember = campo;   
        }
        private void Limpiartextos_Productos()
        {
            textNombreProd.Clear(); textDescProd.Clear(); textMarcaProd.Text = ""; textPrecioProd.Clear(); textStockProd.Text = "0";
        }
        private void Tablaproductos()
        {
            dataGrid_Productos.DataSource = CNcolmado.Obtenerdatos_Producto();
            DataCombobox_Productos("Marca");
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
                    VentanaEmergente("Se registro correctamente", "Exito");
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
                    RealizarAct=VentanaConfirmacion();
                    if (RealizarAct == true)
                    {
                        CNcolmado.Editar_producto(textNombreProd.Text, textDescProd.Text, textMarcaProd.Text, textPrecioProd.Text, textStockProd.Text, ID);
                        VentanaEmergente("Se edito correctamente", "Exito");
                        Tablaproductos();
                        panelAux_Productos.Visible = false;
                        Editar = false;
                    }
                    else {panelAux_Productos.Visible = false; Editar = false;}
                }
                catch (Exception ex) { MessageBox.Show("No se edito correctamente porque" + ex); }
            }
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            Editar = false;
            panelAux_Productos.Visible = true;
            label_panelAux.Text = "Agregar Producto";
            //limpiar todas las text box
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
            else { MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if(dataGrid_Productos.SelectedRows.Count > 0)
            {
                
                ID = dataGrid_Productos.CurrentRow.Cells["IdProducto"].Value.ToString();
                RealizarAct=VentanaConfirmacion();
                if (RealizarAct == true)
                {
                    CNcolmado.Eliminar_Producto(ID);
                    VentanaEmergente("Se elimino correctamente", "Exito");
                    Tablaproductos();
                }
                
            }
            else { MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        #endregion
        #region Panel Clientes
        private void Tablaclientes()
        {
            dataGrid_Clientes.DataSource = CNcolmado.Mostrartabla_Clientes();
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
            else { VentanaEmergente("Seleccione una fila", "Error"); }
           
        }
        private void btnguardar_Cl_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    CNcolmado.Registrar_Cliente(textNombreCl.Text, textTelefonoCl.Text, textInfoCl.Text);
                    VentanaEmergente("Se registro correctamente", "Exito");
                    Tablaclientes();
                    panelAux_Clientes.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se registro correctamente porque" + ex, "Error");
                }
            }
            else
            {
                try
                {
                    RealizarAct = VentanaConfirmacion();
                    if (RealizarAct == true)
                    {
                        CNcolmado.Editar_Cliente(textNombreCl.Text, textTelefonoCl.Text, textInfoCl.Text, ID);
                        MessageBox.Show("El cliente fue editado");
                        Tablaclientes();
                        panelAux_Clientes.Visible = false;
                        Editar = false;
                    }
                    else { panelAux_Clientes.Visible = false; Editar = false; }
                }
                catch (Exception ex) { MessageBox.Show("No se edito correctamente porque" + ex, "Error"); }
            }

        }
        private void btneliminar_Cl_Click(object sender, EventArgs e)
        {
            
            if (dataGrid_Clientes.SelectedRows.Count > 0)
            {
                RealizarAct = VentanaConfirmacion();
                ID = dataGrid_Clientes.CurrentRow.Cells["IdCliente"].Value.ToString();
                CNcolmado.Desactivar_Cliente(ID);
                Tablaclientes();
                panelAux_Clientes.Visible = false;
            }
            else { VentanaEmergente("Seleccione una fila", "Error"); }
        }


        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            menuVentas.Show();
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            dgvHistorialVentas.DataSource = CNcolmado.HistorialVentas();
        }
        private void btnAnularVenta_Click(object sender, EventArgs e)
        {
            if (dgvHistorialVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una venta primero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string estado = dgvHistorialVentas.SelectedRows[0].Cells["Estado"].Value.ToString();
            if (estado == "Anulada")
            {
                MessageBox.Show("Esta venta ya está anulada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro que deseas anular esta venta?",
                "Confirmar anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                string idVenta = dgvHistorialVentas.SelectedRows[0].Cells["IdVenta"].Value.ToString();
               CNcolmado.AnularVenta(idVenta);
                MessageBox.Show("Venta anulada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnVerHistorial_Click(sender, e); // recargar historial
            }
        }
    }
    #region Panel Ventas

    #endregion


}
