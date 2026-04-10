using CapaDatos;
using System;

namespace CapaNegocios
{
    // TODO: Centralizar todos los mensajes de error en un archivo de recursos para soporte multilenguaje
    public class Validaciones
    {
        private CD_Productos CDproductos = new CD_Productos();
        private CD_Clientes CDclientes = new CD_Clientes();
        private CD_Ventas CDventas = new CD_Ventas();

        #region Productos
        public bool Existe_Producto(string nombre, string marca)
        {
            if (CDproductos.ExisteProducto(nombre, marca))
            {
                return true; }
            else
                return false;

        }
        public bool Editar_ProductoExistente(string nombre, string marca,string id)
        {
            if (CDproductos.ExisteProductoEditar(nombre, marca, Convert.ToInt32(id)))
            {
                return true;
            }
            else
                return false;
            
        }
        #endregion
    }
   

    
   
        // TODO: Agregar soporte para validación de formato de correo electrónico y URL
        public abstract class ValidacionBase
        {
            protected string NombreCampo;

            
            public ValidacionBase(string nombreCampo)
            {
                this.NombreCampo = nombreCampo;
            }

            
            public abstract bool Validar(string valor);

            
            public virtual string MostrarError()
            {
                return $"El campo {NombreCampo} no es válido.";
            }

            
            public double ConvertirDouble(string valor)
                 {
            double resultado;
            if (double.TryParse(valor, out resultado))
                return resultado;
            throw new Exception($"El valor '{valor}' no es un número válido.");
                 }
        }
    

        public class ValidacionTexto : ValidacionBase
        {
            private int longitudMaxima;
            private bool permitirNumeros;

            // Constructor con parámetros
            public ValidacionTexto(string nombreCampo, int longitudMaxima, bool permitirNumeros)
                : base(nombreCampo)
            {
                this.longitudMaxima = longitudMaxima;
                this.permitirNumeros = permitirNumeros;
            }

            
            public override bool Validar(string valor)
            {
                if (string.IsNullOrWhiteSpace(valor)) return false;
                if (valor.Trim().Length > longitudMaxima) return false;
                if (!permitirNumeros && !SoloLetras(valor)) return false;
                return true;
            }

           
            public override string MostrarError()
            {
                return $"El campo {NombreCampo} no puede estar vacío y debe tener máximo {longitudMaxima} caracteres.";
            }


        public bool SoloLetras(string valor)
        {
            foreach (char c in valor)
                if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '.')
                    return false;
            return true;
        }
        
        }

    // TODO: Agregar validación de formato de moneda con símbolo configurable por región
    public class ValidacionNumero : ValidacionBase
    {
        // Campos
        private double valorMinimo;
        private double valorMaximo;

        // Constructor
        public ValidacionNumero(string nombreCampo, double valorMinimo, double valorMaximo)
            : base(nombreCampo)
        {
            this.valorMinimo = valorMinimo;
            this.valorMaximo = valorMaximo;
        }

        public bool MaximosDecimales(string valor, int decimales)
        {
            double numero;
            if (!double.TryParse(valor, out numero)) return false;

            string[] partes = valor.Replace(',', '.').Split('.');
            if (partes.Length == 1) return true;

            return partes[1].Length <= decimales;
        }
       
        
       

        // Validar
        public override bool Validar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return false;
            double numero;
            if (!double.TryParse(valor, out numero)) return false;
            if (numero < valorMinimo) return false;
            if (numero > valorMaximo) return false;
            return true;
        }

        // MostrarError
        public override string MostrarError()
        {
            return $"El campo {NombreCampo} debe ser un número entre {valorMinimo} y {valorMaximo}.";
        }

     
    }

}

