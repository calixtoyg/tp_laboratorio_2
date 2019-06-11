using Clases_Instanciables;

namespace Archivos
{
    public class Texto : IArchivo<Jornada>
    {
        public bool Guardar(string archivo, Jornada datos)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
            {
                file.Write(datos.Leer());
            }

            return true;
        }

        public bool Leer(string archivo, out Jornada datos)
        {
            throw new System.NotImplementedException();
        }
    }
}