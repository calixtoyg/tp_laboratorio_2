using System;
using System.IO;
using System.Text;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(archivo, true))
                {
                    file.WriteLine(datos);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            FileStream stream = File.OpenRead(archivo);
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            StringBuilder read = new StringBuilder();
            while (stream.Read(b,0,b.Length) > 0)
            {
                read.Append(temp.GetString(b));
            }
            stream.Close();

            datos = read.ToString();
            return true;
        }
    }
}