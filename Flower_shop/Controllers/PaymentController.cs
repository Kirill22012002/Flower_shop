using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Flower_shop.Models.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;
using Yandex.Checkout.V3;
using static System.Net.WebRequestMethods;

namespace Flower_shop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private IPaymentService _paymentService;

        private readonly AsyncClient _asyncClient;
        private readonly string AfterPaymentURL = "https://town-send.ru/Payment/Paid";

        public PaymentController(
            ILogger<PaymentController> logger,
            IPaymentService paymentService,
            IConfiguration configuration)
        {
            _logger = logger;
            _paymentService = paymentService;
            var clientId = configuration.GetValue<string>("YandexCheckout:ShopId");
            var secretKey = configuration.GetValue<string>("YandexCheckout:SecretKey");
            _asyncClient = new Client(clientId, secretKey).MakeAsync();
        }

        [HttpGet]
        public async Task<IActionResult> CreatePayment(decimal count, string customerId)
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
                Metadata = new Dictionary<string, string> { { "customerId", $"{customerId}" } }
            };

            Payment payment = await _asyncClient.CreatePaymentAsync(newPayment);
            string url = payment.Confirmation.ConfirmationUrl;

            return Redirect(url);
        }

        [HttpPost]
        public async Task<IActionResult> GetNotification(NotificationViewModel notificationVm)
        {
            try
            {
                string returnUrl = await _paymentService.Transaction(notificationVm);

                if (returnUrl == "http://SuccessUrl")
                {
                    return StatusCode(200);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }

            return StatusCode(500);
        }
    }
}