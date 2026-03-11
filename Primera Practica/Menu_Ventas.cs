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
    public partial class Menu_Ventas : Form
    {
        CN_Colmado CNcolmado = new CN_Colmado();
        int idproducto;
        int idcliente;
        int cantidad;
        decimal totalVenta = 0;
        public Menu_Ventas()
        {
            InitializeComponent();
            CargarDatosVenta();
        }
        //para darle los datos a los combo box de productos y clientes
        private void CargarDatosVenta()
        {
            cmbProductos.DataSource = CNcolmado.ObtenerProductos_Venta();
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "IdProducto";

            cmbCliente.DataSource = CNcolmado.Mostrartabla_Clientes();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "IdCliente";
        }

        // Mostrar info del producto seleccionado
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem == null) return;

            DataRowView fila = (DataRowView)cmbProductos.SelectedItem;
            lblNombreProducto.Text = fila["Nombre"].ToString();
            lblPrecioProducto.Text = "RD$ " + fila["Precio"].ToString();
            lblStockProducto.Text = fila["Stock"].ToString() + " unidades";
            nudCantidad.Maximum = Convert.ToInt32(fila["Stock"]);
            nudCantidad.Value = 1;
        }

        // Agregar producto al carrito
        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
           

            if (cmbProductos.SelectedItem == null) return;

            DataRowView fila = (DataRowView)cmbProductos.SelectedItem;
            int cantidad = (int)nudCantidad.Value;
            decimal precio = Convert.ToDecimal(fila["Precio"]);
            decimal subtotal = precio * cantidad;
            int stock = Convert.ToInt32(fila["Stock"]);

            if (cantidad > stock)
            {
                MessageBox.Show("Stock insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Buscar si el producto ya está en el carrito
            foreach (DataGridViewRow filas in dgvCarrito.Rows)
            {
                if (filas.Cells["colmado_IdProducto"].Value.ToString() == fila["IdProducto"].ToString())
                {
                    DialogResult respuesta = MessageBox.Show(
                        "Este producto ya está en el carrito. ¿Desea sobreescribir la cantidad?",
                        "Producto repetido",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        filas.Cells["colmado_Cantidad"].Value = cantidad;
                        filas.Cells["colmado_Subtotal"].Value = subtotal;
                        // Recalcular total desde cero
                        RecalcularTotal();
                    }
                    return;
                }
            }
            // Agregar fila al carrito
            dgvCarrito.Rows.Add(
                fila["IdProducto"],
                fila["Nombre"],
                cantidad,
                precio,
                subtotal
            );

            // Actualizar total
            totalVenta += subtotal;
            lblTotal.Text = "Total: RD$ " + totalVenta.ToString("0.00");
        }
    
            private void RecalcularTotal()
        {
            totalVenta = 0;
            foreach (DataGridViewRow fila in dgvCarrito.Rows)
                totalVenta += Convert.ToDecimal(fila.Cells["colmado_Subtotal"].Value);

            lblTotal.Text = "Total: RD$ " + totalVenta.ToString("0.00");
        }

        // Confirmar venta
        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? idCliente = null;
            if (rbCredito.Checked && cmbCliente.SelectedItem != null)
                idCliente = Convert.ToInt32(cmbCliente.SelectedValue);

            // Convertir carrito a DataTable
            DataTable carrito = new DataTable();
            carrito.Columns.Add("IdProducto", typeof(int));
            carrito.Columns.Add("Nombre", typeof(string));
            carrito.Columns.Add("Cantidad", typeof(int));
            carrito.Columns.Add("Precio", typeof(decimal));

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                carrito.Rows.Add(
                    fila.Cells["colmado_IdProducto"].Value,
                    fila.Cells["colmado_Nombre"].Value,
                    fila.Cells["colmado_Cantidad"].Value,
                    fila.Cells["colmado_Precio"].Value
                );
            }

            try
            {
                CNcolmado.RegistrarVenta(idCliente, carrito, totalVenta);
                MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0) return;

            decimal subtotal = Convert.ToDecimal(dgvCarrito.SelectedRows[0].Cells["colmado_Subtotal"].Value);
            totalVenta -= subtotal;
            lblTotal.Text = "Total: RD$ " + totalVenta.ToString("0.00");

            dgvCarrito.Rows.Remove(dgvCarrito.SelectedRows[0]);
        }
        // Limpiar carrito
        private void LimpiarVenta()
        {
            dgvCarrito.Rows.Clear();
            totalVenta = 0;
            lblTotal.Text = "Total: RD$ 0.00";
            nudCantidad.Value = 1;
            CargarDatosVenta();
        }

        // Cancelar venta
        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }
       
      

    

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
