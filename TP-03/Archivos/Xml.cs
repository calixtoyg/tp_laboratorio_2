using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : new()
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(archivo);
            serializer.Serialize(writer, datos);
            writer.Close();
            return true;
        }
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader writer = new StreamReader(archivo);
            datos = (T)serializer.Deserialize(writer);
            writer.Close();
            return true;
        }
    }
}