namespace Flower_shop.EfStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeProduct> TypesProduct { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<MyPayment> MyPayments { get; set; }


        public WebDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
