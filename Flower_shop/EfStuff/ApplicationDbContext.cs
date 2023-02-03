namespace Flower_shop.EfStuff
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<CustomerWallet> CustomerWallets { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
