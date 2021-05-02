using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class ProductNameNotUniqueException : Exception
    {
        public ProductNameNotUniqueException()
        {
        }

        public ProductNameNotUniqueException(string message)
            : base(message)
        {
        }

        public ProductNameNotUniqueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
