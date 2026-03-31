using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace Primera_Practica
{
    // TODO: Formulario de consulta de auditoría del sistema
    public partial class Frm_Auditoria : Form
    {
        // TODO: Instancia de la capa de negocios
        private CN_Auditoria negocio = new CN_Auditoria();

        public Frm_Auditoria()
        {
            InitializeComponent();
        }

        // TODO: Cargar datos al abrir el formulario de forma asíncrona
        private async void Frm_Auditoria_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarDatosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TODO: Método asíncrono para cargar el DataGridView
        private async Task CargarDatosAsync()
        {
            await Task.Run(() =>
            {
                DataTable tabla = negocio.ObtenerTodos();
                this.Invoke((Action)(() =>
                {
                    dataGridView1.DataSource = tabla;
                }));
            });
        }

        // TODO: Filtrar registros por nombre de usuario
        private void btnFiltrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = negocio.FiltrarPorUsuario(txtUsuario.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TODO: Filtrar registros por rango de fechas
        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = negocio.FiltrarPorFecha(
                    datePickerInicio.Value, datePickerFin.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TODO: Mostrar todos los registros
        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = negocio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}