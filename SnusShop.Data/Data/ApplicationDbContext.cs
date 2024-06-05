using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SnusShop.Data.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace SnusShop.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<OrderProduct> OrdersProducts { get; set; } = null!;
        public DbSet<SellerProduct> SellersProducts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<SellerProduct>()
            .HasKey(sp => new { sp.SellerId, sp.ProductId });

            base.OnModelCreating(builder);
        }
    }
}
