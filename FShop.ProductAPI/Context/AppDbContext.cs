using FShop.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FShop.ProductAPI.Context
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasKey(c => c.CategoryID);

            mb.Entity<Category>().
                Property(c => c.Name)
                    .HasMaxLength(100)
                        .IsRequired();

            mb.Entity<Product>().
                Property(c => c.Name)
                    .HasMaxLength(100)
                        .IsRequired();

            mb.Entity<Product>().
                Property(c => c.Description)
                    .HasMaxLength(255)
                        .IsRequired();

            mb.Entity<Product>().
                Property(c => c.ImageURL)
                    .HasMaxLength(255)
                        .IsRequired();
            mb.Entity<Product>().
               Property(c => c.Price).
                   HasPrecision(12, 2);

            mb.Entity<Category>()
                .HasMany(g => g.Products)
                    .WithOne(c => c.Category)
                        .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Category>().HasData(
                new Category 
                {
                    CategoryID = 1,
                    Name = "T-Shirt" 
                },
                new Category
                {
                    CategoryID = 2,
                    Name = "Short"
                }
                );

        }
    }
}
