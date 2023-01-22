using System.Runtime.Serialization;

namespace Flower_shop.Models.Enums
{
    public enum PaymentEvent
    {
        [EnumMember(Value = "payment.succeeded")]
        PaymentSucceeded,

        [EnumMember(Value = "payment.waiting_for_capture")]
        PaymentWaitingForCapture,

        [EnumMember(Value = "payment.canceled")]
        PaymentCanceled,

        [EnumMember(Value = "refund.succeeded")]
        RefundSucceeded

    }
}
