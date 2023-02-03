namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface ICustomerWalletRepository : IBaseRepository<CustomerWallet>
    {
        Task<CustomerWallet> GetByCustomerIdAsync(string customerId);

    }
}