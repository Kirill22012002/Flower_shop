namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class CustomerWalletRepository : BaseRepository<CustomerWallet>, ICustomerWalletRepository
    {
        public CustomerWalletRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<CustomerWallet> GetByCustomerIdAsync(string customerId)
        {
            return await _dbContext.CustomerWallets.SingleOrDefaultAsync(x => x.CustomerId == customerId);
        }
    }
}
