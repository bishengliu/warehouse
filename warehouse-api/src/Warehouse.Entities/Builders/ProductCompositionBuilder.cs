using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Entities.Models;

namespace Warehouse.Entities.Builders
{
    public class ProductCompositionBuilder: IEntityTypeConfiguration<ProductComposition>
    {
        public void Configure(EntityTypeBuilder<ProductComposition> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Article)
                .WithMany(b => b.ProductCompositions)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_ProductCompositions");

            builder.HasOne(b => b.Product)
                .WithMany(b => b.ProductCompositions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCompositions");

            builder.Property(b => b.ArticleAmount)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
