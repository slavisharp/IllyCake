namespace IllyCake.Common.Exeptions
{
    using System;
    using System.Runtime.Serialization;

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) :base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EntityNotFoundException(SerializationInfo info, StreamingContext context) :base(info, context)
        {
        }
    }
}
