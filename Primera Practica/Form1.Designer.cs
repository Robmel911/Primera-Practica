namespace Primera_Practica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panelInicio = new System.Windows.Forms.Panel();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnreactivarProd = new System.Windows.Forms.Button();
            this.btnagregarProd = new System.Windows.Forms.Button();
            this.btneditarProd = new System.Windows.Forms.Button();
            this.btneliminarProd = new System.Windows.Forms.Button();
            this.panelAux_Productos = new System.Windows.Forms.Panel();
            this.TextCodigoProd = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textStockProd = new System.Windows.Forms.NumericUpDown();
            this.textMarcaProd = new System.Windows.Forms.ComboBox();
            this.textPrecioProd = new System.Windows.Forms.TextBox();
            this.textDescProd = new System.Windows.Forms.TextBox();
            this.textNombreProd = new System.Windows.Forms.TextBox();
            this.btnguardarProd = new System.Windows.Forms.Button();
            this.label_panelAux = new System.Windows.Forms.Label();
            this.dataGrid_Productos = new System.Windows.Forms.DataGridView();
            this.panelVentas = new System.Windows.Forms.Panel();
            this.btnVerHistorial = new System.Windows.Forms.Button();
            this.btnAnularVenta = new System.Windows.Forms.Button();
            this.dgvHistorialVentas = new System.Windows.Forms.DataGridView();
            this.btnRegistrar_venta = new System.Windows.Forms.Button();
            this.panelClientes = new System.Windows.Forms.Panel();
            this.btnRegistrarSaldo = new System.Windows.Forms.Button();
            this.btneliminar_Cl = new System.Windows.Forms.Button();
            this.btneditar_Cl = new System.Windows.Forms.Button();
            this.btnregistrar_Cl = new System.Windows.Forms.Button();
            this.panelAux_Clientes = new System.Windows.Forms.Panel();
            this.btnguardar_Cl = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textInfoCl = new System.Windows.Forms.RichTextBox();
            this.textTelefonoCl = new System.Windows.Forms.MaskedTextBox();
            this.textNombreCl = new System.Windows.Forms.TextBox();
            this.tituloauxCl = new System.Windows.Forms.Label();
            this.dataGrid_Clientes = new System.Windows.Forms.DataGridView();
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAprobarVenta = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.lblTotalDia = new System.Windows.Forms.Label();
            this.dgvVentasDelDia = new System.Windows.Forms.DataGridView();
            this.panelVentasdia = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btntop5 = new System.Windows.Forms.Button();
            this.panelTop5 = new System.Windows.Forms.Panel();
            this.dataGrid_Top5 = new System.Windows.Forms.DataGridView();
            this.panelLateral.SuspendLayout();
            this.panelInicio.SuspendLayout();
            this.panelProductos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelAux_Productos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textStockProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Productos)).BeginInit();
            this.panelVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).BeginInit();
            this.panelClientes.SuspendLayout();
            this.panelAux_Clientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Clientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasDelDia)).BeginInit();
            this.panelVentasdia.SuspendLayout();
            this.panelTop5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Top5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.DarkGreen;
            this.panelLateral.Controls.Add(this.btnClientes);
            this.panelLateral.Controls.Add(this.btnVentas);
            this.panelLateral.Controls.Add(this.btnProductos);
            this.panelLateral.Controls.Add(this.btnInicio);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(58, 734);
            this.panelLateral.TabIndex = 0;
            this.panelLateral.MouseEnter += new System.EventHandler(this.panelLateral_MouseEnter);
            this.panelLateral.MouseLeave += new System.EventHandler(this.panelLateral_MouseLeave);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.DarkGreen;
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(0, 150);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(58, 50);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "👤  Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            this.btnClientes.MouseEnter += new System.EventHandler(this.panelLateral_MouseEnter);
            this.btnClientes.MouseLeave += new System.EventHandler(this.panelLateral_MouseLeave);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.DarkGreen;
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.Location = new System.Drawing.Point(0, 100);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(58, 50);
            this.btnVentas.TabIndex = 2;
            this.btnVentas.Text = "🧾  Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            this.btnVentas.MouseEnter += new System.EventHandler(this.panelLateral_MouseEnter);
            this.btnVentas.MouseLeave += new System.EventHandler(this.panelLateral_MouseLeave);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.DarkGreen;
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(0, 50);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(58, 50);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "📦  Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            this.btnProductos.MouseEnter += new System.EventHandler(this.panelLateral_MouseEnter);
            this.btnProductos.MouseLeave += new System.EventHandler(this.panelLateral_MouseLeave);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.DarkGreen;
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(0, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(58, 50);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "🏠  Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            this.btnInicio.MouseEnter += new System.EventHandler(this.panelLateral_MouseEnter);
            this.btnInicio.MouseLeave += new System.EventHandler(this.panelLateral_MouseLeave);
            // 
            // panelInicio
            // 
            this.panelInicio.Controls.Add(this.btntop5);
            this.panelInicio.Controls.Add(this.panelTop5);
            this.panelInicio.Controls.Add(this.button1);
            this.panelInicio.Controls.Add(this.panelVentasdia);
            this.panelInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInicio.Location = new System.Drawing.Point(0, 0);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(1222, 734);
            this.panelInicio.TabIndex = 1;
            // 
            // panelProductos
            // 
            this.panelProductos.Controls.Add(this.panel1);
            this.panelProductos.Controls.Add(this.panelAux_Productos);
            this.panelProductos.Controls.Add(this.dataGrid_Productos);
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductos.Location = new System.Drawing.Point(0, 0);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(1222, 734);
            this.panelProductos.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnreactivarProd);
            this.panel1.Controls.Add(this.btnagregarProd);
            this.panel1.Controls.Add(this.btneditarProd);
            this.panel1.Controls.Add(this.btneliminarProd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 593);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 141);
            this.panel1.TabIndex = 8;
            // 
            // btnreactivarProd
            // 
            this.btnreactivarProd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnreactivarProd.Location = new System.Drawing.Point(687, 0);
            this.btnreactivarProd.Name = "btnreactivarProd";
            this.btnreactivarProd.Size = new System.Drawing.Size(229, 141);
            this.btnreactivarProd.TabIndex = 7;
            this.btnreactivarProd.Text = "Reactivar";
            this.btnreactivarProd.UseVisualStyleBackColor = true;
            this.btnreactivarProd.Click += new System.EventHandler(this.btnreactivarProd_Click);
            // 
            // btnagregarProd
            // 
            this.btnagregarProd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnagregarProd.Location = new System.Drawing.Point(464, 0);
            this.btnagregarProd.Name = "btnagregarProd";
            this.btnagregarProd.Size = new System.Drawing.Size(223, 141);
            this.btnagregarProd.TabIndex = 4;
            this.btnagregarProd.Text = "Agregar";
            this.btnagregarProd.UseVisualStyleBackColor = true;
            this.btnagregarProd.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btneditarProd
            // 
            this.btneditarProd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btneditarProd.Location = new System.Drawing.Point(236, 0);
            this.btneditarProd.Name = "btneditarProd";
            this.btneditarProd.Size = new System.Drawing.Size(228, 141);
            this.btneditarProd.TabIndex = 5;
            this.btneditarProd.Text = "Editar";
            this.btneditarProd.UseVisualStyleBackColor = true;
            this.btneditarProd.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // btneliminarProd
            // 
            this.btneliminarProd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btneliminarProd.Location = new System.Drawing.Point(0, 0);
            this.btneliminarProd.Name = "btneliminarProd";
            this.btneliminarProd.Size = new System.Drawing.Size(236, 141);
            this.btneliminarProd.TabIndex = 6;
            this.btneliminarProd.Text = "Eliminar";
            this.btneliminarProd.UseVisualStyleBackColor = true;
            this.btneliminarProd.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // panelAux_Productos
            // 
            this.panelAux_Productos.Controls.Add(this.TextCodigoProd);
            this.panelAux_Productos.Controls.Add(this.label1);
            this.panelAux_Productos.Controls.Add(this.btnSalir);
            this.panelAux_Productos.Controls.Add(this.label6);
            this.panelAux_Productos.Controls.Add(this.label5);
            this.panelAux_Productos.Controls.Add(this.label4);
            this.panelAux_Productos.Controls.Add(this.label3);
            this.panelAux_Productos.Controls.Add(this.label2);
            this.panelAux_Productos.Controls.Add(this.textStockProd);
            this.panelAux_Productos.Controls.Add(this.textMarcaProd);
            this.panelAux_Productos.Controls.Add(this.textPrecioProd);
            this.panelAux_Productos.Controls.Add(this.textDescProd);
            this.panelAux_Productos.Controls.Add(this.textNombreProd);
            this.panelAux_Productos.Controls.Add(this.btnguardarProd);
            this.panelAux_Productos.Controls.Add(this.label_panelAux);
            this.panelAux_Productos.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAux_Productos.Location = new System.Drawing.Point(987, 0);
            this.panelAux_Productos.Name = "panelAux_Productos";
            this.panelAux_Productos.Size = new System.Drawing.Size(235, 734);
            this.panelAux_Productos.TabIndex = 7;
            // 
            // TextCodigoProd
            // 
            this.TextCodigoProd.Location = new System.Drawing.Point(27, 569);
            this.TextCodigoProd.Mask = "aa-000";
            this.TextCodigoProd.Name = "TextCodigoProd";
            this.TextCodigoProd.Size = new System.Drawing.Size(100, 26);
            this.TextCodigoProd.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Codigo";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(13, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(31, 34);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre";
            // 
            // textStockProd
            // 
            this.textStockProd.Location = new System.Drawing.Point(23, 463);
            this.textStockProd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.textStockProd.Name = "textStockProd";
            this.textStockProd.Size = new System.Drawing.Size(176, 26);
            this.textStockProd.TabIndex = 7;
            // 
            // textMarcaProd
            // 
            this.textMarcaProd.FormattingEnabled = true;
            this.textMarcaProd.Location = new System.Drawing.Point(23, 272);
            this.textMarcaProd.Name = "textMarcaProd";
            this.textMarcaProd.Size = new System.Drawing.Size(176, 28);
            this.textMarcaProd.TabIndex = 6;
            // 
            // textPrecioProd
            // 
            this.textPrecioProd.Location = new System.Drawing.Point(23, 363);
            this.textPrecioProd.Name = "textPrecioProd";
            this.textPrecioProd.Size = new System.Drawing.Size(176, 26);
            this.textPrecioProd.TabIndex = 5;
            // 
            // textDescProd
            // 
            this.textDescProd.Location = new System.Drawing.Point(23, 174);
            this.textDescProd.Name = "textDescProd";
            this.textDescProd.Size = new System.Drawing.Size(176, 26);
            this.textDescProd.TabIndex = 3;
            // 
            // textNombreProd
            // 
            this.textNombreProd.Location = new System.Drawing.Point(23, 80);
            this.textNombreProd.Name = "textNombreProd";
            this.textNombreProd.Size = new System.Drawing.Size(176, 26);
            this.textNombreProd.TabIndex = 2;
            // 
            // btnguardarProd
            // 
            this.btnguardarProd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnguardarProd.Location = new System.Drawing.Point(0, 684);
            this.btnguardarProd.Name = "btnguardarProd";
            this.btnguardarProd.Size = new System.Drawing.Size(235, 50);
            this.btnguardarProd.TabIndex = 1;
            this.btnguardarProd.Text = "Guardar";
            this.btnguardarProd.UseVisualStyleBackColor = true;
            this.btnguardarProd.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // label_panelAux
            // 
            this.label_panelAux.AutoSize = true;
            this.label_panelAux.Location = new System.Drawing.Point(64, 13);
            this.label_panelAux.Name = "label_panelAux";
            this.label_panelAux.Size = new System.Drawing.Size(51, 20);
            this.label_panelAux.TabIndex = 0;
            this.label_panelAux.Text = "Titulo ";
            // 
            // dataGrid_Productos
            // 
            this.dataGrid_Productos.AllowUserToAddRows = false;
            this.dataGrid_Productos.AllowUserToDeleteRows = false;
            this.dataGrid_Productos.AllowUserToResizeColumns = false;
            this.dataGrid_Productos.AllowUserToResizeRows = false;
            this.dataGrid_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Productos.Location = new System.Drawing.Point(0, 80);
            this.dataGrid_Productos.Name = "dataGrid_Productos";
            this.dataGrid_Productos.ReadOnly = true;
            this.dataGrid_Productos.RowHeadersWidth = 62;
            this.dataGrid_Productos.RowTemplate.Height = 28;
            this.dataGrid_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid_Productos.Size = new System.Drawing.Size(953, 515);
            this.dataGrid_Productos.TabIndex = 1;
            // 
            // panelVentas
            // 
            this.panelVentas.Controls.Add(this.btnVerDetalle);
            this.panelVentas.Controls.Add(this.btnAprobarVenta);
            this.panelVentas.Controls.Add(this.btnVerHistorial);
            this.panelVentas.Controls.Add(this.btnAnularVenta);
            this.panelVentas.Controls.Add(this.dgvHistorialVentas);
            this.panelVentas.Controls.Add(this.btnRegistrar_venta);
            this.panelVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVentas.Location = new System.Drawing.Point(0, 0);
            this.panelVentas.Name = "panelVentas";
            this.panelVentas.Size = new System.Drawing.Size(1222, 734);
            this.panelVentas.TabIndex = 3;
            // 
            // btnVerHistorial
            // 
            this.btnVerHistorial.Location = new System.Drawing.Point(538, 552);
            this.btnVerHistorial.Name = "btnVerHistorial";
            this.btnVerHistorial.Size = new System.Drawing.Size(172, 95);
            this.btnVerHistorial.TabIndex = 3;
            this.btnVerHistorial.Text = "Mostrar historial";
            this.btnVerHistorial.UseVisualStyleBackColor = true;
            this.btnVerHistorial.Click += new System.EventHandler(this.btnVerHistorial_Click);
            // 
            // btnAnularVenta
            // 
            this.btnAnularVenta.Location = new System.Drawing.Point(141, 546);
            this.btnAnularVenta.Name = "btnAnularVenta";
            this.btnAnularVenta.Size = new System.Drawing.Size(186, 95);
            this.btnAnularVenta.TabIndex = 2;
            this.btnAnularVenta.Text = "Anular venta";
            this.btnAnularVenta.UseVisualStyleBackColor = true;
            this.btnAnularVenta.Click += new System.EventHandler(this.btnAnularVenta_Click);
            // 
            // dgvHistorialVentas
            // 
            this.dgvHistorialVentas.AllowUserToAddRows = false;
            this.dgvHistorialVentas.AllowUserToDeleteRows = false;
            this.dgvHistorialVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialVentas.Location = new System.Drawing.Point(39, 25);
            this.dgvHistorialVentas.Name = "dgvHistorialVentas";
            this.dgvHistorialVentas.RowHeadersWidth = 62;
            this.dgvHistorialVentas.RowTemplate.Height = 28;
            this.dgvHistorialVentas.Size = new System.Drawing.Size(1147, 504);
            this.dgvHistorialVentas.TabIndex = 1;
            // 
            // btnRegistrar_venta
            // 
            this.btnRegistrar_venta.Location = new System.Drawing.Point(945, 549);
            this.btnRegistrar_venta.Name = "btnRegistrar_venta";
            this.btnRegistrar_venta.Size = new System.Drawing.Size(264, 95);
            this.btnRegistrar_venta.TabIndex = 0;
            this.btnRegistrar_venta.Text = "Realizar Venta";
            this.btnRegistrar_venta.UseVisualStyleBackColor = true;
            this.btnRegistrar_venta.Click += new System.EventHandler(this.btnRegistrar_Venta_Click);
            // 
            // panelClientes
            // 
            this.panelClientes.Controls.Add(this.btnRegistrarSaldo);
            this.panelClientes.Controls.Add(this.btneliminar_Cl);
            this.panelClientes.Controls.Add(this.btneditar_Cl);
            this.panelClientes.Controls.Add(this.btnregistrar_Cl);
            this.panelClientes.Controls.Add(this.panelAux_Clientes);
            this.panelClientes.Controls.Add(this.dataGrid_Clientes);
            this.panelClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClientes.Location = new System.Drawing.Point(0, 0);
            this.panelClientes.Name = "panelClientes";
            this.panelClientes.Size = new System.Drawing.Size(1222, 734);
            this.panelClientes.TabIndex = 4;
            // 
            // btnRegistrarSaldo
            // 
            this.btnRegistrarSaldo.Location = new System.Drawing.Point(815, 647);
            this.btnRegistrarSaldo.Name = "btnRegistrarSaldo";
            this.btnRegistrarSaldo.Size = new System.Drawing.Size(124, 47);
            this.btnRegistrarSaldo.TabIndex = 5;
            this.btnRegistrarSaldo.Text = "Agregar Saldo";
            this.btnRegistrarSaldo.UseVisualStyleBackColor = true;
            this.btnRegistrarSaldo.Click += new System.EventHandler(this.btnRegistrarSaldo_Click);
            // 
            // btneliminar_Cl
            // 
            this.btneliminar_Cl.Location = new System.Drawing.Point(637, 653);
            this.btneliminar_Cl.Name = "btneliminar_Cl";
            this.btneliminar_Cl.Size = new System.Drawing.Size(124, 47);
            this.btneliminar_Cl.TabIndex = 4;
            this.btneliminar_Cl.Text = "Eliminar Cliente";
            this.btneliminar_Cl.UseVisualStyleBackColor = true;
            this.btneliminar_Cl.Click += new System.EventHandler(this.btneliminar_Cl_Click);
            // 
            // btneditar_Cl
            // 
            this.btneditar_Cl.Location = new System.Drawing.Point(482, 651);
            this.btneditar_Cl.Name = "btneditar_Cl";
            this.btneditar_Cl.Size = new System.Drawing.Size(88, 47);
            this.btneditar_Cl.TabIndex = 3;
            this.btneditar_Cl.Text = "Ediar Cliente";
            this.btneditar_Cl.UseVisualStyleBackColor = true;
            this.btneditar_Cl.Click += new System.EventHandler(this.btneditar_Cl_Click);
            // 
            // btnregistrar_Cl
            // 
            this.btnregistrar_Cl.Location = new System.Drawing.Point(294, 654);
            this.btnregistrar_Cl.Name = "btnregistrar_Cl";
            this.btnregistrar_Cl.Size = new System.Drawing.Size(105, 44);
            this.btnregistrar_Cl.TabIndex = 2;
            this.btnregistrar_Cl.Text = "Regisrar Cliente";
            this.btnregistrar_Cl.UseVisualStyleBackColor = true;
            this.btnregistrar_Cl.Click += new System.EventHandler(this.btnregistrar_Cl_Click);
            // 
            // panelAux_Clientes
            // 
            this.panelAux_Clientes.Controls.Add(this.btnguardar_Cl);
            this.panelAux_Clientes.Controls.Add(this.label9);
            this.panelAux_Clientes.Controls.Add(this.label8);
            this.panelAux_Clientes.Controls.Add(this.label7);
            this.panelAux_Clientes.Controls.Add(this.textInfoCl);
            this.panelAux_Clientes.Controls.Add(this.textTelefonoCl);
            this.panelAux_Clientes.Controls.Add(this.textNombreCl);
            this.panelAux_Clientes.Controls.Add(this.tituloauxCl);
            this.panelAux_Clientes.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAux_Clientes.Location = new System.Drawing.Point(987, 0);
            this.panelAux_Clientes.Name = "panelAux_Clientes";
            this.panelAux_Clientes.Size = new System.Drawing.Size(235, 734);
            this.panelAux_Clientes.TabIndex = 1;
            this.panelAux_Clientes.Visible = false;
            // 
            // btnguardar_Cl
            // 
            this.btnguardar_Cl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnguardar_Cl.Location = new System.Drawing.Point(0, 650);
            this.btnguardar_Cl.Name = "btnguardar_Cl";
            this.btnguardar_Cl.Size = new System.Drawing.Size(235, 84);
            this.btnguardar_Cl.TabIndex = 7;
            this.btnguardar_Cl.Text = "Guardar";
            this.btnguardar_Cl.UseVisualStyleBackColor = true;
            this.btnguardar_Cl.Click += new System.EventHandler(this.btnguardar_Cl_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Informacion ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Telefono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nombre";
            // 
            // textInfoCl
            // 
            this.textInfoCl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textInfoCl.Location = new System.Drawing.Point(22, 184);
            this.textInfoCl.Name = "textInfoCl";
            this.textInfoCl.Size = new System.Drawing.Size(177, 96);
            this.textInfoCl.TabIndex = 3;
            this.textInfoCl.Text = "Direccion, otros telefonos, familia,etc";
            // 
            // textTelefonoCl
            // 
            this.textTelefonoCl.Location = new System.Drawing.Point(22, 128);
            this.textTelefonoCl.Mask = "000-000-0000";
            this.textTelefonoCl.Name = "textTelefonoCl";
            this.textTelefonoCl.Size = new System.Drawing.Size(114, 26);
            this.textTelefonoCl.TabIndex = 2;
            // 
            // textNombreCl
            // 
            this.textNombreCl.Location = new System.Drawing.Point(22, 67);
            this.textNombreCl.Name = "textNombreCl";
            this.textNombreCl.Size = new System.Drawing.Size(100, 26);
            this.textNombreCl.TabIndex = 1;
            // 
            // tituloauxCl
            // 
            this.tituloauxCl.AutoSize = true;
            this.tituloauxCl.Location = new System.Drawing.Point(64, 13);
            this.tituloauxCl.Name = "tituloauxCl";
            this.tituloauxCl.Size = new System.Drawing.Size(51, 20);
            this.tituloauxCl.TabIndex = 0;
            this.tituloauxCl.Text = "label1";
            // 
            // dataGrid_Clientes
            // 
            this.dataGrid_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Clientes.Location = new System.Drawing.Point(12, 50);
            this.dataGrid_Clientes.Name = "dataGrid_Clientes";
            this.dataGrid_Clientes.ReadOnly = true;
            this.dataGrid_Clientes.RowHeadersWidth = 62;
            this.dataGrid_Clientes.Size = new System.Drawing.Size(896, 545);
            this.dataGrid_Clientes.TabIndex = 0;
            // 
            // timerMenu
            // 
            this.timerMenu.Interval = 30;
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAprobarVenta
            // 
            this.btnAprobarVenta.Location = new System.Drawing.Point(346, 549);
            this.btnAprobarVenta.Name = "btnAprobarVenta";
            this.btnAprobarVenta.Size = new System.Drawing.Size(169, 95);
            this.btnAprobarVenta.TabIndex = 4;
            this.btnAprobarVenta.Text = "AprobarVenta";
            this.btnAprobarVenta.UseVisualStyleBackColor = true;
            this.btnAprobarVenta.Click += new System.EventHandler(this.btnAprobarVenta_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(716, 552);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(205, 95);
            this.btnVerDetalle.TabIndex = 5;
            this.btnVerDetalle.Text = "Mostrar venta";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // lblTotalDia
            // 
            this.lblTotalDia.AutoSize = true;
            this.lblTotalDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDia.Location = new System.Drawing.Point(48, 372);
            this.lblTotalDia.Name = "lblTotalDia";
            this.lblTotalDia.Size = new System.Drawing.Size(148, 46);
            this.lblTotalDia.TabIndex = 0;
            this.lblTotalDia.Text = "label10";
            // 
            // dgvVentasDelDia
            // 
            this.dgvVentasDelDia.AllowUserToAddRows = false;
            this.dgvVentasDelDia.AllowUserToDeleteRows = false;
            this.dgvVentasDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasDelDia.Location = new System.Drawing.Point(34, 3);
            this.dgvVentasDelDia.Name = "dgvVentasDelDia";
            this.dgvVentasDelDia.ReadOnly = true;
            this.dgvVentasDelDia.RowHeadersWidth = 62;
            this.dgvVentasDelDia.RowTemplate.Height = 28;
            this.dgvVentasDelDia.Size = new System.Drawing.Size(516, 350);
            this.dgvVentasDelDia.TabIndex = 1;
            // 
            // panelVentasdia
            // 
            this.panelVentasdia.Controls.Add(this.dgvVentasDelDia);
            this.panelVentasdia.Controls.Add(this.lblTotalDia);
            this.panelVentasdia.Location = new System.Drawing.Point(551, 249);
            this.panelVentasdia.Name = "panelVentasdia";
            this.panelVentasdia.Size = new System.Drawing.Size(668, 482);
            this.panelVentasdia.TabIndex = 2;
            this.panelVentasdia.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ver Ventas de hoy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btntop5
            // 
            this.btntop5.Location = new System.Drawing.Point(160, 440);
            this.btntop5.Name = "btntop5";
            this.btntop5.Size = new System.Drawing.Size(152, 49);
            this.btntop5.TabIndex = 4;
            this.btntop5.Text = "Ver top 5 productos";
            this.btntop5.UseVisualStyleBackColor = true;
            this.btntop5.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelTop5
            // 
            this.panelTop5.Controls.Add(this.dataGrid_Top5);
            this.panelTop5.Location = new System.Drawing.Point(551, 249);
            this.panelTop5.Name = "panelTop5";
            this.panelTop5.Size = new System.Drawing.Size(668, 482);
            this.panelTop5.TabIndex = 3;
            this.panelTop5.Visible = false;
            // 
            // dataGrid_Top5
            // 
            this.dataGrid_Top5.AllowUserToAddRows = false;
            this.dataGrid_Top5.AllowUserToDeleteRows = false;
            this.dataGrid_Top5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Top5.Location = new System.Drawing.Point(34, 3);
            this.dataGrid_Top5.Name = "dataGrid_Top5";
            this.dataGrid_Top5.ReadOnly = true;
            this.dataGrid_Top5.RowHeadersWidth = 62;
            this.dataGrid_Top5.RowTemplate.Height = 28;
            this.dataGrid_Top5.Size = new System.Drawing.Size(570, 395);
            this.dataGrid_Top5.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 734);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelInicio);
            this.Controls.Add(this.panelClientes);
            this.Controls.Add(this.panelVentas);
            this.Controls.Add(this.panelProductos);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colmado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLateral.ResumeLayout(false);
            this.panelInicio.ResumeLayout(false);
            this.panelProductos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelAux_Productos.ResumeLayout(false);
            this.panelAux_Productos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textStockProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Productos)).EndInit();
            this.panelVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).EndInit();
            this.panelClientes.ResumeLayout(false);
            this.panelAux_Clientes.ResumeLayout(false);
            this.panelAux_Clientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Clientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasDelDia)).EndInit();
            this.panelVentasdia.ResumeLayout(false);
            this.panelVentasdia.PerformLayout();
            this.panelTop5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Top5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel panelInicio;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.Panel panelVentas;
        private System.Windows.Forms.Panel panelClientes;
        private System.Windows.Forms.Timer timerMenu;
        private System.Windows.Forms.DataGridView dataGrid_Productos;
        private System.Windows.Forms.Panel panelAux_Productos;
        private System.Windows.Forms.Button btneliminarProd;
        private System.Windows.Forms.Button btneditarProd;
        private System.Windows.Forms.Button btnagregarProd;
        private System.Windows.Forms.Button btnguardarProd;
        private System.Windows.Forms.Label label_panelAux;
        private System.Windows.Forms.TextBox textPrecioProd;
        private System.Windows.Forms.TextBox textDescProd;
        private System.Windows.Forms.TextBox textNombreProd;
        private System.Windows.Forms.NumericUpDown textStockProd;
        private System.Windows.Forms.ComboBox textMarcaProd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGrid_Clientes;
        private System.Windows.Forms.Panel panelAux_Clientes;
        private System.Windows.Forms.Button btneliminar_Cl;
        private System.Windows.Forms.Button btneditar_Cl;
        private System.Windows.Forms.Button btnregistrar_Cl;
        private System.Windows.Forms.MaskedTextBox textTelefonoCl;
        private System.Windows.Forms.TextBox textNombreCl;
        private System.Windows.Forms.Label tituloauxCl;
        private System.Windows.Forms.RichTextBox textInfoCl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnguardar_Cl;
        private System.Windows.Forms.Button btnRegistrar_venta;
        private System.Windows.Forms.Button btnAnularVenta;
        private System.Windows.Forms.DataGridView dgvHistorialVentas;
        private System.Windows.Forms.Button btnVerHistorial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreactivarProd;
        private System.Windows.Forms.Button btnRegistrarSaldo;
        private System.Windows.Forms.MaskedTextBox TextCodigoProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAprobarVenta;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.DataGridView dgvVentasDelDia;
        private System.Windows.Forms.Label lblTotalDia;
        private System.Windows.Forms.Panel panelVentasdia;
        private System.Windows.Forms.Button btntop5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelTop5;
        private System.Windows.Forms.DataGridView dataGrid_Top5;
    }
}

