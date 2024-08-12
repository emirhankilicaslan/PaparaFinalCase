using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
{
    public void Configure(EntityTypeBuilder<CartProduct> builder)
    {
        builder.HasKey(c => c.CartProductId);
        
        builder.HasOne(x => x.Cart)
            .WithMany(c => c.CartProducts)
            .HasForeignKey(x => x.CartId);
        
        builder.HasOne(x => x.Product)
            .WithMany(c => c.CartProducts)
            .HasForeignKey(x => x.ProductId);
    }
}