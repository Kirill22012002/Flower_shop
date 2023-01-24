﻿using System.Text.Json.Serialization;

namespace Flower_shop.Models.Notification
{
    public class PaymentCardViewModel
    {
        [JsonPropertyName("first6")]
        public string First6 { get; set; }

        [JsonPropertyName("last4")]
        public string Last4 { get; set; }

        [JsonPropertyName("expiry_year")]
        public string ExpiryYear { get; set; }

        [JsonPropertyName("expiry_month")]
        public string ExpiryMonth { get; set; }

        [JsonPropertyName("card_type")]
        public string CardType { get; set; }

        [JsonPropertyName("issuer_country")]
        public string IssuerCountry { get; set; }
    }
}
