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

        /// <summary>
        /// Hace un mock del ciclo de vida de un paquete
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(10000);
                this.estado += 1;
                this.InformarEstado(this, new EventArgs());
            } while (this.estado != EEstado.Entregado);

            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra los datos de la lista de paquetes.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> lista)
        {
            Paquete paquete = (Paquete) lista;
            return $"{paquete.trackingID} para direccion: {paquete.direccionEntrega}";
        }

        /// <summary>
        /// Verifica la igualdad de paquetes mediante el trackingID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
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

    /// <summary>
    /// Enum con los estados del paquete
    /// </summary>
    public enum EEstado
    {
        Ingresado,
        EnViaje,
        Entregado
    }
}