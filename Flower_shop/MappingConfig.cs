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
                config.CreateMap<Product, ProductViewModel>().ReverseMap();
                config.CreateMap<ProductViewModel, ProductViewModel>();
                config.CreateMap<User, UserViewModel>().ReverseMap();
                config.CreateMap<RegisterViewModel, User>().ReverseMap();
                config.CreateMap<TypeProduct, TypeProductViewModel>().ReverseMap();
                config.CreateMap<Image, ImageViewModel>().ReverseMap();
                config.CreateMap<Color, ColorViewModel>().ReverseMap();
                config.CreateMap<Notification, NotificationViewModel>()
                        .ForMember(nameof(NotificationViewModel.Type),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentType))
                        .ForMember(nameof(NotificationViewModel.Event),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentEvent))
                        .ForMember(nameof(NotificationViewModel.Object.Id),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentId))
                        .ForMember(nameof(NotificationViewModel.Object.Status),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentStatus))
                        .ForMember(nameof(NotificationViewModel.Object.Amount.Value),
                    opt => opt
                        .MapFrom(model =>
                            model.AmountValue))
                        .ForMember(nameof(NotificationViewModel.Object.Amount.Currency),
                    opt => opt
                        .MapFrom(model =>
                            model.AmountCurrency))
                        .ForMember(nameof(NotificationViewModel.Object.IncomeAmount.Value),
                    opt => opt
                        .MapFrom(model =>
                            model.IncomeAmountValue))
                        .ForMember(nameof(NotificationViewModel.Object.Recipient.AccountId),
                    opt => opt
                        .MapFrom(model =>
                            model.RecipientAccountId))
                        .ForMember(nameof(NotificationViewModel.Object.Recipient.GatewayId),
                    opt => opt
                        .MapFrom(model =>
                            model.RecipientGatewayId))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Type),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentMethodType))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Id),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentMethodId))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Saved),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentMethodSaved))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Title),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentMethodTitle))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Card.First6),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentCardFirst6))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Card.Last4),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentCardLast4))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Card.ExpiryYear),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentCardExpiryYear))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Card.ExpiryMonth),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentCardExpiryMonth))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Card.CardType),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentCardType))
                        .ForMember(nameof(NotificationViewModel.Object.PaymentMethod.Card.IssuerCountry),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentIssuerCountry))
                        .ForMember(nameof(NotificationViewModel.Object.CapturedAt),
                    opt => opt
                        .MapFrom(model =>
                            model.CapturedAt))
                        .ForMember(nameof(NotificationViewModel.Object.CreatedAt),
                    opt => opt
                        .MapFrom(model =>
                            model.CreatedAt))
                        .ForMember(nameof(NotificationViewModel.Object.Test),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentTest))
                        .ForMember(nameof(NotificationViewModel.Object.RefundedAmount.Value),
                    opt => opt
                        .MapFrom(model =>
                            model.RefundedAmountValue))
                        .ForMember(nameof(NotificationViewModel.Object.RefundedAmount.Currency),
                    opt => opt
                        .MapFrom(model =>
                            model.RefundedAmountCurrency))
                        .ForMember(nameof(NotificationViewModel.Object.Paid),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentPaid))
                        .ForMember(nameof(NotificationViewModel.Object.Refundable),
                    opt => opt
                        .MapFrom(model =>
                            model.PaymentRefundable))
                        .ForMember(nameof(NotificationViewModel.Object.AuthorizationDetails.Rrn),
                    opt => opt
                        .MapFrom(model =>
                            model.AuthorizationDetailsRrn))
                        .ForMember(nameof(NotificationViewModel.Object.AuthorizationDetails.AuthCode),
                    opt => opt
                        .MapFrom(model =>
                            model.AuthorizationAuthCode))
                        .ForMember(nameof(NotificationViewModel.Object.AuthorizationDetails.ThreeDSecure.Applied),
                    opt => opt
                        .MapFrom(model =>
                            model.ThreeDSecureApplied))
                        .ForMember(nameof(NotificationViewModel.Object.AuthorizationDetails.ThreeDSecure.MethodCompleted),
                    opt => opt
                        .MapFrom(model =>
                            model.ThreeDSecureMethodCompleted))
                        .ForMember(nameof(NotificationViewModel.Object.AuthorizationDetails.ThreeDSecure.ChallengeCompleted),
                    opt => opt
                        .MapFrom(model =>
                            model.ThreeDSecureChallengeCompleted))
                    .ReverseMap();
            });
        }
    }
}