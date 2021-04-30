using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities.Builders;
using Warehouse.Entities.Models;

namespace Warehouse.Entities
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleBuilder());
            modelBuilder.ApplyConfiguration(new ProductBuilder());
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Product> Product { get; set; }
    }
}
