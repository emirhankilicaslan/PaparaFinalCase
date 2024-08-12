using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.Tag).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.Url).IsRequired(true).HasMaxLength(20);
        
        builder.HasIndex(x => x.Name).IsUnique(true);
    }
}