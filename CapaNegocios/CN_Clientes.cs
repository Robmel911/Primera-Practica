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

        // TODO: Mostrartabla_Clientes - Sin parámetros, llama al SP MostrarClientes vía la capa de datos y retorna DataTable con todos los clientes
        public DataTable Mostrartabla_Clientes()
        {
            return CDclientes.MostrarTabla("MostrarClientes");
        }
        // TODO: ObtenerClientesDesactivados - Sin parámetros, llama al SP MostrarClientesDesactivados vía la capa de datos y retorna DataTable con todos los clientes desactivados
        public DataTable ObtenerClientesDesactivados()
        {
            return CDclientes.MostrarClientesDesactivados();
        }

        // TODO: Registrar_Cliente - Recibe nombre, telefono e informacion, los envía a la capa de datos para insertar el nuevo cliente en la BD
        public void Registrar_Cliente(string nombre, string telefono, string informacion)
        {
            CDclientes.Registrar_Clientes(nombre, telefono, informacion);
        }

        // TODO: Editar_Cliente - Recibe nombre, telefono, informacion e id como string, convierte id a int y envía los datos a la capa de datos para actualizar el cliente
        public void Editar_Cliente(string nombre, string telefono, string informacion, string id)
        {
            CDclientes.Editar_Clientes(nombre, telefono, informacion, Convert.ToInt32(id));
        }

        // TODO: Desactivar_Cliente - Recibe IdCliente como string, lo convierte a int y lo envía a la capa de datos para desactivar el cliente en la BD
        public void Desactivar_Cliente(string id)
        {
            CDclientes.Desactivar_Clientes(Convert.ToInt32(id));
        }

        // TODO: Reactivar_Cliente - Recibe IdCliente como string, lo convierte a int y lo envía a la capa de datos para reactivar el cliente en la BD
        public void Reactivar_Cliente(string id)
        {
            CDclientes.Reactivar_Clientes(Convert.ToInt32(id));
        }

        // TODO: Agrgarsaldo_Cliente - Recibe saldo e id como string, los convierte a int y los envía a la capa de datos para sumar el saldo al balance del cliente
        public void Agrgarsaldo_Cliente(string saldo, string id)
        {
            CDclientes.Agregarsaldo(Convert.ToInt32(saldo), Convert.ToInt32(id));
        }

        // TODO: ExisteTelefono - Recibe teléfono como string, consulta la BD y retorna bool indicando si el teléfono ya está registrado
        public bool ExisteTelefono(string telefono)
        {
            return CDclientes.ExisteTelefono(telefono);
        }

        // TODO: ExisteTelefonoEditar - Recibe teléfono e id como string, verifica si el teléfono pertenece a otro cliente distinto al que se edita y retorna bool
        public bool ExisteTelefonoEditar(string telefono, string id)
        {
            return CDclientes.ExisteTelefonoEditar(telefono, Convert.ToInt32(id));
        }

       
    }
}
