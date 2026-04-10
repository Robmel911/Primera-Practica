using CapaDatos;
using System;

namespace CapaNegocios
{
    public class Validaciones
    {
        private CD_Productos CDproductos = new CD_Productos();
        private CD_Clientes CDclientes = new CD_Clientes();
        private CD_Ventas CDventas = new CD_Ventas();

        #region Productos

        // TODO: Existe_Producto - Recibe nombre y marca del producto, consulta la BD y retorna bool indicando si esa combinación ya existe
        public bool Existe_Producto(string nombre, string marca)
        {
            if (CDproductos.ExisteProducto(nombre, marca))
                return true;
            else
                return false;
        }

        // TODO: Editar_ProductoExistente - Recibe nombre, marca e id del producto, verifica si existe un duplicado al editar excluyendo el registro actual y retorna bool
        public bool Editar_ProductoExistente(string nombre, string marca, string id)
        {
            if (CDproductos.ExisteProductoEditar(nombre, marca, Convert.ToInt32(id)))
                return true;
            else
                return false;
        }

        #endregion
    }


    public abstract class ValidacionBase
    {
        protected string NombreCampo;

        // TODO: ValidacionBase - Recibe nombreCampo como string, lo almacena para usarlo en los mensajes de validación de las clases hijas
        public ValidacionBase(string nombreCampo)
        {
            this.NombreCampo = nombreCampo;
        }

        // TODO: Validar - Recibe valor como string, método abstracto que cada clase hija implementa con su propia lógica de validación y retorna bool
        public abstract bool Validar(string valor);

        // TODO: MostrarError - Sin parámetros, retorna string con el mensaje de error genérico del campo; puede ser sobreescrito en las clases hijas
        public virtual string MostrarError()
        {
            return $"El campo {NombreCampo} no es válido.";
        }

        // TODO: ConvertirDouble - Recibe valor como string, lo convierte a double y lo retorna; lanza excepción si el valor no es numérico
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

        // TODO: ValidacionTexto - Recibe nombreCampo, longitudMaxima y permitirNumeros, configura las reglas de validación para campos de texto
        public ValidacionTexto(string nombreCampo, int longitudMaxima, bool permitirNumeros)
            : base(nombreCampo)
        {
            this.longitudMaxima = longitudMaxima;
            this.permitirNumeros = permitirNumeros;
        }

        // TODO: Validar - Recibe valor como string, verifica que no esté vacío, no supere la longitud máxima y cumpla la regla de solo letras si aplica; retorna bool
        public override bool Validar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return false;
            if (valor.Trim().Length > longitudMaxima) return false;
            if (!permitirNumeros && !SoloLetras(valor)) return false;
            return true;
        }

        // TODO: MostrarError - Sin parámetros, retorna string con el mensaje de error indicando el nombre del campo y la longitud máxima permitida
        public override string MostrarError()
        {
            return $"El campo {NombreCampo} no puede estar vacío y debe tener máximo {longitudMaxima} caracteres.";
        }

        // TODO: SoloLetras - Recibe valor como string, verifica que solo contenga letras, espacios, guiones y puntos; retorna bool
        public bool SoloLetras(string valor)
        {
            foreach (char c in valor)
                if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '.')
                    return false;
            return true;
        }
    }


    public class ValidacionNumero : ValidacionBase
    {
        private double valorMinimo;
        private double valorMaximo;

        // TODO: ValidacionNumero - Recibe nombreCampo, valorMinimo y valorMaximo, configura las reglas de validación para campos numéricos con rango
        public ValidacionNumero(string nombreCampo, double valorMinimo, double valorMaximo)
            : base(nombreCampo)
        {
            this.valorMinimo = valorMinimo;
            this.valorMaximo = valorMaximo;
        }

        // TODO: MaximosDecimales - Recibe valor como string y cantidad de decimales permitidos como int, verifica que el número no supere ese límite y retorna bool
        public bool MaximosDecimales(string valor, int decimales)
        {
            double numero;
            if (!double.TryParse(valor, out numero)) return false;

            string[] partes = valor.Replace(',', '.').Split('.');
            if (partes.Length == 1) return true;

            return partes[1].Length <= decimales;
        }

        // TODO: Validar - Recibe valor como string, verifica que no esté vacío, sea numérico y esté dentro del rango configurado; retorna bool
        public override bool Validar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return false;
            double numero;
            if (!double.TryParse(valor, out numero)) return false;
            if (numero < valorMinimo) return false;
            if (numero > valorMaximo) return false;
            return true;
        }

        // TODO: MostrarError - Sin parámetros, retorna string con el mensaje de error indicando el rango numérico válido del campo
        public override string MostrarError()
        {
            return $"El campo {NombreCampo} debe ser un número entre {valorMinimo} y {valorMaximo}.";
        }
    }
}
