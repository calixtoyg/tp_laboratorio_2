using System;
using System.Threading;
using CustomExceptions;

namespace TP_04
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformarEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
        }


        public void MockCicloDeVida()
        {
           
                do
                {
                    Thread.Sleep(1000);
                    this.estado += 1;
                    this.InformarEstado(this, new EventArgs());
                } while (this.estado != EEstado.Entregado);

                PaqueteDAO.Insertar(this);
            
         
        }

        public string MostrarDatos(IMostrar<Paquete> lista)
        {
            Paquete paquete = (Paquete) lista;
            return $"{paquete.trackingID} para direccion: {paquete.direccionEntrega}";
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


        public override string ToString()
        {
            return MostrarDatos(this);
        }


        public string DireccionEntrega
        {
            get => direccionEntrega;
            set => direccionEntrega = value;
        }

        public EEstado Estado
        {
            get => estado;
            set => estado = value;
        }

        public string TrackingID
        {
            get => trackingID;
            set => trackingID = value;
        }
    }

    public enum EEstado
    {
        Ingresado,
        EnViaje,
        Entregado
    }
}