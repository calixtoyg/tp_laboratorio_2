using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
        {
            throw this;
        }

        public DniInvalidoException(Exception e)
        {
            throw new DniInvalidoException(e.GetBaseException());
        }

        public DniInvalidoException(string message) : base(message)
        {
            
        }

        public DniInvalidoException(Exception e, string message) : base(message, e)
        {
            
        }
    }
}