using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.DataAccessLayer.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.NormalizedName).IsRequired(true);
        builder.Property(x => x.Description).IsRequired(true).HasMaxLength(20);

        builder.HasData(
            new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Admin Role"
            },
            new Role
            {
                Name = "User",
                NormalizedName = "USER",
                Description = "User Role"
            });
    }
}