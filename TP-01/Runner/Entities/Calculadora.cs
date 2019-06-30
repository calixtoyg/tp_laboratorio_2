using System;

namespace Entities
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorValidado = ValidarOperador(operador);
            switch (operadorValidado)
            {
                
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    double resultado = num1 / num2;
                    return resultado;
                
                default:
                    return num1 + num2;
            }

        }

        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "-":
                    return "-";
                case "/":
                    return "/";
                case "*":
                    return "*";
                default:
                    return "+";
            }
        }
    }
}