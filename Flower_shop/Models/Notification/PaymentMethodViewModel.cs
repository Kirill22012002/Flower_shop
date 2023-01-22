namespace Flower_shop.Models.Notification
{
    public class PaymentMethodViewModel
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public bool Saved { get; set; }
        public string Title { get; set; }
        public PaymentCardViewModel Card { get; set; }

    }
}
