using Flower_shop.Models.Notification;

namespace Flower_shop.EfStuff.DbModels
{
    public class Notification : BaseModel
    {
        public string PaymentType { get; set; }
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
        public string PaymentMethodTitle { get; set; }
        public string PaymentCardFirst6 { get; set; }
        public string PaymentCardLast4 { get; set; }
        public string PaymentCardExpiryYear { get; set; }
        public string PaymentCardExpiryMonth { get; set; }
        public string PaymentCardType { get; set; }
        public string PaymentIssuerCountry { get; set; }
        public DateTime CapturedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool PaymentTest { get; set; }
        public string RefundedAmountValue { get; set; }
        public string RefundedAmountCurrency { get; set; }
        public bool PaymentPaid { get; set; }
        public bool PaymentRefundable { get; set; }
        public string AuthorizationDetailsRrn { get; set; }
        public string AuthorizationAuthCode { get; set; }
        public bool ThreeDSecureApplied { get; set; }
        public bool ThreeDSecureMethodCompleted { get; set; }
        public bool ThreeDSecureChallengeCompleted { get; set; }
    }
}
