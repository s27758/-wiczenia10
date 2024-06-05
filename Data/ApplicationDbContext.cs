using Ćwiczenia10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Ćwiczenia10.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductsCategories> ProductsCategories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsCategories>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductsCategories>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductsCategories>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductsCategories)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<ShoppingCart>()
                .HasKey(sc => new { sc.AccountId, sc.ProductId });

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.Account)
                .WithMany(a => a.ShoppingCarts)
                .HasForeignKey(sc => sc.AccountId);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.Product)
                .WithMany(p => p.ShoppingCarts)
                .HasForeignKey(sc => sc.ProductId);
        }
    }
    }
    