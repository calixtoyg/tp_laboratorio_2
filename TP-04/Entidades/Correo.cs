using System.Collections.Generic;
using System.Text;
using System.Threading;
using CustomExceptions;

namespace TP_04
{
    public class Correo : IMostrar<List<Paquete>>
    {
        // Fields
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        // Methods
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            using (List<Thread>.Enumerator enumerator = this.mockPaquetes.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        // si no queda nada en el enumerator hago un break.
                        break;
                    }
                    Thread current = enumerator.Current;
                    if (current.IsAlive)
                    {
                        current.Abort();
                    }
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder mostrarDatosBuilder = new StringBuilder();
            using (List<Paquete>.Enumerator enumerator = ((Correo) elementos).paquetes.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        // si no queda nada en el enumerator hago un break.
                        break;
                    }
                    Paquete current = enumerator.Current;
                    mostrarDatosBuilder.AppendLine($"{current.TrackingID} para: {current.DireccionEntrega} en estado: ({current.Estado.ToString()})");
                }
            }
            return mostrarDatosBuilder.ToString();

        }
       
        
        public static Correo operator +(Correo c, Paquete p)
        {
            using (List<Paquete>.Enumerator enumerator = c.paquetes.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        // si no queda nada en el enumerator hago un break.
                        break;
                    }
                    Paquete current = enumerator.Current;
                    if (p == current)
                    {
                        throw new TrackingIdRepetidoException($"Tracking ID {p.TrackingID} ya esta en la lista.");
                    }
                }
            }
            c.paquetes.Add(p);
            Thread item = new Thread(new ThreadStart(p.MockCicloDeVida));
            item.Start();
            c.mockPaquetes.Add(item);
            return c;
        }



        
        
        
        // Properties
        public List<Paquete> Paquetes { get; set; }
        
        
    }
}