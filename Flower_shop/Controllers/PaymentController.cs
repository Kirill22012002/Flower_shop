using Microsoft.AspNetCore.HttpsPolicy;
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
        private readonly string AfterPaymentURL = "https://cvetu-lepel.by/Payment/AfterPayment";

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
                    Value = 100.00m,
                    Currency = "RUB"
                },
                Confirmation = new Confirmation
                {
                    Type = ConfirmationType.Redirect,
                    ReturnUrl = AfterPaymentURL
                }
            };

            Payment payment = _client.CreatePayment(newPayment);

            string url = payment.Confirmation.ConfirmationUrl;
            Response.Redirect(url);
        }


        [HttpPost]
        public IActionResult GetAnswerTEST([FromBody] Payment payment)
        {
            var myPayment = _mapper.Map<MyPayment>(payment);

            _dbContext.MyPayments.Add(myPayment);
            _dbContext.SaveChanges();


            switch (payment.Status)
            {
                case PaymentStatus.Succeeded:
                    return Redirect("~/Home/Index");

                case PaymentStatus.WaitingForCapture:
                    return Redirect("~/Home/Index");

                case PaymentStatus.Canceled:
                    return Redirect("~/Home/Index");
            }

            return StatusCode(200);
        }

        [HttpGet]
        public IActionResult AfterPayment()
        {
            return Redirect("~/Home/Index");
        }
    }
}