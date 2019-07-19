using System;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        
        /// <summary>
        /// Serializa en un archivo xml el objeto que recibe como parametro
        /// </summary>
        /// <param name="archivo">path</param>
        /// <param name="datos"></param>
        /// <returns></returns>
        /// <exception cref="ArchivosException"></exception>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    serializer.Serialize(writer, datos);
                }


                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee desde un archivo xml los datos de un objeto que recibe por parametro
        /// </summary>
        /// <param name="archivo">path</param>
        /// <param name="datos"></param>
        /// <returns></returns>
        /// <exception cref="ArchivosException"></exception>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextReader writer = new StreamReader(archivo))
                {
                    datos = (T) serializer.Deserialize(writer);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}