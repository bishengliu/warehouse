using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class ArticleNameIsNullException : Exception
    {
        public ArticleNameIsNullException() { }
        public ArticleNameIsNullException(string message)
            : base(message)
        {
        }

        public ArticleNameIsNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
