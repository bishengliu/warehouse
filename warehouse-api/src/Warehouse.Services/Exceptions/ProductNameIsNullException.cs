using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class ProductNameIsNullException : Exception
    {
        public ProductNameIsNullException() { }
        public ProductNameIsNullException(string message)
            : base(message)
        {
        }

        public ProductNameIsNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
