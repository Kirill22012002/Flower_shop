using Flower_shop.Models.Enums;
using Yandex.Checkout.V3;

namespace Flower_shop.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public PaymentEvent Event { get; set; }
        public Payment Object { get; set; }
    }
}