using System;
using System.Runtime.Serialization;

namespace CBVinil.Application.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        public BusinessException(string message)
            : base(message)
        { }
    }
}
