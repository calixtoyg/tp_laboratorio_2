using System.IO;
using System.Text;
using Clases_Instanciables;

namespace Archivos
{
    public class Texto : IArchivo<Jornada>
    {
        public bool Guardar(string archivo, Jornada datos)
        {
            FileStream stream = new FileStream(archivo, FileMode.Append);
            byte[] info = new UTF8Encoding(true).GetBytes(archivo);
            stream.Write(info, 0, info.Length);
            stream.Close();
            return true;
        }

        public bool Leer(string archivo, out Jornada datos)
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

            datos = null;
            return true;
        }
    }
}