using Flower_shop.Models.Enums;
using Flower_shop.Models.Notification;
using Microsoft.OpenApi.Extensions;

namespace Flower_shop.Services.Implimentations
{
    public class PaymentService : IPaymentService
    {
        private WebDbContext _dbContext;
        private IWalletRepository _walletRepository;
        private IMapper _mapper;

        private readonly string SuccessUrl = "http://SuccessUrl";
        private readonly string UnsuccessUrl = "http://UnsuccessUrl";
        private readonly string ErrorUrl = "http://ErrorUrl";

        public PaymentService(
            WebDbContext dbContext,
            IWalletRepository walletRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _walletRepository = walletRepository;
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
                PutMoneyIntoAccount(notificationVm);

                return SuccessUrl;
            }
            else if (notificationVm.Object.Status == "payment.canceled")
            {
                return UnsuccessUrl;
            }

            return ErrorUrl;
        }
        public void PutMoneyIntoAccount(NotificationViewModel notificationVm)
        {
            string customerId = notificationVm.Object.Metadata["customerId"];
            decimal ammount = Decimal.Parse(notificationVm.Object.Amount.Value);


            if (customerId != null)
            {
                var wallet = _walletRepository.GetByCustomerId(customerId);
                wallet.Count += ammount;

                _dbContext.SaveChanges();
            }
        }

    }
}