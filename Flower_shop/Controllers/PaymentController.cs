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
        private readonly string AfterPaymentURL = "https://cvetu-lepel.by/Index/Paid";

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
        public void Paid([FromBody]Payment payment)
        {
            var myPayment = new MyPayment()
            {
                Id = "56Id",
                Code = payment.CreatedAt.ToString()
            };

            _dbContext.MyPayments.Add(myPayment);
            _dbContext.SaveChanges();
        }










        /*[HttpPost]
        public IActionResult Paid([FromBody]Payment payment)
        {

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
        }*/

    }
}