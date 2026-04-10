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
    // TODO: Agregar búsqueda de producto por nombre en tiempo real al escribir en el combo
    // TODO: Implementar impresión de recibo/factura al confirmar la venta
    public partial class Menu_Ventas : Form
    {
        CN_Auditoria auditoria = new CN_Auditoria();
        CN_Colmado CNcolmado = new CN_Colmado();
        decimal totalVenta = 0;
        public Menu_Ventas()
        {
            InitializeComponent();
            CargarDatosVenta();
            cmbCliente.SelectedIndex = -1;
            EstiloDataGrid_Carrito();


        }
        private void EstiloDataGrid_Carrito()
        {
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToResizeRows = false;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.ReadOnly = true;

            // Encabezado
            dgvCarrito.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dgvCarrito.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCarrito.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCarrito.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCarrito.ColumnHeadersHeight = 40;
            dgvCarrito.EnableHeadersVisualStyles = false;

            // Filas
            dgvCarrito.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvCarrito.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgvCarrito.DefaultCellStyle.BackColor = Color.White;
            dgvCarrito.DefaultCellStyle.Padding = new Padding(5);
            dgvCarrito.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dgvCarrito.DefaultCellStyle.SelectionForeColor = Color.White;
            

            // Filas alternas
            dgvCarrito.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.Columns["colmado_IdProducto"].Visible = false;
            dgvCarrito.GridColor = Color.FromArgb(200, 230, 201);
            dgvCarrito.RowTemplate.Height = 35;
            dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }

 
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
            if (nudCantidad.Maximum > 0)
                nudCantidad.Value = 1;
            else
            {
                MessageBox.Show("Producto sin stock disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nudCantidad.Value = 0;
                cmbCliente.SelectedIndex = -1;
            }
        }

        // Agregar producto al carrito
        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {


            if (cmbProductos.SelectedItem == null ) return;

            DataRowView fila = (DataRowView)cmbProductos.SelectedItem;
            int cantidad = (int)nudCantidad.Value;
            decimal precio = Convert.ToDecimal(fila["Precio"]);
            decimal subtotal = precio * cantidad;
            int stock = Convert.ToInt32(fila["Stock"]);

            if (cantidad ==0 || stock ==0)
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
            string estado = "Completada";

            if (chkAsociarCliente.Checked && cmbCliente.SelectedItem != null)
                idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            else if (chkAsociarCliente.Checked && cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un cliente o desmarcar la opción de asociar cliente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbCredito.Checked)
            {
                if (idCliente == null)
                {
                    MessageBox.Show("Debes seleccionar un cliente para venta a crédito.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                estado = "Pendiente";
            }

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
                CNcolmado.RegistrarVenta(idCliente, carrito, totalVenta,estado);
                auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Registar Ventas - exitoso");
                MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarVenta();
            }
            catch (Exception ex)
            {
                auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Registrar Ventas - Fallido");
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

        private void rbContado_CheckedChanged(object sender, EventArgs e)
        {
            chkAsociarCliente.Enabled = true;
            cmbCliente.Enabled = chkAsociarCliente.Checked;
        }

        private void rbCredito_CheckedChanged(object sender, EventArgs e)
        {
            chkAsociarCliente.Checked = true;
            chkAsociarCliente.Enabled = false;  // obligatorio en crédito
            cmbCliente.Enabled = true;
        }

        private void chkAsociarCliente_CheckedChanged(object sender, EventArgs e)
        {
            cmbCliente.Enabled = chkAsociarCliente.Checked;
            if (!chkAsociarCliente.Checked)
                cmbCliente.SelectedIndex = -1;
        }
        private void txtBuscarCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCodigo.Text.Length >= 2)
            {
                cmbProductos.DataSource = CNcolmado.BuscarProducto(txtBuscarCodigo.Text);
                cmbProductos.DisplayMember = "Nombre";
                cmbProductos.ValueMember = "IdProducto";
            }
            else
            {
                CargarDatosVenta(); 
            }
        }
    }
}

