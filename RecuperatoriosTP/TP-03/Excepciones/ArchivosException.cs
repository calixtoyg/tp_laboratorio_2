using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception e) : base(e.Message, e)
        {
            
        }

    }
}