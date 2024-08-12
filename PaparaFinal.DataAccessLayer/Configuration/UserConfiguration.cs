using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.IdentityNumber).IsRequired(true).HasMaxLength(11);
        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(25);

        builder.HasIndex(x => new { x.UserName }).IsUnique(true);
        builder.HasIndex(x => new { x.IdentityNumber }).IsUnique(true);
        builder.HasIndex(x => new { x.Email }).IsUnique(true);
        
        builder.HasOne(x => x.DigitalWallet)
            .WithOne(x => x.User)
            .HasForeignKey<DigitalWallet>(x => x.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Cart)
            .WithOne(x => x.User)
            .HasForeignKey<Cart>(x => x.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Coupons)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
    }
}