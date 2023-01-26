using Flower_shop.Models.Enums;
using Flower_shop.Models.Notification;
using Microsoft.OpenApi.Extensions;
using Yandex.Checkout.V3;

namespace Flower_shop.Services.Implimentations
{
    public class PaymentService : IPaymentService
    {
        private WebDbContext _dbContext;
        private IWalletRepository _walletRepository;
        private IMapper _mapper;
        private ILogger<PaymentService> _logger;

        private readonly string SuccessUrl = "http://SuccessUrl";
        private readonly string UnsuccessUrl = "http://UnsuccessUrl";
        private readonly string ErrorUrl = "http://ErrorUrl";

        public PaymentService(
            WebDbContext dbContext,
            IWalletRepository walletRepository,
            IMapper mapper,
            ILogger<PaymentService> logger)
        {
            _dbContext = dbContext;
            _walletRepository = walletRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public string Transaction(NotificationViewModel notificationVm)
        {
            var returnUrl = CheckTransaction(notificationVm);

            return returnUrl;
        }

        public string CheckTransaction(NotificationViewModel notificationVm)
        {
            var paymentStatus = notificationVm.Object.Status.ToString().ToLower();

            if (paymentStatus == PaymentStatus.Succeeded.ToString().ToLower())
            {
                PutMoneyIntoAccount(notificationVm);

                return SuccessUrl;
            }
            else if (paymentStatus == PaymentStatus.Canceled.ToString().ToLower())
            {
                return UnsuccessUrl;
            }

            return ErrorUrl;
        }

        public void PutMoneyIntoAccount(NotificationViewModel notificationVm)
        {
            try
            {
                string customerId = notificationVm.Object.Metadata["customerId"];
                decimal amount = Decimal.Parse(notificationVm.Object.Amount.Value);

                var wallet = _walletRepository.GetByCustomerId(customerId);
                wallet.Count += amount;

                _dbContext.Wallets.Update(wallet);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError($"PutMoneyIntoAccount exception: {ex.Message}");
            }
        }

    }
}