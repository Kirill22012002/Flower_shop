namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        Task<string> GetCustomerIdByPaymentIdAsync(string paymentId);

    }
}
