using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class DigitalWalletConfiguration : IEntityTypeConfiguration<DigitalWallet>
{
    public void Configure(EntityTypeBuilder<DigitalWallet> builder)
    {
        builder.Property(x => x.Balance).IsRequired(true);
    }
}