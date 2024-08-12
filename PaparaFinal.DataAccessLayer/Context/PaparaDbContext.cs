using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PaparaFinal.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PaparaFinal.DataAccessLayer.Configuration;

namespace PaparaFinal.DataAccessLayer.Context;

public class PaparaDbContext : IdentityDbContext<User, Role, string>
{
    public PaparaDbContext(DbContextOptions<PaparaDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<DigitalWallet> DigitalWallets { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CouponConfiguration());
        modelBuilder.ApplyConfiguration(new DigitalWalletConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
