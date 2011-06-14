using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibRawNet.Native {
    [Serializable]
    public class LibRawNativeException : Exception {
        public LibRawNativeException() {
        }

        public LibRawNativeException(string message) : base(message) {
        }

        public LibRawNativeException(string message, Exception inner) : base(message, inner) {
        }

        protected LibRawNativeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {
        }
    }
}
