using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Warehouse.Entities.Models;

namespace Warehouse.Entities.Builders
{
    public class ArticleBuilder: IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.Stock)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(b => b.UpdateAt)
                .HasDefaultValue(DateTime.UtcNow);

        }
    }
}
