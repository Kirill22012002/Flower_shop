namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Wallet GetByCustomerId(string customerId);
    }
}