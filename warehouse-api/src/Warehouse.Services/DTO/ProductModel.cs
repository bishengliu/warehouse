using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities.Models;

namespace Warehouse.Services.DTO
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ProductArticleModel> Articles { get; set; }
    }
}
