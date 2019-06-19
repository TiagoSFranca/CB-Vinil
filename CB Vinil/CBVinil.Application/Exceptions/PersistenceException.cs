using System;
using System.Runtime.Serialization;

namespace CBVinil.Application.Exceptions
{
    [Serializable]
    public class PersistenceException : Exception
    {
        protected PersistenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        public PersistenceException(Exception exception)
            : base("Ocorreu um ou mais erros ao persistir os dados.", exception)
        { }
    }
}
