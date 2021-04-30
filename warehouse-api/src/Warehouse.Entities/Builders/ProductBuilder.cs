using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities.Models;

namespace Warehouse.Entities.Builders
{
    public class ProductBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(b => b.UpdateAt)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
