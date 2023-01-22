using Flower_shop.EfStuff.DbModels;
using Flower_shop.Models.Notification;
using Microsoft.AspNetCore.HttpsPolicy;
using Newtonsoft.Json;
using System.Net;
using Yandex.Checkout.V3;
using static System.Net.WebRequestMethods;

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

        public PaymentController(
            WebDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpPost]
        public void CreatePayment()
        {
            var newPayment = new NewPayment
            {
                Amount = new Amount
                {
                    Value = 100000.00m,
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
        public void Paid(NotificationViewModel json)
        {
            var dbNotification = new Notification()
            {
                NotificationStr = json.Object.Status.ToString()
            };

            _dbContext.Notifications.Add(dbNotification);
            _dbContext.SaveChanges();
        }
    }
}