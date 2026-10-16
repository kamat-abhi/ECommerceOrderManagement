using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneTOMany.Data;

namespace OneTOMany.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics", Description = "Electronic devices and accessories" },
                new Category { CategoryId = 2, CategoryName = "Clothing", Description = "Clothing and fashion products" },
                new Category { CategoryId = 3, CategoryName = "Books", Description = "Educational and programming books" }
            );

            builder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Laptop", Description = "High-performance laptop", Price = 50000m, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853", IsActive = true },
                new Product { ProductId = 2, ProductName = "Mobile", Description = "Smartphone with modern features", Price = 20000m, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9", IsActive = true },
                new Product { ProductId = 3, ProductName = "Keyboard", Description = "USB computer keyboard", Price = 1500m, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3", IsActive = true },
                new Product { ProductId = 4, ProductName = "Mouse", Description = "Wireless computer mouse", Price = 500m, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1527814050087-3793815479db", IsActive = true },
                new Product { ProductId = 5, ProductName = "Headphones", Description = "Over-ear audio headphones", Price = 2500m, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e", IsActive = true },
                new Product { ProductId = 6, ProductName = "T-Shirt", Description = "Cotton casual T-shirt", Price = 800m, CategoryId = 2, ImageUrl = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab", IsActive = true },
                new Product { ProductId = 7, ProductName = "Jeans", Description = "Denim jeans for everyday wear", Price = 1800m, CategoryId = 2, ImageUrl = "https://images.unsplash.com/photo-1542272604-787c3835535d", IsActive = true },
                new Product { ProductId = 8, ProductName = "C# Programming", Description = "Learn C# programming fundamentals", Price = 600m, CategoryId = 3, ImageUrl = "https://images.unsplash.com/photo-1532012197267-da84d127e765", IsActive = true },
                new Product { ProductId = 9, ProductName = "ASP.NET Core", Description = "Guide to ASP.NET Core development", Price = 750m, CategoryId = 3, ImageUrl = "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c", IsActive = true },
                new Product { ProductId = 10, ProductName = "SQL Server Guide", Description = "Learn SQL Server and database management", Price = 500m, CategoryId = 3, ImageUrl = "https://images.unsplash.com/photo-1507842217343-583bb7270b66", IsActive = true }
            );
        }


    }
}
