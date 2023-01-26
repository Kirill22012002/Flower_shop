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
        public ActionResult TestPaymentService([FromQuery]NotificationViewModel notificationVm)
        {
            string returnUrl = _paymentService.Transaction(notificationVm);

            Console.WriteLine(returnUrl);

            return Ok();
        }
    }
}
