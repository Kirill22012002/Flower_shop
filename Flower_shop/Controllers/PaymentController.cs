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
        private WebDbContext _dbContext;
        private INotificationRepository _notificationRepository;
        private IMapper _mapper;
        private readonly ILogger<PaymentController> _logger;
        private IPaymentService _paymentService;

        private readonly AsyncClient _asyncClient = new Client("976779", "test_MBXuTxf0WcyIigi7Js-zI_xpdCj8zUg58QhK8LFg3vY").MakeAsync();
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
                Metadata = new Dictionary<string, string> { { "customerId", $"{customerId}"} }
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

                if(returnUrl == "http://SuccessUrl")
                {
                    return StatusCode(200);
                }

            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }

            return StatusCode(500);
        }
    }
}