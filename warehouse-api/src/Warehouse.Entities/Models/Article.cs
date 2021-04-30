﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Entities.Models
{
    public class Article
    {
        public Article()
        {
            ProductDefinitions = new HashSet<ProductDefinition>();
            UpdateAt = DateTime.UtcNow;
            UpdateBy = "DemoUser";
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public DateTime UpdateAt { get; set; }
        public string   UpdateBy { get; set; }

        public virtual ICollection<ProductDefinition> ProductDefinitions { get; set; }
    }
}
