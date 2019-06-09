using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Programa
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            Array values = Enum.GetValues(typeof(Sarasa));
//            Random random = new Random();
//            for (int i = 0; i < 5; i++)
//            {
//                Console.WriteLine((Sarasa) values.GetValue(random.Next(values.Length)));
//                
//            }
            StringBuilder builder = new StringBuilder("hola, ");
            builder.Remove(builder.Length - 2, 2);
            Console.Write(builder);
        }

        public enum Sarasa
        {
            Hola,Chau,Puto,Mierda,Caca
        }
    }
}