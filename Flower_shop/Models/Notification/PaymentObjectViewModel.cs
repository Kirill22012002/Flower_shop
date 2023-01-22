namespace Flower_shop.Models.Notification
{
    public class PaymentObjectViewModel
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public PaymentAmountViewModel Amount { get; set; }
        public PaymentAmountViewModel IncomeAmount { get; set; }
        public PaymentRecipientViewModel Recipient { get; set; }
        public PaymentMethodViewModel PaymentMethod { get; set; }
        public DateTime CapturedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Test { get; set; }
        public PaymentAmountViewModel RefundedAmount { get; set; }
        public bool Paid { get; set; }
        public bool Refundable { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public AuthorizationDetailsViewModel AuthorizationDetails { get; set; }
    }
}
