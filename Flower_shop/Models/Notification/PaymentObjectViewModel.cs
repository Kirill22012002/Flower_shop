using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{
    public class PaymentObjectViewModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
         
        [JsonPropertyName("amount")]
        public PaymentAmountViewModel Amount { get; set; }

        [JsonPropertyName("income_amount")]
        public PaymentAmountViewModel IncomeAmount { get; set; }

        [JsonPropertyName("recipient")]
        public PaymentRecipientViewModel Recipient { get; set; }

        [JsonPropertyName("payment_method")]
        public PaymentMethodViewModel PaymentMethod { get; set; }

        [JsonPropertyName("captured_at")]
        public DateTime CapturedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }

        [JsonPropertyName("refunded_amount")]
        public PaymentAmountViewModel RefundedAmount { get; set; }

        [JsonPropertyName("paid")]
        public bool Paid { get; set; }

        [JsonPropertyName("refundable")]
        public bool Refundable { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonPropertyName("authorization_details")]
        public AuthorizationDetailsViewModel AuthorizationDetails { get; set; }
    }
}
