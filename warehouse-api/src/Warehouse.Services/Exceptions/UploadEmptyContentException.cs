using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class UploadEmptyContentException : Exception
    {
        public UploadEmptyContentException() { }
        public UploadEmptyContentException(string message)
            : base(message)
        {
        }

        public UploadEmptyContentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
