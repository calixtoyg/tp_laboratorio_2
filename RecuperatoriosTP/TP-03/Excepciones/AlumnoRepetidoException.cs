using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException()
        {
        }

        public AlumnoRepetidoException(string message) : base(message)
        {
        }
    }
}