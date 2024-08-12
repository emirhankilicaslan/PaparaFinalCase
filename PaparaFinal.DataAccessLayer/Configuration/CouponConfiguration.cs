using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.Property(x => x.CouponCode).IsRequired(true).HasMaxLength(10);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.DiscountAmount).IsRequired(true);
        builder.Property(x => x.ExpireDate).IsRequired(true);
        
        builder.HasIndex(x => x.CouponCode).IsUnique(true);
    }
}