using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(250);

        builder.Property(t => t.Price).HasPrecision(10,2);
        
        builder.HasOne(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryId);
    }
}