using Flower_shop.Models.Enums;
using Flower_shop.Models.Notification;
using Yandex.Checkout.V3;

namespace Flower_shop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;
        private readonly Client _client = new Client("976779", "test_MBXuTxf0WcyIigi7Js-zI_xpdCj8zUg58QhK8LFg3vY");
        private readonly string AfterPaymentURL = "https://cvetu-lepel.by/Payment/Paid";
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(
            WebDbContext dbContext,
            IMapper mapper,
            ILogger<PaymentController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public void CreatePayment()
        {
            var newPayment = new NewPayment
            {
                Amount = new Amount
                {
                    Value = 10.00m,
                    Currency = "RUB"
                },
                Confirmation = new Confirmation
                {
                    Type = ConfirmationType.Redirect,
                    ReturnUrl = AfterPaymentURL
                },
                Capture = true
            };

            Payment payment = _client.CreatePayment(newPayment);

            string url = payment.Confirmation.ConfirmationUrl;
            Response.Redirect(url);
        }
        [HttpGet]
        public IActionResult Paid()
        {
            return Redirect("https://cvetu-lepel.by/Index/AfterPayment");
        }

        [HttpPost]
        public IActionResult Paid(NotificationViewModel notificationVm)
        {
            try
            {
                _logger.LogInformation($"NOTIFICATION: {notificationVm}");

                var dbNotification = _mapper.Map<Notification>(notificationVm);
                
                _dbContext.Notifications.Add(dbNotification);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }

            return Ok();
        }

    }
}