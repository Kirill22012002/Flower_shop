using Flower_shop.Models.Enums;
using Yandex.Checkout.V3;

namespace Flower_shop.Models
{
    public class Transaction
    {
        public PaymentEvent Event { get; set; }
        public Payment Object { get; set; }
    }
}