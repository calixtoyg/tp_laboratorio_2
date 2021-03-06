using System;
using System.IO;
using System.Text;

namespace TP_04
{
    public static class GuardarString
    {
        
        /// <summary>
        /// Guarda String en un archivo
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo">path del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                FileStream stream =
                    new FileStream(
                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar +
                        archivo, FileMode.Append);
                byte[] info = new UTF8Encoding(true).GetBytes(texto);
                stream.Write(info, 0, info.Length);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          

        }
    }
}