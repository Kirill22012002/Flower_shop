using Flower_shop.Models.Enums;
using Flower_shop.Models.Notification;
using Microsoft.OpenApi.Extensions;

namespace Flower_shop.Services.Implimentations
{
    public class PaymentService : IPaymentService
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;

        private readonly string SuccessUrl = "http://SuccessUrl";
        private readonly string UnsuccessUrl = "http://UnsuccessUrl";
        private readonly string ErrorUrl = "http://ErrorUrl";

        public PaymentService(
            WebDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public string Transaction(NotificationViewModel notificationVm)
        {
            var returnUrl = CheckTransaction(notificationVm);

            return returnUrl;
        }

        public string CheckTransaction(NotificationViewModel notificationVm)
        {
            if (notificationVm.Event == "payment.succeeded")
            {
                return SuccessUrl;
            }
            else if (notificationVm.Object.Status == "payment.canceled")
            {
                return UnsuccessUrl;
            }

            return ErrorUrl;
        }

    }
}
