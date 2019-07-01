using System;

namespace TP_04
{
    public class Paquete
    {
        public EventHandler<EventArgs> InformarEstado;
        
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
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
        Ingresado,EnViaje,Entregado
    }
}