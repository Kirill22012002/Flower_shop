using Flower_shop.Models.Notification;

namespace Flower_shop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private IPaymentService _paymentService;

        public TestController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult TestPaymentService()
        {
            var notificationVm = new NotificationViewModel()
            {
                Object = new PaymentObjectViewModel()
                {
                    Amount = new PaymentAmountViewModel()
                    {
                        Value = "1000.00"
                    },
                    Metadata = new Dictionary<string, string> 
                    { 
                        {
                            "customerId", "kirill334"
                        }
                    },
                    Id = "2b643ef8-000f-5000-a000-1df1b031420e",
                    Status = "succeeded"
                }
            };

            var returnUrl = _paymentService.Transaction(notificationVm);

            return Ok();
        }
    }
}
