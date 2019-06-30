using System;
using System.Data.Common;
using System.Text;

namespace Entities
{
    public class Numero
    {
        private double numero;

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            SetNumero = numero;
        }

        public Numero()
        {
            numero = 0;
        }

        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double result))
            {
                Console.WriteLine("Conversion exitosa de {0} --> {1}", strNumero, result);
                return result;
            }

            Console.WriteLine("No se pudo parsear de {0} --> {1}", strNumero, result);
            return result;

        }

        public string BinarioDecimal(string binario)
        {
            SetNumero = binario;
            double valorAbsoluto = Math.Abs(numero);
            int valorAbsolutoSinDecimales = (int) valorAbsoluto;
            int contador = 0;
            int resultado = 0;
            int i = 0;
            while (true)
            {
                if (valorAbsolutoSinDecimales == 0)
                {
                    break;
                }
                else
                {
                    int temp = valorAbsolutoSinDecimales % 10;
                    resultado += temp * (int)Math.Pow(2, contador);
                    valorAbsolutoSinDecimales = valorAbsolutoSinDecimales/ 10;
                    contador++;
                }
            }

            return resultado.ToString();

        }
        
        public string DecimalBinario(string numeroDecimal)
        {
            SetNumero = numeroDecimal;
            double valorAbsoluto = Math.Abs(numero);
            int valorAbsolutoSinDecimales = (int) valorAbsoluto;
            int[] binaryNum = new int[1000];
            int i = 0;
            
            while (valorAbsolutoSinDecimales > 0)
            {
                binaryNum[i] = valorAbsolutoSinDecimales % 2;
                valorAbsolutoSinDecimales /= 2;
                i++;
            }
            
            StringBuilder builder = new StringBuilder();

            for (int j = i; j >= 0; j--)
            {
                builder.Append(binaryNum[j]);
            }

            return builder.ToString();


        }    
        
        public string DecimalBinario(double numeroDecimal)
        {
            double valorAbsoluto = Math.Abs(numeroDecimal);
            int valorAbsolutoSinDecimales = (int) valorAbsoluto;
            int[] binaryNum = new int[1000];
            int i = 0;
            
            while (valorAbsolutoSinDecimales > 0)
            {
                binaryNum[i] = valorAbsolutoSinDecimales % 2;
                valorAbsolutoSinDecimales /= 2;
                i++;
            }
            
            StringBuilder builder = new StringBuilder();

            for (int j = i; j >= 0; j--)
            {
                builder.Append(binaryNum[j]);
            }

            return builder.ToString();
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return Double.MinValue;
            }
            return n1.numero / n2.numero;
        }
    }
}