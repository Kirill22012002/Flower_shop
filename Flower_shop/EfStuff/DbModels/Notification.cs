namespace Flower_shop.EfStuff.DbModels
{
    public class Notification : BaseModel
    {
        public string PaymentEvent { get; set; }
        public string PaymentId { get; set; }
        public string PaymentStatus { get; set; }
        public string AmountValue { get; set; }
        public string AmountCurrency { get; set; }
        public string IncomeAmountValue { get; set; }
        public string IncomeAmountCurrency { get; set; }    
        public string RecipientAccountId { get; set; }
        public string RecipientGatewayId { get; set; }
        public string PaymentMethodType { get; set; }
        public string PaymentMethodId { get; set; }
        public bool PaymentMethodSaved { get; set; }
        public string CapturedAt { get; set; }
        public string CreatedAt { get; set; }
        public bool Test { get; set; }
        public string RefundedAmountValue { get; set; }
        public string RefundedAmountCurrency { get; set; }
        public bool Paid { get; set; }
    }
}
