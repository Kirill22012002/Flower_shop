using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{
    public class PaymentMethodViewModel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("saved")]
        public bool Saved { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("card")]
        public PaymentCardViewModel Card { get; set; }

    }
}
