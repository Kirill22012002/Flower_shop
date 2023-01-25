namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class NotificationRepository :  BaseRepository<Notification> , INotificationRepository
    {
        public NotificationRepository(WebDbContext context) : base(context)
        {
        }

    }
}
