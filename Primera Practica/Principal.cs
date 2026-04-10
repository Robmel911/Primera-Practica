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
    // TODO: Agregar control de permisos por rol (Admin vs Empleado) para habilitar/deshabilitar secciones
    public partial class Principal : Form
    {
        private CN_Auditoria auditoria = new CN_Auditoria();
        private CN_Colmado CNcolmado = new CN_Colmado();
        private CN_Clientes CNclientes = new CN_Clientes();
        private CN_Producto CNproducto = new CN_Producto();
        private CN_Usuarios CNusuarios = new CN_Usuarios();
        private Menu_Ventas menuVentas = new Menu_Ventas();
        private Validaciones validaciones = new Validaciones();
        private Menu_auxiliar menuAuxiliar = new Menu_auxiliar("");
        private Creditos creditos = new Creditos();
        private const int MENU_COLAPSADO = 35;
        private const int MENU_EXPANDIDO = 200;
        private const int VELOCIDAD_ANIM = 80;
        private bool menuExpandiendo = false;
        private bool Editar = false;
        private string ID;
        private bool RealizarAct = false;
        private string rol;

        public Principal()
        {
            InitializeComponent();
            MostrarPanel(panelInicio);
            MarcarBotonActivo(btnInicio);
            EstiloDataGrid_Productos();
            EstiloDataGrid_Clientes();
            EstiloDataGrid_HistorialVentas();
            CargarInicio();
            EstiloDataGrid_VentasDelDia();
            EstiloDataGrid_Top5();
        }
        // TODO: Mostrar nombre y rol del usuario autenticado en la barra superior del formulario
        private async void Form1_Load(object sender, EventArgs e)
        {// Oculta el principal
            this.Hide();
            Login login = new Login();
            if (login.ShowDialog() != DialogResult.OK)
            {
                // Si cierra sin loguearse cierra toda la app
                Application.Exit();
                return;
            }
            // Login exitoso, muestra el principal
            this.Show();
            // Maximiza la ventana
            this.WindowState = FormWindowState.Maximized;
            rol = login.RolUsuario;
            Tablaproductos();
            await Tablaclientes();
            dataGrid_Productos.Columns["IdProducto"].Visible = false;
            dataGrid_Productos.Columns["Activo"].Visible = false;
            dgvVentasDelDia.Columns["IdVenta"].Visible = false;
            dgvVentasDelDia.Columns["Estado"].Visible = false;
        }
        #region Funciones comunes
        private void desactivarbtn(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = Color.FromArgb(200, 230, 201);
        }
        private void activarbtn(Button btn)
        {
            btn.Enabled = true;
            btn.BackColor = Color.FromArgb(27, 94, 32);
        }
        private void mostrarbtn(Button btn)
        {
            btn.Visible = true;
        }
        private void ocultarbtn(Button btn)
        {
            btn.Visible = false;
        }
        private void VentanaEmergente(string Mensaje, string titulo)
        {
            MessageBox.Show(Mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private bool VentanaConfirmacion()
        {
            RealizarAct = false;
            DialogResult Resultado = MessageBox.Show("Esta seguro", "Seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                return true;
            }
            else return false;
        }
        #endregion
        #region Panel Inicio
        //todo: Refactorizar el código de estilo de los DataGridView para evitar repetición. Crear una función genérica que reciba el DataGridView a estilizar y aplique el mismo formato a todos. Esto hará que el código sea más limpio y fácil de mantener.
        private void EstiloDataGrid_VentasDelDia()
        {
            dgvVentasDelDia.BackgroundColor = Color.White;
            dgvVentasDelDia.BorderStyle = BorderStyle.None;
            dgvVentasDelDia.RowHeadersVisible = false;
            dgvVentasDelDia.AllowUserToAddRows = false;
            dgvVentasDelDia.AllowUserToResizeRows = false;
            dgvVentasDelDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentasDelDia.ReadOnly = true;
            dgvVentasDelDia.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dgvVentasDelDia.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVentasDelDia.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvVentasDelDia.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvVentasDelDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVentasDelDia.ColumnHeadersHeight = 40;
            dgvVentasDelDia.EnableHeadersVisualStyles = false;
            dgvVentasDelDia.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvVentasDelDia.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgvVentasDelDia.DefaultCellStyle.BackColor = Color.White;
            dgvVentasDelDia.DefaultCellStyle.Padding = new Padding(5);
            dgvVentasDelDia.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dgvVentasDelDia.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvVentasDelDia.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dgvVentasDelDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentasDelDia.GridColor = Color.FromArgb(200, 230, 201);
            dgvVentasDelDia.RowTemplate.Height = 35;
            dgvVentasDelDia.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvVentasDelDia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }
        private void EstiloDataGrid_Top5()
        {
            dataGrid_Top5.BackgroundColor = Color.White;
            dataGrid_Top5.BorderStyle = BorderStyle.None;
            dataGrid_Top5.RowHeadersVisible = false;
            dataGrid_Top5.AllowUserToAddRows = false;
            dataGrid_Top5.AllowUserToResizeRows = false;
            dataGrid_Top5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid_Top5.ReadOnly = true;
            dataGrid_Top5.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dataGrid_Top5.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid_Top5.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGrid_Top5.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGrid_Top5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid_Top5.ColumnHeadersHeight = 40;
            dataGrid_Top5.EnableHeadersVisualStyles = false;
            dataGrid_Top5.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGrid_Top5.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dataGrid_Top5.DefaultCellStyle.BackColor = Color.White;
            dataGrid_Top5.DefaultCellStyle.Padding = new Padding(5);
            dataGrid_Top5.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dataGrid_Top5.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGrid_Top5.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dataGrid_Top5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid_Top5.GridColor = Color.FromArgb(200, 230, 201);
            dataGrid_Top5.RowTemplate.Height = 35;
            dataGrid_Top5.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGrid_Top5.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }
        private void CargarInicio()
        {
            // Ventas del día
            DataTable tabla = CNcolmado.ReporteVentas();
            dgvVentasDelDia.DataSource = tabla;

            decimal totalDia = 0;
            foreach (DataRow fila in tabla.Rows)
                totalDia += Convert.ToDecimal(fila["MontoTotal"]);
            lblTotalDia.Text = "Total del día: RD$ " + totalDia.ToString("0.00");

            // Top 5
            dataGrid_Top5.DataSource = CNcolmado.Top5Productos();
        }

        private void btnCargarInicio_Click(object sender, EventArgs e)
        {
            CargarInicio();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panelTop5.Visible = true;
            panelVentasdia.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panelVentasdia.Visible = true;
            panelTop5.Visible = false;
        }
        #endregion
        #region Funcion del panel lateral
        //todo: Refactorizar el código de los botones del menú lateral para evitar repetición. Crear una función genérica que reciba el panel a mostrar y el botón a marcar como activo, y que se encargue de ocultar los demás paneles y resetear el estilo de los botones. Esto hará que el código sea más limpio y fácil de mantener.
        private void MostrarPanel(Panel panelActivo)
        {
            panelInicio.Visible = false;
            panelProductos.Visible = false;
            panelVentas.Visible = false;
            panelClientes.Visible = false;
            panelAux_Productos.Visible = false;
            panelRegistros.Visible = false;

            panelActivo.Visible = true;
            panelActivo.BringToFront();
        }
        //todo: Agregar un efecto visual (cambio de color o icono) en el botón del menú lateral correspondiente al panel activo para mejorar la navegación y la experiencia del usuario.
        private void MarcarBotonActivo(Button btnActivo)
        {
            btnInicio.BackColor = Color.Transparent;
            btnProductos.BackColor = Color.Transparent;
            btnVentas.BackColor = Color.Transparent;
            btnClientes.BackColor = Color.Transparent;
            btnRegistro.BackColor = Color.Transparent;
            btnCerrarSesion.BackColor = Color.Transparent;
            btnAcercade.BackColor = Color.Transparent;
            dgvHistorialVentas.DataSource = null;
            btnActivo.BackColor = Color.FromArgb(46, 125, 50);
        }
        //todo: En el panel de inicio, agregar un botón o función que permita actualizar los datos mostrados (ventas del día y top 5) sin necesidad de recargar toda la aplicación. Esto mejorará la experiencia del usuario al mantener la información actualizada en tiempo real.
        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelInicio);
            MarcarBotonActivo(btnInicio);
            CargarInicio();
        }
        //todo: En el módulo de productos, agregar una función de búsqueda en tiempo real que permita filtrar los productos por nombre o código a medida que el usuario escribe en un cuadro de búsqueda. Esto mejorará la usabilidad y facilitará la gestión del inventario.
        private void btnProductos_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelProductos);
            MarcarBotonActivo(btnProductos);
            Tablaproductos();
            panelbtns_Productos.Visible= false;
            btnMostraropciones.Visible = true;
        }
        //todo: En el módulo de ventas, agregar una función de búsqueda o filtro que permita al usuario encontrar rápidamente una venta específica por cliente, fecha o monto. Esto facilitará la gestión de ventas y la atención al cliente.
        private void btnVentas_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelVentas);
            MarcarBotonActivo(btnVentas);
            ocultarbtn(btnVerDetalle);
            ocultarbtn(btnAnularVenta);
            ocultarbtn(btnAprobarVenta);
            ocultarbtn(btnRegistrar_venta);
            activarbtn(btnVerHistorial);

        }

        private async void btnClientes_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelClientes);
            MarcarBotonActivo(btnClientes);
            ocultarbtn(btnReacCliente);
            await Tablaclientes();
        }
        //todo: En el panel de auditoría, mostrar un resumen visual (gráficos o indicadores) de las acciones más comunes realizadas por los usuarios, además del registro detallado. Esto ayudará a identificar patrones de uso y posibles anomalías de forma rápida.
        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            MostrarPanel(panelRegistros);
            MarcarBotonActivo(btnRegistro);
            activarbtn(btnMostrarReg);
            panelReg.Visible = false; 
            if (rol == "Cajero")
            {
                btnModusuario.Visible = false;
                btnAgrusuario.Visible = false;
            }

        }
        //Todo: Al cerrar sesión, limpiar toda la información sensible de la sesión anterior y mostrar el formulario de login nuevamente. Si el login se cancela, cerrar toda la aplicación.
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnCerrarSesion);
            if (MessageBox.Show("¿Está seguro de cerrar sesión?", "Cerrar Sesión",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();

                if (login.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }

                // Actualizar rol con el nuevo usuario
                rol = login.RolUsuario;
            
                this.Show();
                MarcarBotonActivo(btnInicio);
                btnInicio.PerformClick(); // Simula clic para cargar el panel de inicio
            }
        }
        private void btnAcercade_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnAcercade);
            creditos.ShowDialog(); 
            
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
        #region Validaciones productos
        // Declarar las validaciones con sus constructores
        private ValidacionTexto vNombre = new ValidacionTexto("Nombre", 100, false);
        private ValidacionTexto vMarca = new ValidacionTexto("Marca", 50, false);
        private ValidacionTexto vCodigo = new ValidacionTexto("Código", 10, true);
        private ValidacionNumero vPrecio = new ValidacionNumero("Precio", 1, 9999);
        private ValidacionNumero vStock = new ValidacionNumero("Stock", 1, 9999);

        private bool ValidarCamposProducto()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (!vNombre.Validar(textNombreProd.Text))
            {
                errorProvider1.SetError(textNombreProd, vNombre.MostrarError());
                valido = false;
            }

            if (!vMarca.Validar(textMarcaProd.Text))
            {
                errorProvider1.SetError(textMarcaProd, vMarca.MostrarError());
                valido = false;
            }

            if (!vCodigo.Validar(TextCodigoProd.Text))
            {
                errorProvider1.SetError(TextCodigoProd, vCodigo.MostrarError());
                valido = false;
            }

            if (!vPrecio.Validar(textPrecioProd.Text))
            {
                errorProvider1.SetError(textPrecioProd, vPrecio.MostrarError());
                valido = false;
            }

            if (!vStock.Validar(textStockProd.Text))
            {
                errorProvider1.SetError(textStockProd, vStock.MostrarError());
                valido = false;
            }
            if (!vPrecio.Validar(textPrecioProd.Text) || !vPrecio.MaximosDecimales(textPrecioProd.Text, 0))
            {
                errorProvider1.SetError(textPrecioProd, "El precio debe ser un número entero válido .");
                valido = false;
            }

            return valido;
        }
        #endregion
        private void Tablaproductos()
        {
            dataGrid_Productos.DataSource = CNproducto.Obtenerdatos_Producto();
            DataCombobox_Productos();
                VerificarStockBajo();
        }
        private void TablaProductosDesactivados()
        {
            dataGrid_Productos.DataSource = CNproducto.ObtenerProductosdesactivados();
            DataCombobox_Productos();
        }
        private void chkverProddesac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkverProddesac.Checked)
            {
                TablaProductosDesactivados();
                mostrarbtn(btnMostraropciones);
                panelbtns_Productos.Visible = false;
                ocultarbtn(btneliminarProd);
                ocultarbtn(btneditarProd);
                ocultarbtn(btnagregarProd);
                panelAux_Productos.Visible = false;
                Limpiartextos_Productos();
            }
            else
            {
                Tablaproductos();
                btnMostraropciones.Visible = true;
                panelbtns_Productos.Visible = false;
                mostrarbtn(btneliminarProd);
                mostrarbtn(btneditarProd);
                mostrarbtn(btnagregarProd);
            }
        }
        private void dataGrid_Productos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow fila in dataGrid_Productos.Rows)
            {
                if (fila.Cells["Stock"] == null) continue;

                int stock = Convert.ToInt32(fila.Cells["Stock"].Value);
                if (stock <= 5)
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210); // rojo claro
                    fila.DefaultCellStyle.ForeColor = Color.FromArgb(183, 28, 28);   // rojo oscuro
                    fila.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }
        private void VerificarStockBajo()
        {
            int count = 0;
            foreach (DataGridViewRow fila in dataGrid_Productos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["Stock"].Value) <= 5)
                    count++;
            }

            if (count > 0)
            {
                lblAlerta.Text = $"¡Alerta! {count} producto(s) con stock bajo.";
            }
                
        }
        private void EstiloDataGrid_Productos()
        {
            dataGrid_Productos.BackgroundColor = Color.White;
            dataGrid_Productos.BorderStyle = BorderStyle.None;
            dataGrid_Productos.RowHeadersVisible = false;
            dataGrid_Productos.AllowUserToAddRows = false;
            dataGrid_Productos.AllowUserToResizeRows = false;
            dataGrid_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid_Productos.ReadOnly = true;
            dataGrid_Productos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dataGrid_Productos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid_Productos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGrid_Productos.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGrid_Productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid_Productos.ColumnHeadersHeight = 40;
            dataGrid_Productos.EnableHeadersVisualStyles = false;
            dataGrid_Productos.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGrid_Productos.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dataGrid_Productos.DefaultCellStyle.BackColor = Color.White;
            dataGrid_Productos.DefaultCellStyle.Padding = new Padding(5);
            dataGrid_Productos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dataGrid_Productos.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGrid_Productos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dataGrid_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid_Productos.GridColor = Color.FromArgb(200, 230, 201);
            dataGrid_Productos.RowTemplate.Height = 35;
            dataGrid_Productos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGrid_Productos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            }
        public void DataCombobox_Productos()
        {
            CN_Producto TablaProd = new CN_Producto();
            textMarcaProd.DataSource = TablaProd.Obtenermarcas();
            textMarcaProd.DisplayMember = "Marca";
            textMarcaProd.ValueMember = "Marca";
        }
        private void Limpiartextos_Productos()
        {
            textNombreProd.Clear(); textDescProd.Clear(); textMarcaProd.Text = ""; textPrecioProd.Clear(); textStockProd.Text = "0";
            TextCodigoProd.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            panelAux_Productos.Visible = false;

        }
        private void btnMostraropciones_Click(object sender, EventArgs e)
        {
            panelbtns_Productos.Visible = true;
            btnMostraropciones.Visible= false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposProducto())
            {
                VentanaEmergente("Por favor, corrige los errores en el formulario.", "Error de validación");
                return;
            }
            //Cuando se agrega
            if (Editar == false)
            {
                try
                {
                    if (validaciones.Existe_Producto(textNombreProd.Text, textMarcaProd.Text) == true)
                    {
                        VentanaEmergente("El producto ya existe", "Error");
                        return;
                    }
                    CNproducto.Insertar_producto(textNombreProd.Text, textDescProd.Text, textMarcaProd.Text, textPrecioProd.Text, TextCodigoProd.Text, textStockProd.Text);
                    VentanaEmergente("Se registro correctamente", "Exito");
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Insertar productos - exitoso");
                    Tablaproductos();
                    panelAux_Productos.Visible = false;
                }
                catch (Exception ex) 
                {
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Insertar producto - Fallido");
                    MessageBox.Show("No se agrego correctamente porque" + ex);
                }
            }
            // Cuando se edita
            else
            {
                try
                {
                    if (validaciones.Editar_ProductoExistente(textNombreProd.Text, textMarcaProd.Text, ID) == true)
                    {
                        VentanaEmergente("El producto ya existe", "Error");
                        return;
                    }
                    RealizarAct = VentanaConfirmacion();
                    if (RealizarAct == true)
                    {

                        CNproducto.Editar_producto(textNombreProd.Text, textDescProd.Text, textMarcaProd.Text, textPrecioProd.Text, textStockProd.Text, TextCodigoProd.Text, ID);
                        VentanaEmergente("Se edito correctamente", "Exito");
                        auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Editar producto - exitoso");
                        Tablaproductos();
                        panelAux_Productos.Visible = false;
                        Editar = false;
                    }
                    else { panelAux_Productos.Visible = false; Editar = false; }
                }
                catch (Exception ex) 
                {
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Editar producto - Fallido");
                    MessageBox.Show("No se edito correctamente porque" + ex); 
                }
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
                TextCodigoProd.Text = dataGrid_Productos.CurrentRow.Cells["Codigo"].Value.ToString();
                ID = dataGrid_Productos.CurrentRow.Cells["IdProducto"].Value.ToString();

            }
            else { MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGrid_Productos.SelectedRows.Count > 0)
            {

                ID = dataGrid_Productos.CurrentRow.Cells["IdProducto"].Value.ToString();
                RealizarAct = VentanaConfirmacion();
                if (RealizarAct == true)
                {
                    CNproducto.Eliminar_Producto(ID);
                    VentanaEmergente("Se elimino correctamente", "Exito");
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Eliminar producto - exitoso");
                    Tablaproductos();
                }

            }
            else 
            { 
                MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Eliminar producto - Fallido");
            }
        }

        private void btnreactivarProd_Click(object sender, EventArgs e)
        {
            menuAuxiliar = new Menu_auxiliar("Productos");
            menuAuxiliar.ShowDialog();
        }
        #endregion
        #region Panel Clientes
        #region Validaciones clientes
        private ValidacionTexto vNombreCliente = new ValidacionTexto("Nombre", 100, false);
        private bool ValidarCamposCliente()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (!vNombreCliente.Validar(textNombreCl.Text))
            {
                errorProvider1.SetError(textNombreCl, vNombreCliente.MostrarError());
                valido = false;
            }

            if (Editar == false)
            {
                if (CNclientes.ExisteTelefono(textTelefonoCl.Text))
                {
                    errorProvider1.SetError(textTelefonoCl, "Ya existe un cliente con ese teléfono.");
                    valido = false;
                }
            }
            else
            {
                if (CNclientes.ExisteTelefonoEditar(textTelefonoCl.Text, ID))
                {
                    errorProvider1.SetError(textTelefonoCl, "Ya existe un cliente con ese teléfono.");
                    valido = false;
                }
            }

            return valido;
        }
        #endregion
        private void EstiloDataGrid_Clientes()
        {
            dataGrid_Clientes.BackgroundColor = Color.White;
            dataGrid_Clientes.BorderStyle = BorderStyle.None;
            dataGrid_Clientes.RowHeadersVisible = false;
            dataGrid_Clientes.AllowUserToAddRows = false;
            dataGrid_Clientes.AllowUserToResizeRows = false;
            dataGrid_Clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid_Clientes.ReadOnly = true;
            dataGrid_Clientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dataGrid_Clientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid_Clientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGrid_Clientes.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGrid_Clientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid_Clientes.ColumnHeadersHeight = 40;
            dataGrid_Clientes.EnableHeadersVisualStyles = false;
            dataGrid_Clientes.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGrid_Clientes.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dataGrid_Clientes.DefaultCellStyle.BackColor = Color.White;
            dataGrid_Clientes.DefaultCellStyle.Padding = new Padding(5);
            dataGrid_Clientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dataGrid_Clientes.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGrid_Clientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dataGrid_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid_Clientes.GridColor = Color.FromArgb(200, 230, 201);
            dataGrid_Clientes.RowTemplate.Height = 35;
            dataGrid_Clientes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGrid_Clientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

        }
        private async Task Tablaclientes()
        {
            
            dataGrid_Clientes.DataSource = await Task.Run(() => CNclientes.Mostrartabla_Clientes());
            dataGrid_Clientes.Columns["IdCliente"].Visible = false;
            dataGrid_Clientes.Columns["Activo"].Visible = false;
            
        }
        private void btnregistrar_Cl_Click(object sender, EventArgs e)
        {
            panelAux_Clientes.Visible = true;
            tituloauxCl.Text = "Registrar cliente";
            textInfoCl.Clear(); textNombreCl.Clear(); textTelefonoCl.Clear();
        }

        private void btneditar_Cl_Click(object sender, EventArgs e)
        {
            if (dataGrid_Clientes.SelectedRows.Count > 0)
            {
                Editar = true;
                panelAux_Clientes.Visible = true;
                tituloauxCl.Text = "Editar cliente";
                textNombreCl.Text = dataGrid_Clientes.CurrentRow.Cells["Nombre"].Value.ToString();
                textTelefonoCl.Text = dataGrid_Clientes.CurrentRow.Cells["Telefono"].Value.ToString();
                textInfoCl.Text = dataGrid_Clientes.CurrentRow.Cells["Informacion"].Value.ToString();
                ID = dataGrid_Clientes.CurrentRow.Cells["IdCliente"].Value.ToString();
            }
            else { VentanaEmergente("Seleccione una fila", "Error"); }

        }
        private async void btnguardar_Cl_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCliente())
            {
                VentanaEmergente("Por favor, corrige los errores en el formulario.", "Error de validación");
                return;
            }
            if (Editar == false)
            {
                try
                {
                    CNclientes.Registrar_Cliente(textNombreCl.Text, textTelefonoCl.Text, textInfoCl.Text);
                    VentanaEmergente("Se registro correctamente", "Exito");
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Registrar Cliente - exitoso");
                    await Tablaclientes();
                    panelAux_Clientes.Visible = false;
                }
                catch (Exception ex)
                {
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Registrar Cliente - Fallido");
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
                        CNclientes.Editar_Cliente(textNombreCl.Text, textTelefonoCl.Text, textInfoCl.Text, ID);
                        MessageBox.Show("El cliente fue editado");
                        await Tablaclientes();
                        panelAux_Clientes.Visible = false;
                        Editar = false;
                    }
                    else { panelAux_Clientes.Visible = false; Editar = false; }
                }
                catch (Exception ex) 
                {
                    auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Editar Cliente - Fallido");
                    MessageBox.Show("No se edito correctamente porque" + ex, "Error"); 
                }
            }

        }
        private async void btneliminar_Cl_Click(object sender, EventArgs e)
        {

            if (dataGrid_Clientes.SelectedRows.Count > 0)
            {
                RealizarAct = VentanaConfirmacion();
                ID = dataGrid_Clientes.CurrentRow.Cells["IdCliente"].Value.ToString();
                CNclientes.Desactivar_Cliente(ID);
                Tablaclientes();
                panelAux_Clientes.Visible = false;
            }
            else 
            {
                VentanaEmergente("Seleccione una fila", "Error");
            }
        }

        private void btnRegistrarSaldo_Click(object sender, EventArgs e)
        {
            menuAuxiliar = new Menu_auxiliar("Clientes");
            menuAuxiliar.ShowDialog();
        }
        private async void chkClientesdesactivados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClientesdesactivados.Checked)
            {
                dataGrid_Clientes.DataSource = CNclientes.ObtenerClientesDesactivados();
                ocultarbtn(btnRegistrarSaldo);
                ocultarbtn(btneditar_Cl);
                ocultarbtn(btneliminar_Cl);
                ocultarbtn(btnregistrar_Cl);
                panelAux_Clientes.Visible = false;
                mostrarbtn(btnReacCliente);
            }
            else
            {
                await Tablaclientes();
                mostrarbtn(btnRegistrarSaldo);
                mostrarbtn(btneditar_Cl);
                mostrarbtn(btneliminar_Cl);
                mostrarbtn(btnregistrar_Cl);
            }

        }
        private void btnReacCliente_Click(object sender, EventArgs e)
        {
            RealizarAct = VentanaConfirmacion();
            if (RealizarAct == true)
            {
                if (dataGrid_Clientes.SelectedRows.Count > 0)
                {
                    ID = dataGrid_Clientes.CurrentRow.Cells["IdCliente"].Value.ToString();
                    CNclientes.Reactivar_Cliente(ID);
                    VentanaEmergente("Cliente reactivado correctamente", "Éxito");
                    chkClientesdesactivados.Checked = false;
                }
                else { VentanaEmergente("Seleccione una fila", "Error"); }
            }
        }
        #endregion
        #region Panel Ventas
        //todo: En el panel de ventas, agregar una función de búsqueda o filtro que permita al usuario encontrar rápidamente una venta específica por cliente, fecha o monto. Esto facilitará la gestión de ventas y la atención al cliente.
        private void EstiloDataGrid_HistorialVentas()
        {
            dgvHistorialVentas.BackgroundColor = Color.White;
            dgvHistorialVentas.BorderStyle = BorderStyle.None;
            dgvHistorialVentas.RowHeadersVisible = false;
            dgvHistorialVentas.AllowUserToAddRows = false;
            dgvHistorialVentas.AllowUserToResizeRows = false;
            dgvHistorialVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialVentas.ReadOnly = true;
            dgvHistorialVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dgvHistorialVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorialVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHistorialVentas.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgvHistorialVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistorialVentas.ColumnHeadersHeight = 40;
            dgvHistorialVentas.EnableHeadersVisualStyles = false;
            dgvHistorialVentas.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvHistorialVentas.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgvHistorialVentas.DefaultCellStyle.BackColor = Color.White;
            dgvHistorialVentas.DefaultCellStyle.Padding = new Padding(5);
            dgvHistorialVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dgvHistorialVentas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvHistorialVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dgvHistorialVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialVentas.GridColor = Color.FromArgb(200, 230, 201);
            dgvHistorialVentas.RowTemplate.Height = 35;
            dgvHistorialVentas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvHistorialVentas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }


        private void btnRegistrar_Venta_Click(object sender, EventArgs e)
        {
          
            menuVentas.ShowDialog();
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            dgvHistorialVentas.DataSource = CNcolmado.HistorialVentas();
            mostrarbtn(btnVerDetalle);
            mostrarbtn(btnAnularVenta);
            mostrarbtn(btnAprobarVenta);
            mostrarbtn(btnRegistrar_venta);
            desactivarbtn(btnVerHistorial);
            activarbtn(btnVerDetalle);
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
                auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Anular Venta - exitoso");
                btnVerHistorial_Click(sender, e); // recargar historial
            }
        }


        private void btnAprobarVenta_Click(object sender, EventArgs e)
        {
            if (dgvHistorialVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una venta primero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string estado = dgvHistorialVentas.SelectedRows[0].Cells["Estado"].Value.ToString();

            if (estado == "Completada")
            {
                MessageBox.Show("Esta venta ya está completada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (estado == "Anulada")
            {
                MessageBox.Show("No se puede completar una venta anulada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idVenta = dgvHistorialVentas.SelectedRows[0].Cells["IdVenta"].Value.ToString();
            CNcolmado.CompletarVenta(idVenta);
            MessageBox.Show("Venta completada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            auditoria.RegistrarAuditoria(Sesion.IdUsuario, "Completar Venta - exitoso");
            btnVerHistorial_Click(sender, e);
        }
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            activarbtn(btnVerHistorial);
            ocultarbtn(btnAnularVenta);
            ocultarbtn(btnAprobarVenta);
            ocultarbtn(btnRegistrar_venta);
            if (dgvHistorialVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una venta primero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                string idVenta = dgvHistorialVentas.SelectedRows[0].Cells["IdVenta"].Value.ToString();
                dgvHistorialVentas.DataSource = CNcolmado.ObtenerDetalleVenta(idVenta);
           desactivarbtn(btnVerDetalle);
        }



        #endregion
        #region Panel Registros
        #region Estilo y validaciones usuarios
        ValidacionTexto vNombreusuario = new ValidacionTexto("Nombre de usuario", 20, true);
        ValidacionTexto vContrausuario = new ValidacionTexto("Contraseña", 20, true);
        private void EstiloDataGrid_Auditoria()
        {
            dataGridAuditoria.BackgroundColor = Color.White;
            dataGridAuditoria.BorderStyle = BorderStyle.None;
            dataGridAuditoria.RowHeadersVisible = false;
            dataGridAuditoria.AllowUserToAddRows = false;
            dataGridAuditoria.AllowUserToResizeRows = false;
            dataGridAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAuditoria.ReadOnly = true;
            dataGridAuditoria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 94, 32);
            dataGridAuditoria.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridAuditoria.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridAuditoria.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGridAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridAuditoria.ColumnHeadersHeight = 40;
            dataGridAuditoria.EnableHeadersVisualStyles = false;
            dataGridAuditoria.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridAuditoria.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridAuditoria.DefaultCellStyle.BackColor = Color.White;
            dataGridAuditoria.DefaultCellStyle.Padding = new Padding(5);
            dataGridAuditoria.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dataGridAuditoria.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridAuditoria.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
            dataGridAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAuditoria.GridColor = Color.FromArgb(200, 230, 201);
            dataGridAuditoria.RowTemplate.Height = 35;
            dataGridAuditoria.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridAuditoria.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }
        #endregion
        private void TablaAuditoria()
        {
            
            CN_Auditoria auditoria = new CN_Auditoria();
            dataGridAuditoria.DataSource = auditoria.MostrarAuditoria();
            EstiloDataGrid_Auditoria();

        }
        private void CargarComboUsuarios()
        {
            DataTable tabla = CNusuarios.MostrarUsuario();
            cmbUsuarios.DataSource = tabla;
            cmbUsuarios.DisplayMember = "Usuario";
            cmbUsuarios.ValueMember = "IdUsuario";
            cmbUsuarios.SelectedIndex = -1;
        }
        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedIndex == -1)
            {
                txtNombreusuario.Clear();
                txtContrausuario.Clear();
                cmbTipousuario.SelectedIndex = -1;
                return;
            }

            DataRowView fila = (DataRowView)cmbUsuarios.SelectedItem;
            txtNombreusuario.Text = fila["Usuario"].ToString();
            txtContrausuario.Text = fila["Contrasena"].ToString();
            cmbTipousuario.SelectedItem = fila["Rol"].ToString();
        }
        private void btnMostrarReg_Click(object sender, EventArgs e)
        {
            panelReg.Visible = true;   
            desactivarbtn(btnMostrarReg);
            TablaAuditoria();
            pictureBoxLogoReg.Visible = true;
        }

        private void btnModusuario_Click(object sender, EventArgs e)
        {
            Editar = true;
            panelAuxUsuario.Visible = true;
            lbltituloAuxusuario.Text = "Modificar Usuario";
            lblseleccionusuario.Visible = true;
            cmbUsuarios.Visible = true;
            cmbUsuarios.SelectedIndex = -1;
            CargarComboUsuarios();
            txtNombreusuario.Location = new Point(30, 170);
            txtContrausuario.Location = new Point(30, 220);
            lblNombreusuario.Location = new Point(30, 150);
            lblContrausuario.Location = new Point(30, 200);
        }

        private void btnAgrusurio_Click(object sender, EventArgs e)
        {
            
            txtContrausuario.Clear();
            txtNombreusuario.Clear();
            panelAuxUsuario.Visible = true;
            lbltituloAuxusuario.Text = "Registrar Usuario";
            lblseleccionusuario.Visible = false;
            cmbUsuarios.Visible = false;
            cmbTipousuario.SelectedIndex = -1;
            txtNombreusuario.Location = new Point(30, 80);
            txtContrausuario.Location = new Point(30, 130);
            lblNombreusuario.Location = new Point(30, 60);
            lblContrausuario.Location = new Point(30, 110);

        }

        private void btnguardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (!vNombreusuario.Validar(txtNombreusuario.Text))
                    {
                        errorProvider1.SetError(txtNombreusuario, vNombreusuario.MostrarError());
                        return;
                }
                if (!vContrausuario.Validar(txtContrausuario.Text))
                {
                    errorProvider1.SetError(txtContrausuario, vContrausuario.MostrarError());
                    return;
                }
                if (Editar == true)
                {
                    if (cmbUsuarios.SelectedIndex == -1)
                    {errorProvider1.SetError(cmbUsuarios, "Seleccione un usuario para modificar.");
                        return;
                    }
                    RealizarAct = VentanaConfirmacion();
                    if (RealizarAct == false)
                    {
                        
                        return;
                    }
                    else
                    {
                        DataRowView fila = (DataRowView)cmbUsuarios.SelectedItem;
                        string idUsuario = fila["IdUsuario"].ToString();
                        CNusuarios.EditarUsuario(txtNombreusuario.Text,
                                                txtContrausuario.Text,
                                                cmbTipousuario.SelectedItem.ToString(), idUsuario);
                        MessageBox.Show("Usuario modificado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RealizarAct = false;
                    }
                }
                else
                {
                    if (cmbTipousuario.SelectedIndex == -1)
                    {
                        errorProvider1.SetError(cmbTipousuario, "Seleccione un tipo de usuario.");
                        return;
                    }
                    CNusuarios.InsertarUsuario(txtNombreusuario.Text,
                                        txtContrausuario.Text,
                                        cmbTipousuario.SelectedItem.ToString());
                    MessageBox.Show("Usuario registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

                panelAuxUsuario.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalirpnlUsuario_Click(object sender, EventArgs e)
        {
            panelAuxUsuario.Visible = false;
            txtContrausuario.Clear();
            txtNombreusuario.Clear();
        }

        private void chkAuditoriadetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuditoriadetalle.Checked)
            {
                dataGridAuditoria.DataSource = auditoria.MostrarAuditoriaDetalle();
                EstiloDataGrid_Auditoria();
            }
            else
            {
                TablaAuditoria();
            }
        }





        #endregion

      
    }
    }




      


    






