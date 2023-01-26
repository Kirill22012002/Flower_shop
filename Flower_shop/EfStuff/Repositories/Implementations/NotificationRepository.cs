namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class NotificationRepository :  BaseRepository<Notification> , INotificationRepository
    {
        public NotificationRepository(WebDbContext context) : base(context)
        {
        }
        
        public string GetCustomerIdByPaymentId(string paymentId)
        {
            return _webContext.Notifications
                .SingleOrDefault(x => x.PaymentId == paymentId)
                .CustomerId
                .ToString();
        }
    }
}
