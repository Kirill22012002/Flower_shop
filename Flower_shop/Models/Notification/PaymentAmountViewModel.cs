using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{
    public class PaymentAmountViewModel
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
