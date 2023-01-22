namespace Flower_shop.Models.Notification
{
    public class NotificationViewModel
    {
        public string Type { get; set; }
        public string Event { get; set; }
        public PaymentObjectViewModel Object { get; set; }

    }
}