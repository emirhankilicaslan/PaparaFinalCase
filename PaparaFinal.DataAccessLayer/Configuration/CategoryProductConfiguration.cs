using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
{
    public void Configure(EntityTypeBuilder<CategoryProduct> builder)
    {
        builder.HasKey(c => c.CategoryProductId);
        
        builder.HasOne(x => x.Category)
            .WithMany(c => c.CategoryProducts)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Product)
            .WithMany(c => c.CategoryProducts)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}