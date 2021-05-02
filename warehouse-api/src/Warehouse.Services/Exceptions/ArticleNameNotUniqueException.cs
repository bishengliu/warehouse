using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class ArticleNameNotUniqueException : Exception
    {
        public ArticleNameNotUniqueException()
        {
        }

        public ArticleNameNotUniqueException(string message)
            : base(message)
        {
        }

        public ArticleNameNotUniqueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
