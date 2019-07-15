using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string message) : base(message)
        {
            
        }
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
        
    }
}
