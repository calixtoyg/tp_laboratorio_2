using System;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
        {
        }

        public SinProfesorException(string message) : base(message)
        {
        }
        
    }
}