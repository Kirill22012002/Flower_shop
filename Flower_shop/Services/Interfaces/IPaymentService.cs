using Flower_shop.Models.Notification;
using Yandex.Checkout.V3;

namespace Flower_shop.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> Transaction(NotificationViewModel notificationVm);
        Task<string> CheckTransaction(NotificationViewModel notificationVm);
        Task PutMoneyIntoAccount(NotificationViewModel notificationVm);
        Task<bool> SaveNotificationAsync(NotificationViewModel notificationVm);
        
    }
}