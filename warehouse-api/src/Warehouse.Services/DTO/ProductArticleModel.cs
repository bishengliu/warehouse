using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Services.DTO
{
    public class ProductArticleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; } // total article price * amount
    }
}
