using CapaNegocios;
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
    public partial class Menu_auxiliar : Form
    {
        CN_Producto CNproducto = new CN_Producto();
        CN_Colmado CNcolmado = new CN_Colmado();
        CN_Auditoria auditoria = new CN_Auditoria();
        string ID;
        
        
        public Menu_auxiliar(bool productos)
        {
          
            InitializeComponent();
            Panel_activarprod.Visible = false;
            Panel_Saldo.Visible = false;
           
            
            if (productos == true)
            {
                CargarDatosProductos();
                Panel_activarprod.Visible = true;
            }
            else if (productos == false)
            {
                CargarDatosClientes();
                Panel_Saldo.Visible = true;
                Panel_activarprod.Visible = false;
            }


        }
        #region Cargar productos desactivados
        private void CargarDatosProductos()
        {
            cmbProductos.DataSource = CNproducto.ObtenerProductosdesactivados();
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "IdProducto";
            cmbProductos.SelectedIndex = -1;


        }

        // Mostrar info del producto seleccionado
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem == null) return;


            DataRowView fila = (DataRowView)cmbProductos.SelectedItem;
            lblNombreProducto.Text = fila["Nombre"].ToString();
            lblPrecioProducto.Text = "RD$ " + fila["Precio"].ToString();
            lblStockProducto.Text = fila["Stock"].ToString() + " unidades";
            lblDescripcionProducto.Text = fila["Descripcion"].ToString();
            lblCodigoProducto.Text = fila["Codigo"].ToString();
            ID = fila["IdProducto"].ToString();

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            CNproducto.Reactivar_Producto(ID);
            MessageBox.Show("Producto reactivado exitosamente.");
            auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Reactivar producto - exitoso");
            CargarDatosProductos();
        }
        #endregion
        #region Registrar saldo
        private void CargarDatosClientes()
        {
            cmbClientes.DataSource = CNproducto.Mostrartabla_Clientes();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "IdCliente";
            cmbClientes.SelectedIndex = -1;
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem == null) return;

            DataRowView fila = (DataRowView)cmbClientes.SelectedItem;
            lblNombreCliente.Text = fila["Nombre"].ToString();
            lblTelefonoCliente.Text = fila["Telefono"].ToString();
            lblSaldoCliente.Text = "RD$ " + fila["Saldo"].ToString();
            ID = fila["IdCliente"].ToString();

        }
        private void btnagregarSaldo_Click(object sender, EventArgs e)
        {
            CNproducto.Agrgarsaldo_Cliente(txtSaldo.Text, ID);
            auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Agregar Saldo - exitoso");
        }

        #endregion

        private void Menu_auxiliar_Load(object sender, EventArgs e)
        {

        }
    }
}
