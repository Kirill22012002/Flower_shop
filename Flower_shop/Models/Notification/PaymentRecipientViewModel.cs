using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{
    public class PaymentRecipientViewModel
    {
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("gateway_id")]
        public string GatewayId { get; set; }
    }
}
