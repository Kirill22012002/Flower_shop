using Flower_shop.Models.Notification;
using Yandex.Checkout.V3;

namespace Flower_shop.Services.Implimentations
{
    public class PaymentService : IPaymentService
    {
        private IWalletRepository _walletRepository;
        private INotificationRepository _notificationRepository;
        private IMapper _mapper;
        private ILogger<PaymentService> _logger;

        private readonly string SuccessUrl = "http://SuccessUrl";
        private readonly string UnsuccessUrl = "http://UnsuccessUrl";
        private readonly string ErrorUrl = "http://ErrorUrl";

        public PaymentService(
            IWalletRepository walletRepository,
            IMapper mapper,
            ILogger<PaymentService> logger,
            INotificationRepository notificationRepository)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
            _logger = logger;
            _notificationRepository = notificationRepository;
        }

        public async Task<string> Transaction(NotificationViewModel notificationVm)
        {
            var returnUrl = await CheckTransaction(notificationVm);

            return returnUrl;
        }

        public async Task<string> CheckTransaction(NotificationViewModel notificationVm)
        {
            var paymentStatus = notificationVm.Object.Status.ToString().ToLower();

            _logger.LogInformation($"CheckTransaction: paymentStatus: {paymentStatus}");

            if (paymentStatus == PaymentStatus.Succeeded.ToString().ToLower())
            {
                bool saved = await SaveNotificationAsync(notificationVm);

                _logger.LogInformation($"CheckTransaction: Saved data is {saved}");

                if (saved == true)
                {
                    PutMoneyIntoAccount(notificationVm);
                    return SuccessUrl;
                }

                return UnsuccessUrl;
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
                var customerId = _notificationRepository.GetCustomerIdByPaymentId(notificationVm.Object.Id);
                var wallet = _walletRepository.GetByCustomerId(customerId);
                float inputAmount;
                bool isParsed = float.TryParse(notificationVm.Object.Amount.Value.ToString(), out inputAmount);

                _logger.LogInformation($"PutMoneyIntoAccount: Amount was parsed is: {isParsed}");
                _logger.LogInformation($"PutMoneyIntoAccount: CustomerAmount before payment: {wallet.Count}");

                wallet.Count += inputAmount;

                _logger.LogInformation($"PutMoneyIntoAccount: CustomerAmount after payment: {wallet.Count}");

                _walletRepository.Update(wallet);

            }
            catch (Exception ex)
            {
                _logger.LogError($"PutMoneyIntoAccount exception: {ex.Message}");
            }
        }

        public async Task<bool> SaveNotificationAsync(NotificationViewModel notificationVm)
        {
            var notificationDb = _mapper.Map<Notification>(notificationVm);

            return await _notificationRepository.SaveAsync(notificationDb);
        }

    }
}