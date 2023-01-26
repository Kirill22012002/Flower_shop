namespace Flower_shop.EfStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public WebDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
