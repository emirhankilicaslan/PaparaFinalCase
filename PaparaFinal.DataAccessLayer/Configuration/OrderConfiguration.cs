using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.OrderNumber).IsRequired(true).HasMaxLength(9);
        builder.Property(x => x.OrderDate).IsRequired(true);
        builder.Property(x => x.Status).IsRequired(true);

        builder.HasOne(x => x.OrderDetail)
            .WithOne(x => x.Order)
            .HasForeignKey<OrderDetail>(x => x.OrderId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
    }
}