using System;
using System.Runtime.Serialization;

namespace AdmissionTest.model.exception {
    public class SubcategoryException: Exception {
        public SubcategoryException()
        {
        }

        public SubcategoryException(string message) : base(message)
        {
        }

        public SubcategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SubcategoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
