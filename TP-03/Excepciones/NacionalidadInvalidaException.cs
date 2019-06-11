using System;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {
        }

        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
        
    }
}