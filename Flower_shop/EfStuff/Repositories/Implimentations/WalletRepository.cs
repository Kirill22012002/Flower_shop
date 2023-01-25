namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(WebDbContext context) : base(context)
        {
        }

        public Wallet GetByCustomerId(string customerId)
        {
            return _webContext.Wallets.SingleOrDefault(x => x.CustomerId == customerId);
        }

    }
}
