using Flower_shop.EfStuff.DbModels;
using Flower_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flower_shop.EfStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeProduct> TypesProduct { get; set; }
        public WebDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<TypeProduct>()
                .HasMany(x => x.Products)
                .WithOne(x => x.TypeProduct)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
