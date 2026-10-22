using APIVersioningTaskDayOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIVersioningTaskDayOne.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>()
                .HasData(new Category { Id = 1, Name = "Category 1" },
                         new Category { Id = 2, Name = "Category 2" });
            modelBuilder.Entity<Product>()
                .HasData(new Product { Id = 1, Name = "Product 1", Price = 10.99m, CategoryId = 1 },
                         new Product { Id = 2, Name = "Product 2", Price = 19.99m, CategoryId = 1 },
                         new Product { Id = 3, Name = "Product 3", Price = 5.99m, CategoryId = 2 });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
