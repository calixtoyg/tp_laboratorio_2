using System;
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
            foreach (Thread thread in this.mockPaquetes)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }

        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> paquetes = ((Correo) elementos).paquetes;
            StringBuilder builder = new StringBuilder();
            foreach (Paquete paquete in paquetes)
            {
                builder.AppendLine($"{paquete.TrackingID} para {paquete.DireccionEntrega} ({paquete.Estado.ToString()})");
            }
            return builder.ToString();

        }


        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.paquetes)
            {
                if (p == paquete)
                {
                    throw new TrackingIdRepetidoException($"El Tracking ID {p.TrackingID} ya figura en la lista de envios.");
                }
            }
            c.paquetes.Add(p);
            Thread item = new Thread(new ThreadStart(p.MockCicloDeVida));
            item.Start();
            c.mockPaquetes.Add(item);
            return c;
   
        }


        // Properties
        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
    }
}