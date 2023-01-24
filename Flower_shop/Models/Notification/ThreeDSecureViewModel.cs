using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{
    public class ThreeDSecureViewModel
    {
        [JsonPropertyName("applied")]
        public bool Applied { get; set; }

        [JsonPropertyName("method_completed")]
        public bool MethodCompleted { get; set; }

        [JsonPropertyName("challenge_completed")]
        public bool ChallengeCompleted { get; set; }
    }
}
