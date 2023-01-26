using Flower_shop.EfStuff.DbModels;
using Flower_shop.Models.Notification;
using Yandex.Checkout.V3;

namespace Flower_shop
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<NotificationViewModel, Notification>()
                        .ForMember(nameof(Notification.PaymentType),
                            opt => opt
                        .MapFrom(model =>
                            model.Type))
                        .ForMember(nameof(Notification.PaymentEvent),
                            opt => opt
                        .MapFrom(model =>
                            model.Event))
                        .ForMember(nameof(Notification.PaymentStatus),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Status))
                        .ForMember(nameof(Notification.PaymentId),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Id))
                        .ForMember(nameof(Notification.AmountValue),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Amount.Value))
                        .ForMember(nameof(Notification.AmountValue),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Amount.Value))
                        .ForMember(nameof(Notification.AmountCurrency),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Amount.Currency))
                        .ForMember(nameof(Notification.IncomeAmountValue),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.IncomeAmount.Value))
                        .ForMember(nameof(Notification.IncomeAmountCurrency),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.IncomeAmount.Currency))
                        .ForMember(nameof(Notification.RecipientAccountId),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Recipient.AccountId))
                        .ForMember(nameof(Notification.RecipientGatewayId),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Recipient.GatewayId))
                        .ForMember(nameof(Notification.PaymentMethodType),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Type))
                        .ForMember(nameof(Notification.PaymentMethodId),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Id))
                        .ForMember(nameof(Notification.PaymentMethodSaved),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Saved))
                        .ForMember(nameof(Notification.PaymentMethodTitle),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Title))
                        .ForMember(nameof(Notification.PaymentCardFirst6),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Card.First6))
                        .ForMember(nameof(Notification.PaymentCardLast4),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Card.Last4))
                        .ForMember(nameof(Notification.PaymentCardExpiryYear),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Card.ExpiryYear))
                        .ForMember(nameof(Notification.PaymentCardExpiryYear),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Card.ExpiryYear))
                        .ForMember(nameof(Notification.PaymentCardExpiryMonth),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Card.ExpiryMonth))
                        .ForMember(nameof(Notification.PaymentCardType),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Card.CardType))
                        .ForMember(nameof(Notification.PaymentIssuerCountry),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.PaymentMethod.Card.IssuerCountry))
                        .ForMember(nameof(Notification.CapturedAt),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.CapturedAt.ToString()))
                        .ForMember(nameof(Notification.CreatedAt),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.CreatedAt.ToString()))
                        .ForMember(nameof(Notification.PaymentTest),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Test))
                        .ForMember(nameof(Notification.RefundedAmountValue),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.RefundedAmount.Value))
                        .ForMember(nameof(Notification.RefundedAmountCurrency),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.RefundedAmount.Currency))
                        .ForMember(nameof(Notification.PaymentPaid),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Paid))
                        .ForMember(nameof(Notification.PaymentRefundable),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Refundable))
                        .ForMember(nameof(Notification.AuthorizationDetailsRrn),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.AuthorizationDetails.Rrn))
                        .ForMember(nameof(Notification.AuthorizationAuthCode),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.AuthorizationDetails.AuthCode))
                        .ForMember(nameof(Notification.ThreeDSecureApplied),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.AuthorizationDetails.ThreeDSecure.Applied))
                        .ForMember(nameof(Notification.ThreeDSecureMethodCompleted),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.AuthorizationDetails.ThreeDSecure.MethodCompleted))
                        .ForMember(nameof(Notification.ThreeDSecureChallengeCompleted),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.AuthorizationDetails.ThreeDSecure.ChallengeCompleted))
                        .ForMember(nameof(Notification.CustomerId),
                            opt => opt
                        .MapFrom(model =>
                            model.Object.Metadata["customerId"]))
                        .ReverseMap();
            });
        }
    }
}