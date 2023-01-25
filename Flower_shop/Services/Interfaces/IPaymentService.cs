using Flower_shop.Models.Notification;

namespace Flower_shop.Services.Interfaces
{
    public interface IPaymentService
    {
        string CheckTransaction(NotificationViewModel notificationVm);
        string Transaction(NotificationViewModel notificationVm);
    }
}