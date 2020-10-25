using System;
using System.Runtime.Serialization;

namespace GameOfChores.Application.Exceptions
{
    [Serializable]
    public class ChoreTypeAlreadyExistsException : Exception
    {
        public ChoreTypeAlreadyExistsException()
        {
        }

        protected ChoreTypeAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
