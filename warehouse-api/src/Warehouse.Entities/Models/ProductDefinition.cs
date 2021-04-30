using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Entities.Models
{
    public class ProductDefinition
    {
        public ProductDefinition()
        {
            UpdateAt = DateTime.UtcNow;
            UpdateBy = "DemoUser";
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int ArticleId { get; set; }
        public int ArticleAmount { get; set; }

        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }

        public virtual Product Product { get; set; }
        public virtual Article Article { get; set; }
    }
}
