using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{

    public class AuthorizationDetailsViewModel
    {
        [JsonPropertyName("rrn")]
        public string Rrn { get; set; }

        [JsonPropertyName("auth_code")]
        public string AuthCode { get; set; }

        [JsonPropertyName("three_d_secure")]
        public ThreeDSecureViewModel ThreeDSecure { get; set; }

    }
}
