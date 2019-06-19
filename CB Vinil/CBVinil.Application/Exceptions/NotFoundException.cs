using System;
using System.Runtime.Serialization;

namespace CBVinil.Application.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        public NotFoundException(string name, object key)
            : base($"Entidade \"{name}\" ({key}) não foi encontrada.")
        { }
    }
}
