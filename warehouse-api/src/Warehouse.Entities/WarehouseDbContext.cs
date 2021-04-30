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
            modelBuilder.ApplyConfiguration(new ProductDefinitionBuilder());

            modelBuilder.Entity<ProductDefinition>()
                .HasIndex(p => new { p.ProductId, p.ArticleId })
                .IsUnique();

            modelBuilder.Ignore<ProductStock>();
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDefinition> ProductDefinition { get; set; }
        public virtual DbSet<ProductStock> ProductStock { get; set; }
    }
}
