namespace Flower_shop.Models.Notification
{
    public class PaymentCardViewModel
    {
        public string First6 { get; set; }
        public string Last4 { get; set; }
        public string ExpiryYear { get; set; }
        public string ExpiryMonth { get; set; }
        public string CardType { get; set; }
        public string IssuerCountry { get; set; }
    }
}
