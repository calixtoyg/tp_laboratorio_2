using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
        {
        }

        public DniInvalidoException(string message) : base(message)
        {
        }
    }
}