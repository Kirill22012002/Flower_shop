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
                _logger.LogInformation($"Notification (" +
                    $"{notificationVm.Object.Amount.Currency}," +
                    $"{notificationVm.Object.Amount.Value}," +
                    $"{notificationVm.Object.CapturedAt.ToString()}," +
                    $"{notificationVm.Object.CreatedAt.ToString()}," +
                    $"{notificationVm.Object.IncomeAmount.Currency}," +
                    $"{notificationVm.Object.IncomeAmount.Value}," +
                    $"{notificationVm.Object.Paid}," +
                    $"{notificationVm.Event}");
                _logger.LogInformation($"NOTIF NEW: {notificationVm}");

                var dbNotification = new Notification()
                {
                    AmountCurrency = notificationVm.Object.Amount.Currency,
                    AmountValue= notificationVm.Object.Amount.Value,
                    CapturedAt = notificationVm.Object.CapturedAt.ToString(),
                    CreatedAt = notificationVm.Object.CreatedAt.ToString(),
                    IncomeAmountCurrency = notificationVm.Object.IncomeAmount.Currency,
                    IncomeAmountValue = notificationVm.Object.IncomeAmount.Value,
                    Paid = notificationVm.Object.Paid,
                    PaymentEvent = notificationVm.Event,
                    PaymentStatus = notificationVm.Object.Status,
                    RecipientAccountId = notificationVm.Object.Recipient.AccountId,
                    RecipientGatewayId = notificationVm.Object.Recipient.GatewayId,
                    PaymentMethodType = notificationVm.Object.PaymentMethod.Type,
                    PaymentMethodId = notificationVm.Object.PaymentMethod.Id,
                    PaymentId = notificationVm.Object.Id,
                    PaymentMethodSaved = notificationVm.Object.PaymentMethod.Saved,
                    Test = notificationVm.Object.Test,
                    RefundedAmountValue = notificationVm.Object.RefundedAmount.Value,
                    RefundedAmountCurrency = notificationVm.Object.RefundedAmount.Currency
                };
                
                _dbContext.Notifications.Add(dbNotification);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }

            return RedirectToAction("Success", new {str = "success"});
        }

        public string Success(string message)
        {
            return message;
        }

        
            
    }
}