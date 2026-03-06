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
            this.panelAux = new System.Windows.Forms.Panel();
            this.textStock = new System.Windows.Forms.NumericUpDown();
            this.textMarca = new System.Windows.Forms.ComboBox();
            this.textPrecio = new System.Windows.Forms.TextBox();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.btnguardar = new System.Windows.Forms.Button();
            this.label_panelAux = new System.Windows.Forms.Label();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btneditar = new System.Windows.Forms.Button();
            this.btnagregar = new System.Windows.Forms.Button();
            this.dataGrid_Productos = new System.Windows.Forms.DataGridView();
            this.panelVentas = new System.Windows.Forms.Panel();
            this.panelClientes = new System.Windows.Forms.Panel();
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelLateral.SuspendLayout();
            this.panelProductos.SuspendLayout();
            this.panelAux.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Productos)).BeginInit();
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
            this.panelLateral.Size = new System.Drawing.Size(83, 651);
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
            this.btnClientes.Size = new System.Drawing.Size(83, 50);
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
            this.btnVentas.Size = new System.Drawing.Size(83, 50);
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
            this.btnProductos.Size = new System.Drawing.Size(83, 50);
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
            this.btnInicio.Size = new System.Drawing.Size(83, 50);
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
            this.panelInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInicio.Location = new System.Drawing.Point(0, 0);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(1091, 651);
            this.panelInicio.TabIndex = 1;
            // 
            // panelProductos
            // 
            this.panelProductos.Controls.Add(this.panelAux);
            this.panelProductos.Controls.Add(this.btneliminar);
            this.panelProductos.Controls.Add(this.btneditar);
            this.panelProductos.Controls.Add(this.btnagregar);
            this.panelProductos.Controls.Add(this.dataGrid_Productos);
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductos.Location = new System.Drawing.Point(0, 0);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(1091, 651);
            this.panelProductos.TabIndex = 2;
            // 
            // panelAux
            // 
            this.panelAux.Controls.Add(this.btnSalir);
            this.panelAux.Controls.Add(this.label6);
            this.panelAux.Controls.Add(this.label5);
            this.panelAux.Controls.Add(this.label4);
            this.panelAux.Controls.Add(this.label3);
            this.panelAux.Controls.Add(this.label2);
            this.panelAux.Controls.Add(this.textStock);
            this.panelAux.Controls.Add(this.textMarca);
            this.panelAux.Controls.Add(this.textPrecio);
            this.panelAux.Controls.Add(this.textDesc);
            this.panelAux.Controls.Add(this.textNombre);
            this.panelAux.Controls.Add(this.btnguardar);
            this.panelAux.Controls.Add(this.label_panelAux);
            this.panelAux.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAux.Location = new System.Drawing.Point(856, 0);
            this.panelAux.Name = "panelAux";
            this.panelAux.Size = new System.Drawing.Size(235, 651);
            this.panelAux.TabIndex = 7;
            // 
            // textStock
            // 
            this.textStock.Location = new System.Drawing.Point(23, 463);
            this.textStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.textStock.Name = "textStock";
            this.textStock.Size = new System.Drawing.Size(176, 26);
            this.textStock.TabIndex = 7;
            // 
            // textMarca
            // 
            this.textMarca.FormattingEnabled = true;
            this.textMarca.Location = new System.Drawing.Point(23, 272);
            this.textMarca.Name = "textMarca";
            this.textMarca.Size = new System.Drawing.Size(176, 28);
            this.textMarca.TabIndex = 6;
            // 
            // textPrecio
            // 
            this.textPrecio.Location = new System.Drawing.Point(23, 363);
            this.textPrecio.Name = "textPrecio";
            this.textPrecio.Size = new System.Drawing.Size(176, 26);
            this.textPrecio.TabIndex = 5;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(23, 174);
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(176, 26);
            this.textDesc.TabIndex = 3;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(23, 80);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(176, 26);
            this.textNombre.TabIndex = 2;
            // 
            // btnguardar
            // 
            this.btnguardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnguardar.Location = new System.Drawing.Point(0, 601);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(235, 50);
            this.btnguardar.TabIndex = 1;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // label_panelAux
            // 
            this.label_panelAux.AutoSize = true;
            this.label_panelAux.Location = new System.Drawing.Point(64, 13);
            this.label_panelAux.Name = "label_panelAux";
            this.label_panelAux.Size = new System.Drawing.Size(51, 20);
            this.label_panelAux.TabIndex = 0;
            this.label_panelAux.Text = "label1";
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(586, 564);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(99, 39);
            this.btneliminar.TabIndex = 6;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btneditar
            // 
            this.btneditar.Location = new System.Drawing.Point(405, 565);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(91, 38);
            this.btneditar.TabIndex = 5;
            this.btneditar.Text = "Editar";
            this.btneditar.UseVisualStyleBackColor = true;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(215, 565);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(86, 38);
            this.btnagregar.TabIndex = 4;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // dataGrid_Productos
            // 
            this.dataGrid_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Productos.Location = new System.Drawing.Point(6, 36);
            this.dataGrid_Productos.Name = "dataGrid_Productos";
            this.dataGrid_Productos.RowHeadersWidth = 62;
            this.dataGrid_Productos.RowTemplate.Height = 28;
            this.dataGrid_Productos.Size = new System.Drawing.Size(752, 464);
            this.dataGrid_Productos.TabIndex = 1;
            // 
            // panelVentas
            // 
            this.panelVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVentas.Location = new System.Drawing.Point(0, 0);
            this.panelVentas.Name = "panelVentas";
            this.panelVentas.Size = new System.Drawing.Size(1091, 651);
            this.panelVentas.TabIndex = 3;
            // 
            // panelClientes
            // 
            this.panelClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClientes.Location = new System.Drawing.Point(0, 0);
            this.panelClientes.Name = "panelClientes";
            this.panelClientes.Size = new System.Drawing.Size(1091, 651);
            this.panelClientes.TabIndex = 4;
            // 
            // timerMenu
            // 
            this.timerMenu.Interval = 30;
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Descripción";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Precio";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 651);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.panelInicio);
            this.Controls.Add(this.panelClientes);
            this.Controls.Add(this.panelVentas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLateral.ResumeLayout(false);
            this.panelProductos.ResumeLayout(false);
            this.panelAux.ResumeLayout(false);
            this.panelAux.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Productos)).EndInit();
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
        private System.Windows.Forms.Panel panelAux;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btneditar;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Label label_panelAux;
        private System.Windows.Forms.TextBox textPrecio;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.NumericUpDown textStock;
        private System.Windows.Forms.ComboBox textMarca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
    }
}

