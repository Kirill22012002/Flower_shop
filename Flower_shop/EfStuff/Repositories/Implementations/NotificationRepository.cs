namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class NotificationRepository :  BaseRepository<Notification> , INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> GetCustomerIdByPaymentIdAsync(string paymentId)
        {
            return (await _dbContext.Notifications
                .SingleOrDefaultAsync(x => x.PaymentId == paymentId))
                .CustomerId
                .ToString();
        }
    }
}
