using System;
using System.Runtime.Serialization;

namespace SeleniumingIT
{
    [Serializable]
    internal class PostingFaildException : Exception
    {
        public PostingFaildException()
        {
        }

        public PostingFaildException(string message) : base(message)
        {
        }

        public PostingFaildException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PostingFaildException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}