using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{
    public class NotificationViewModel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("object")]
        public PaymentObjectViewModel Object { get; set; }

    }
}