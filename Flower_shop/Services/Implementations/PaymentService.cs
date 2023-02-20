using AutoMapper.Execution;
using Flower_shop.Models.Notification;
using System.Globalization;
using Yandex.Checkout.V3;

namespace Flower_shop.Services.Implimentations
{
    public class PaymentService : IPaymentService
    {
        private ICustomerWalletRepository _walletRepository;
        private INotificationRepository _notificationRepository;
        private IMapper _mapper;
        private ILogger<PaymentService> _logger;

        private readonly string SuccessUrl = "http://SuccessUrl";
        private readonly string UnsuccessUrl = "http://UnsuccessUrl";
        private readonly string ErrorUrl = "http://ErrorUrl";

        public PaymentService(
            ICustomerWalletRepository walletRepository,
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

            bool saved = await SaveNotificationAsync(notificationVm);

            if (saved == true)
            {
                _logger.LogInformation($"CheckTransaction: Saved data is {saved}");

                if (paymentStatus == PaymentStatus.Succeeded.ToString().ToLower())
                {
                    try
                    {
                        await PutMoneyIntoAccount(notificationVm);

                        return SuccessUrl;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"PutMoneyIntoAccount exception: {ex.Message}");

                        return ErrorUrl;
                    }
                }
                else if (paymentStatus == PaymentStatus.Canceled.ToString().ToLower())
                {
                    return UnsuccessUrl;
                }
            }
            return ErrorUrl;
        }

        public async Task PutMoneyIntoAccount(NotificationViewModel notificationVm)
        {
            var customerId = await _notificationRepository.GetCustomerIdByPaymentIdAsync(notificationVm.Object.Id);
            var wallet = await _walletRepository.GetByCustomerIdAsync(customerId);

            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            var amount = Decimal.Parse(notificationVm.Object.Amount.Value, numberFormatInfo);

            _logger.LogInformation($"PutMoneyIntoAccount: CustomerAmount before payment: {wallet.Count}");

            wallet.Count += amount;

            _logger.LogInformation($"PutMoneyIntoAccount: CustomerAmount after payment: {wallet.Count}");

            await _walletRepository.UpdateAsync(wallet);
        }

        public async Task<bool> SaveNotificationAsync(NotificationViewModel notificationVm)
        {
            var notificationDb = _mapper.Map<Notification>(notificationVm);

            return await _notificationRepository.TryAddAsync(notificationDb);
        }
    }
}
