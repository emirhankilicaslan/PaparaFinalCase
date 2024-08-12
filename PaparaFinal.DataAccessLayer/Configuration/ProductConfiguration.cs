using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Description).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Price).IsRequired(true);
        builder.Property(x => x.UnitsInStock).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
    }
}