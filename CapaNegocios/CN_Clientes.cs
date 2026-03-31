using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocios
{
    public class CN_Clientes
    {
        private CD_Clientes CDclientes = new CD_Clientes();

        public DataTable Mostrartabla_Clientes()
        {
            return CDclientes.MostrarTabla();
        }
        public void Registrar_Cliente(string nombre, string telefono, string informacion)
        {
            CDclientes.Registrar_Clientes(nombre, telefono, informacion);
        }
        public void Editar_Cliente(string nombre, string telefono, string informacion, string id)
        {
            CDclientes.Editar_Clientes(nombre, telefono, informacion, Convert.ToInt32(id));
        }
        public void Desactivar_Cliente(string id)
        {
            CDclientes.Desactivar_Clientes(Convert.ToInt32(id));
        }
        public void Reactivar_Cliente(string id)
        {
            CDclientes.Reactivar_Clientes(Convert.ToInt32(id));
        }
        public void Agrgarsaldo_Cliente(string saldo, string id)
        {
            CDclientes.Agregarsaldo(Convert.ToInt32(saldo), Convert.ToInt32(id));
        }
        public bool ExisteTelefono(string telefono)
        {
            return CDclientes.ExisteTelefono(telefono);
        }
        public bool ExisteTelefonoEditar(string telefono, string id)
        {
            return CDclientes.ExisteTelefonoEditar(telefono, Convert.ToInt32(id));
        }
    }
}