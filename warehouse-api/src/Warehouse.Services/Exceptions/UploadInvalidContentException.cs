using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class UploadInvalidContentException : Exception
    {
        public UploadInvalidContentException() { }
        public UploadInvalidContentException(string message)
            : base(message)
        {
        }

        public UploadInvalidContentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
