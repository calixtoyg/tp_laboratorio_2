using System;

namespace CustomExceptions
{
    public class DatoNoCompletadoException : Exception
    {
        public DatoNoCompletadoException(string message) : base(message)
        {
        }
    }
}