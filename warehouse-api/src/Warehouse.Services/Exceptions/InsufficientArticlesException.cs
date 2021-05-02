using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class InsufficientArticlesException : Exception
    {
        public InsufficientArticlesException()
        {
        }

        public InsufficientArticlesException(string message)
            : base(message)
        {
        }

        public InsufficientArticlesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
