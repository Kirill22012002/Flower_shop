using AutoMapper;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.EfStuff.Repositories.Interfaces;
using Flower_shop.Models.Notification;
using Flower_shop.Services.Implimentations;
using Microsoft.Extensions.Logging;
using Moq;
using Yandex.Checkout.V3;

namespace Flower_shop_tests
{

    [TestFixture]
    public class PaymentServiceTests
    {
        private PaymentService _paymentService;
        private Mock<ICustomerWalletRepository> _mockWalletRepository;
        private Mock<INotificationRepository> _mockNotificationRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<ILogger<PaymentService>> _mockLogger;

        private readonly string SuccessUrl = "http://SuccessUrl";
        private readonly string ErrorUrl = "http://ErrorUrl";
        private readonly string UnsuccessUrl = "http://UnsuccessUrl";

        private readonly NotificationViewModel _succeededNotification = new NotificationViewModel
        {
            Object = new PaymentObjectViewModel
            {
                Id = "1",
                Amount = new PaymentAmountViewModel
                {
                    Value = "10.00"
                },
                Status = PaymentStatus.Succeeded.ToString().ToLower(),
                Metadata = new Dictionary<string, string> { { "customerId", "TestCustomerId" } }
            }
        };

        private NotificationViewModel _canceledNotification = new NotificationViewModel
        {
            Object = new PaymentObjectViewModel
            {
                Id = "1",
                Amount = new PaymentAmountViewModel
                {
                    Value = "10.00"
                },
                Status = PaymentStatus.Canceled.ToString().ToLower(),
                Metadata = new Dictionary<string, string> { { "customerId", "TestCustomerId" } }
            }
        };

        [SetUp]
        public void SetUp()
        {
            _mockWalletRepository = new Mock<ICustomerWalletRepository>();
            _mockNotificationRepository = new Mock<INotificationRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<PaymentService>>();

            _paymentService = new PaymentService(
                _mockWalletRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object,
                _mockNotificationRepository.Object);
        }

        [Test]
        public async Task Transaction_ReturnsSuccessUrl_WhenPaymentSucceeded()
        {
            // Arrange
            var customerId = "TestCustomerId";
            var wallet = new CustomerWallet
            {
                CustomerId = customerId,
                Count = 100
            };

            _mockWalletRepository
                .Setup(repo => repo.GetByCustomerIdAsync(customerId))
                .ReturnsAsync(wallet);

            _mockMapper
                .Setup(mapper => mapper.Map<Notification>(It.IsAny<NotificationViewModel>()))
                .Returns(new Notification());

            _mockNotificationRepository
                .Setup(repo => repo.TryAddAsync(It.IsAny<Notification>()))
                .ReturnsAsync(true);

            // Act
            var result = await _paymentService.Transaction(_succeededNotification);

            // Assert
            Assert.AreEqual(SuccessUrl, result);
            Assert.AreEqual(100 + Convert.ToDecimal(_succeededNotification.Object.Amount.Value), wallet.Count);
        }

        [Test]
        public async Task Transaction_ReturnsSuccessUrl_WhenPaymentSucceeded_AndPutMoneyIntoAccountSucceeds()
        {
            // Arrange
            _mockNotificationRepository
                .Setup(x => x.TryAddAsync(It.IsAny<Notification>()))
                .ReturnsAsync(true);

            _mockWalletRepository
                .Setup(x => x.GetByCustomerIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new CustomerWallet { Count = 0 });

            // Act
            var result = await _paymentService.Transaction(_succeededNotification);

            // Assert
            Assert.AreEqual(SuccessUrl, result);
            _mockWalletRepository.Verify(x => x.UpdateAsync(It.IsAny<CustomerWallet>()));
        }

        [Test]
        public async Task Transaction_ReturnsUnsuccessUrl_WhenPaymentCanceled()
        {
            // Arrange
            _mockMapper
                .Setup(mapper => mapper.Map<Notification>(It.IsAny<NotificationViewModel>()))
                .Returns(new Notification());

            _mockNotificationRepository
                .Setup(repo => repo.TryAddAsync(It.IsAny<Notification>()))
                .ReturnsAsync(true);

            // Act
            var result = await _paymentService.Transaction(_canceledNotification);

            // Assert
            Assert.AreEqual(UnsuccessUrl, result);
        }

        [Test]
        public async Task Transaction_ReturnsErrorUrl_WhenSaveNotificationAsyncReturnsFalse()
        {
            // Arrange
            var notificationVm = new NotificationViewModel
            {
                Object = new PaymentObjectViewModel
                {
                    Id = "1",
                    Amount = new PaymentAmountViewModel
                    {
                        Value = "10.00"
                    },
                    Status = PaymentStatus.Succeeded.ToString().ToLower()
                }
            };

            _mockNotificationRepository
                .Setup(x => x.TryAddAsync(It.IsAny<Notification>()))
                .ReturnsAsync(false);

            // Act
            var result = await _paymentService.Transaction(notificationVm);

            // Assert
            Assert.AreEqual(ErrorUrl, result);
        }

        [Test]
        public async Task Transaction_ReturnsErrorUrl_WhenPaymentSucceeded_AndPutMoneyIntoAccountThrowsException()
        {
            // Arrange
            _mockNotificationRepository
                .Setup(x => x.TryAddAsync(It.IsAny<Notification>()))
                .ReturnsAsync(true);

            _mockWalletRepository
                .Setup(x => x.GetByCustomerIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new CustomerWallet { Count = 0 });

            _mockWalletRepository
                .Setup(x => x.UpdateAsync(It.IsAny<CustomerWallet>()))
                .ThrowsAsync(new Exception("Something went wrong!"));

            // Act
            var result = await _paymentService.Transaction(_succeededNotification);

            // Assert
            Assert.AreEqual(ErrorUrl, result);
        }
    }
}