using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities.Models;

namespace Warehouse.Entities.Builders
{
    public class ProductDefinitionBuilder: IEntityTypeConfiguration<ProductDefinition>
    {
        public void Configure(EntityTypeBuilder<ProductDefinition> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Article)
                .WithMany(b => b.ProductDefinitions)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_ProductCompositions");

            builder.HasOne(b => b.Product)
                .WithMany(b => b.ProductDefinitions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCompositions");

            builder.Property(b => b.ArticleAmount)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(b => b.Price)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(b => b.UpdateAt)
                .HasDefaultValue(DateTime.UtcNow);

        }
    }
}
