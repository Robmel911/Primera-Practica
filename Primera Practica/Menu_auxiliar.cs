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
    // TODO: Agregar confirmación visual al reactivar un producto o agregar saldo a un cliente
    // TODO: Separar en dos formularios distintos: uno para productos y otro para clientes
    public partial class Menu_auxiliar : Form
    {
        CN_Producto CNproducto = new CN_Producto();
        CN_Colmado CNcolmado = new CN_Colmado();
        ValidacionNumero validaciones = new ValidacionNumero("Saldo",1,1000);
       
        CN_Auditoria auditoria = new CN_Auditoria();
        string ID;
        
        
        public Menu_auxiliar(string Tipo)
        {
          
            InitializeComponent();
            Panel_activarprod.Visible = false;
            Panel_Saldo.Visible = false;

            // Configurar la ventana según el tipo de operación
            if (Tipo == "Productos")
            {
                CargarDatosProductos();
                Panel_activarprod.Visible = true;
                this.Text = "Activar Productos";
            }
            else if (Tipo == "Clientes")
            {
                CargarDatosClientes();
                Panel_Saldo.Visible = true;
                Panel_activarprod.Visible = false;
                this.Text = "Agregar Saldo";
            }


        }
        // Método para limpiar los campos de texto
        private void LimpiarCampos(Label label)
        {
            label.Text = "";
        }

        #region Cargar productos desactivados
        // Cargar productos desactivados en el combo box
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
            if (cmbProductos.SelectedIndex == -1)
            {
                LimpiarCampos(lblNombreProducto);
                LimpiarCampos(lblPrecioProducto);
                LimpiarCampos(lblStockProducto);
                LimpiarCampos(lblDescripcionProducto);
                LimpiarCampos(lblCodigoProducto);
                return;
            }
            DataRowView fila = (DataRowView)cmbProductos.SelectedItem;
            lblNombreProducto.Text = fila["Nombre"].ToString();
            lblPrecioProducto.Text = "RD$ " + fila["Precio"].ToString();
            lblStockProducto.Text = fila["Stock"].ToString() + " unidades";
            lblDescripcionProducto.Text = fila["Descripcion"].ToString();
            lblCodigoProducto.Text = fila["Codigo"].ToString();
            ID = fila["IdProducto"].ToString();

        }
        // Reactivar producto seleccionado
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            errorProviderAux.Clear();
            if (cmbProductos.SelectedIndex == -1)
            {
                errorProviderAux.SetError(cmbProductos, "Debe seleccionar un Producto");
                return;
            }
            CNproducto.Reactivar_Producto(ID);
            MessageBox.Show("Producto reactivado exitosamente.");
            auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Reactivar producto - exitoso");
            CargarDatosProductos();
        }
        #endregion
        #region Registrar saldo
        // Cargar clientes activos
        private void CargarDatosClientes()
        {
            cmbClientes.DataSource = CNproducto.Mostrartabla_Clientes();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "IdCliente";
            cmbClientes.SelectedIndex = -1;
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar info del cliente seleccionado
            DataRowView fila = (DataRowView)cmbClientes.SelectedItem;
            // Si no se ha seleccionado ningún cliente, limpiar los campos 
            if (cmbClientes.SelectedIndex == -1)
            {
                LimpiarCampos(lblNombreCliente);
                LimpiarCampos(lblTelefonoCliente);
                LimpiarCampos(lblSaldoCliente);
                return;
            }
            lblNombreCliente.Text = fila["Nombre"].ToString();
            lblTelefonoCliente.Text = fila["Telefono"].ToString();
            lblSaldoCliente.Text = "RD$ " + fila["Saldo"].ToString();
            ID = fila["IdCliente"].ToString();


        }
        private void btnagregarSaldo_Click(object sender, EventArgs e)
        {
            // Validar campos
            errorProviderAux.Clear();
            // Validar que se haya seleccionado un cliente
            if (cmbClientes.SelectedIndex == -1)
            {
                errorProviderAux.SetError(cmbClientes, "Debe seleccionar un cliente.");
                return;
            }
            // Validar que el campo de saldo no esté vacío y sea un número válido
            if (!validaciones.Validar(txtSaldo.Text))
            {
                errorProviderAux.SetError(txtSaldo, validaciones.MostrarError());
                return;
            }
            // Agregar saldo al cliente
            CNcolmado.Agrgarsaldo_Cliente(txtSaldo.Text, ID);
            // Mostrar mensaje de éxito y preguntar si desea seguir en la ventana
            DialogResult salir = MessageBox.Show(@"Saldo agregado exitosamente. r\n\ Quieres seguir en esta ventana","Operacion Existosa",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            CargarDatosClientes();  
            if(salir == DialogResult.Yes) this.Close();
            else if(salir == DialogResult.No) return;
        }

        #endregion

        private void Menu_auxiliar_Load(object sender, EventArgs e)
        {

        }
    }
}
