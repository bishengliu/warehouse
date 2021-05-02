using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class ArticleDefinedInProductException: Exception
    {
        public ArticleDefinedInProductException() { }
        public ArticleDefinedInProductException(string message)
            : base(message)
        {
        }

        public ArticleDefinedInProductException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
