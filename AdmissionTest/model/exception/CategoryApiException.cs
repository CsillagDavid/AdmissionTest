using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AdmissionTest.model.exception {
    public class CategoryApiException : Exception {
        public CategoryApiException()
        {
        }

        public CategoryApiException(string message) : base(message)
        {
        }

        public CategoryApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CategoryApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
