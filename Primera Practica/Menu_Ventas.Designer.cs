namespace Primera_Practica
{
    partial class Menu_Ventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Ventas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAsociarCliente = new System.Windows.Forms.CheckBox();
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.btnConfirmarVenta = new System.Windows.Forms.Button();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbContado = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStockProducto = new System.Windows.Forms.Label();
            this.lblPrecioProducto = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.colmado_IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmado_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmado_Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmado_Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmado_Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcodigo = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAsociarCliente);
            this.panel1.Controls.Add(this.btnCancelarVenta);
            this.panel1.Controls.Add(this.btnConfirmarVenta);
            this.panel1.Controls.Add(this.rbCredito);
            this.panel1.Controls.Add(this.rbContado);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 465);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 113);
            this.panel1.TabIndex = 0;
            // 
            // chkAsociarCliente
            // 
            this.chkAsociarCliente.AutoSize = true;
            this.chkAsociarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAsociarCliente.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkAsociarCliente.Location = new System.Drawing.Point(83, 57);
            this.chkAsociarCliente.Name = "chkAsociarCliente";
            this.chkAsociarCliente.Size = new System.Drawing.Size(156, 24);
            this.chkAsociarCliente.TabIndex = 14;
            this.chkAsociarCliente.Text = "Venta a cliente";
            this.chkAsociarCliente.UseVisualStyleBackColor = true;
            this.chkAsociarCliente.CheckedChanged += new System.EventHandler(this.chkAsociarCliente_CheckedChanged);
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenta.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCancelarVenta.Location = new System.Drawing.Point(517, 63);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(104, 32);
            this.btnCancelarVenta.TabIndex = 11;
            this.btnCancelarVenta.Text = "Cancelar";
            this.btnCancelarVenta.UseVisualStyleBackColor = true;
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // btnConfirmarVenta
            // 
            this.btnConfirmarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarVenta.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnConfirmarVenta.Location = new System.Drawing.Point(517, 25);
            this.btnConfirmarVenta.Name = "btnConfirmarVenta";
            this.btnConfirmarVenta.Size = new System.Drawing.Size(104, 32);
            this.btnConfirmarVenta.TabIndex = 11;
            this.btnConfirmarVenta.Text = "Confirmar";
            this.btnConfirmarVenta.UseVisualStyleBackColor = true;
            this.btnConfirmarVenta.Click += new System.EventHandler(this.btnConfirmarVenta_Click);
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredito.ForeColor = System.Drawing.Color.DarkGreen;
            this.rbCredito.Location = new System.Drawing.Point(298, 75);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(79, 24);
            this.rbCredito.TabIndex = 13;
            this.rbCredito.TabStop = true;
            this.rbCredito.Text = "Fiado";
            this.rbCredito.UseVisualStyleBackColor = true;
            this.rbCredito.CheckedChanged += new System.EventHandler(this.rbCredito_CheckedChanged);
            // 
            // rbContado
            // 
            this.rbContado.AutoSize = true;
            this.rbContado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContado.ForeColor = System.Drawing.Color.DarkGreen;
            this.rbContado.Location = new System.Drawing.Point(298, 45);
            this.rbContado.Name = "rbContado";
            this.rbContado.Size = new System.Drawing.Size(123, 24);
            this.rbContado.TabIndex = 12;
            this.rbContado.TabStop = true;
            this.rbContado.Text = "Al Contado";
            this.rbContado.UseVisualStyleBackColor = true;
            this.rbContado.CheckedChanged += new System.EventHandler(this.rbContado_CheckedChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotal.Location = new System.Drawing.Point(297, 22);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(135, 20);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total: RD$ 0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGreen;
            this.label9.Location = new System.Drawing.Point(32, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Enabled = false;
            this.cmbCliente.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(107, 22);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(121, 28);
            this.cmbCliente.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtcodigo);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.nudCantidad);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblStockProducto);
            this.panel2.Controls.Add(this.lblPrecioProducto);
            this.panel2.Controls.Add(this.lblNombreProducto);
            this.panel2.Controls.Add(this.btnAgregarCarrito);
            this.panel2.Controls.Add(this.cmbProductos);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 215);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(342, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Codigo:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(97, 175);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 26);
            this.nudCantidad.TabIndex = 10;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(9, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Cantidad:";
            // 
            // lblStockProducto
            // 
            this.lblStockProducto.AutoSize = true;
            this.lblStockProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblStockProducto.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStockProducto.Location = new System.Drawing.Point(114, 136);
            this.lblStockProducto.Name = "lblStockProducto";
            this.lblStockProducto.Size = new System.Drawing.Size(14, 20);
            this.lblStockProducto.TabIndex = 8;
            this.lblStockProducto.Text = "-";
            // 
            // lblPrecioProducto
            // 
            this.lblPrecioProducto.AutoSize = true;
            this.lblPrecioProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecioProducto.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPrecioProducto.Location = new System.Drawing.Point(114, 98);
            this.lblPrecioProducto.Name = "lblPrecioProducto";
            this.lblPrecioProducto.Size = new System.Drawing.Size(14, 20);
            this.lblPrecioProducto.TabIndex = 7;
            this.lblPrecioProducto.Text = "-";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreProducto.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNombreProducto.Location = new System.Drawing.Point(114, 62);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(14, 20);
            this.lblNombreProducto.TabIndex = 6;
            this.lblNombreProducto.Text = "-";
            // 
            // btnAgregarCarrito
            // 
            this.btnAgregarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCarrito.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAgregarCarrito.Location = new System.Drawing.Point(278, 177);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(134, 32);
            this.btnAgregarCarrito.TabIndex = 5;
            this.btnAgregarCarrito.Text = "+ Agregar";
            this.btnAgregarCarrito.UseVisualStyleBackColor = true;
            this.btnAgregarCarrito.Click += new System.EventHandler(this.btnAgregarCarrito_Click);
            // 
            // cmbProductos
            // 
            this.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductos.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(102, 14);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(121, 28);
            this.cmbProductos.TabIndex = 4;
            this.cmbProductos.SelectedIndexChanged += new System.EventHandler(this.cmbProductos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stock:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto:";
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colmado_IdProducto,
            this.colmado_Nombre,
            this.colmado_Cantidad,
            this.colmado_Precio,
            this.colmado_Subtotal});
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.Location = new System.Drawing.Point(0, 215);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersWidth = 62;
            this.dgvCarrito.RowTemplate.Height = 28;
            this.dgvCarrito.Size = new System.Drawing.Size(633, 250);
            this.dgvCarrito.TabIndex = 2;
            // 
            // colmado_IdProducto
            // 
            this.colmado_IdProducto.HeaderText = "IdProducto";
            this.colmado_IdProducto.MinimumWidth = 8;
            this.colmado_IdProducto.Name = "colmado_IdProducto";
            this.colmado_IdProducto.ReadOnly = true;
            this.colmado_IdProducto.Width = 150;
            // 
            // colmado_Nombre
            // 
            this.colmado_Nombre.HeaderText = "Nombre";
            this.colmado_Nombre.MinimumWidth = 8;
            this.colmado_Nombre.Name = "colmado_Nombre";
            this.colmado_Nombre.ReadOnly = true;
            this.colmado_Nombre.Width = 150;
            // 
            // colmado_Cantidad
            // 
            this.colmado_Cantidad.HeaderText = "Cantidad";
            this.colmado_Cantidad.MinimumWidth = 8;
            this.colmado_Cantidad.Name = "colmado_Cantidad";
            this.colmado_Cantidad.ReadOnly = true;
            this.colmado_Cantidad.Width = 150;
            // 
            // colmado_Precio
            // 
            this.colmado_Precio.HeaderText = "Precio";
            this.colmado_Precio.MinimumWidth = 8;
            this.colmado_Precio.Name = "colmado_Precio";
            this.colmado_Precio.ReadOnly = true;
            this.colmado_Precio.Width = 150;
            // 
            // colmado_Subtotal
            // 
            this.colmado_Subtotal.HeaderText = "Subtotal";
            this.colmado_Subtotal.MinimumWidth = 8;
            this.colmado_Subtotal.Name = "colmado_Subtotal";
            this.colmado_Subtotal.ReadOnly = true;
            this.colmado_Subtotal.Width = 150;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(418, 14);
            this.txtcodigo.Mask = "aa-000";
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 26);
            this.txtcodigo.TabIndex = 13;
            this.txtcodigo.TextChanged += new System.EventHandler(this.txtBuscarCodigo_TextChanged);
            // 
            // Menu_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 578);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu_Ventas";
            this.Text = "Ventas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStockProducto;
        private System.Windows.Forms.Label lblPrecioProducto;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.RadioButton rbContado;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.Button btnConfirmarVenta;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmado_IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmado_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmado_Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmado_Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmado_Subtotal;
        private System.Windows.Forms.CheckBox chkAsociarCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtcodigo;
    }
}