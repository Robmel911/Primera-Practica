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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelVentas = new System.Windows.Forms.Panel();
            this.panelClientes = new System.Windows.Forms.Panel();
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.panelLateral.SuspendLayout();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panelLateral.Size = new System.Drawing.Size(83, 450);
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
            this.panelInicio.Location = new System.Drawing.Point(83, 0);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(717, 450);
            this.panelInicio.TabIndex = 1;
            // 
            // panelProductos
            // 
            this.panelProductos.Controls.Add(this.dataGridView1);
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductos.Location = new System.Drawing.Point(83, 0);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(717, 450);
            this.panelProductos.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(480, 339);
            this.dataGridView1.TabIndex = 1;
            // 
            // panelVentas
            // 
            this.panelVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVentas.Location = new System.Drawing.Point(0, 0);
            this.panelVentas.Name = "panelVentas";
            this.panelVentas.Size = new System.Drawing.Size(800, 450);
            this.panelVentas.TabIndex = 3;
            // 
            // panelClientes
            // 
            this.panelClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClientes.Location = new System.Drawing.Point(0, 0);
            this.panelClientes.Name = "panelClientes";
            this.panelClientes.Size = new System.Drawing.Size(800, 450);
            this.panelClientes.TabIndex = 4;
            // 
            // timerMenu
            // 
            this.timerMenu.Interval = 30;
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.panelInicio);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelClientes);
            this.Controls.Add(this.panelVentas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelLateral.ResumeLayout(false);
            this.panelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;

    


    }
}

