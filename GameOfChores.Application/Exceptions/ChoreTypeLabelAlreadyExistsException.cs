using System;
using System.Runtime.Serialization;

namespace GameOfChores.Application.Exceptions
{
    [Serializable]
    public class ChoreTypeLabelAlreadyExistsException : Exception
    {
        public ChoreTypeLabelAlreadyExistsException()
        {
        }

        protected ChoreTypeLabelAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
