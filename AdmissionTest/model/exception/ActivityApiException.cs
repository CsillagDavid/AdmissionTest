using System;
using System.Runtime.Serialization;

namespace AdmissionTest.model.exception {
    public class ActivityApiException : Exception {
        public ActivityApiException()
        {
        }

        public ActivityApiException(string message) : base(message)
        {
        }

        public ActivityApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ActivityApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
