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

            SeedProducts(builder);
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Description = "Description for product 1", ImageUrl = "https://dip-store.com/_next/image?url=http%3A%2F%2Fstatic.dripeurope.com%2Fproducts%2FPAZ%2Fpaz-x_freeze.png&w=1920&q=75", Price = 19.99m },
                new Product { Id = 2, Name = "Product 2", Description = "Description for product 2", ImageUrl = "https://dip-store.com/_next/image?url=https%3A%2F%2Fstatic.dripeurope.com%2FDIP%2520STORE%2FProducts%2FPAZ%2Fpazz-daytona.png&w=1080&q=75", Price = 24.99m },
                new Product { Id = 3, Name = "Product 3", Description = "Description for product 3", ImageUrl = "https://dip-store.com/_next/image?url=https%3A%2F%2Fstatic.dripeurope.com%2FDIP%2520STORE%2FProducts%2FV%26YOU%2F%26BOOST%2B%2Fboost%2B-cool-berry-new.png&w=1080&q=75", Price = 29.99m },
                new Product { Id = 4, Name = "Product 4", Description = "Description for product 4", ImageUrl = "https://dip-store.com/_next/image?url=http%3A%2F%2Fstatic.dripeurope.com%2Fproducts%2FACE%2Fcool%2520mint%2Face-cool_mint-front-opened.png&w=1080&q=75", Price = 34.99m },
                new Product { Id = 5, Name = "Product 5", Description = "Description for product 5", ImageUrl = "https://dip-store.com/_next/image?url=http%3A%2F%2Fstatic.dripeurope.com%2Fproducts%2FACE%2520X%2Face_x-cool_mint-side.png&w=1080&q=75", Price = 39.99m },
                new Product { Id = 6, Name = "Product 6", Description = "Description for product 6", ImageUrl = "https://dip-store.com/_next/image?url=https%3A%2F%2Fstatic.dripeurope.com%2FDIP%2520STORE%2FProducts%2FV%26YOU%2F%26BOOST%2Fboost-blueberry-old.png&w=1080&q=75", Price = 44.99m }
            );
        }
    }
}
