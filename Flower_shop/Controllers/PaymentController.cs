using Flower_shop.Models.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Yandex.Checkout.V3;

namespace Flower_shop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private WebDbContext _dbContext;
        private INotificationRepository _notificationRepository;
        private IMapper _mapper;
        private readonly ILogger<PaymentController> _logger;
        private IPaymentService _paymentService;
        private readonly Client _client = new Client("976779", "test_MBXuTxf0WcyIigi7Js-zI_xpdCj8zUg58QhK8LFg3vY");
        private readonly string AfterPaymentURL = "https://town-send.ru/Payment/Paid";

        public PaymentController(
            WebDbContext dbContext,
            INotificationRepository notificationRepository,
            IMapper mapper,
            ILogger<PaymentController> logger,
            IPaymentService paymentService)
        {
            _dbContext = dbContext;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _logger = logger;
            _paymentService = paymentService;
        }

        /// <summary>
        /// Creates a new payment and redirects to payment(to YKassa)
        /// </summary>

        [HttpGet]
        public void CreatePayment(decimal count, string customerId)
        {
            var newPayment = new NewPayment
            {
                Amount = new Amount
                {
                    Value = count
                },
                Confirmation = new Confirmation
                {
                    Type = ConfirmationType.Redirect,
                    ReturnUrl = AfterPaymentURL
                },
                Capture = true, 
                Metadata = new Dictionary<string, string> { { "customerId", $"{customerId}"} }
            };

            Payment payment = _client.CreatePayment(newPayment);

            string url = payment.Confirmation.ConfirmationUrl;
            Response.Redirect(url);
        }

        [HttpGet]
        public IActionResult GetNotification()
        {
            return Redirect("https://town-send.ru/Index/AfterPayment");
        }

        /// <summary>
        /// Data comes here from Ykassa by HTTP and put it in db
        /// and check it with the help of the _paymentService
        /// </summary>
        [HttpPost]
        public IActionResult GetNotification(NotificationViewModel notificationVm)
        {
            try
            {
                _logger.LogInformation($"NOTIFICATION: {notificationVm.Object.Id}");

                var notificationDb = _mapper.Map<Notification>(notificationVm);

                _notificationRepository.Save(notificationDb);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }
            finally
            {
                var returnUrl = _paymentService.Transaction(notificationVm);
            }

            return StatusCode(200);
        }
    }
}