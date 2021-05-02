using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.Exceptions
{
    public class ArticleNotFoundException: Exception
    {
        public ArticleNotFoundException() { }
        public ArticleNotFoundException(string message)
            : base(message)
        {
        }

        public ArticleNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
