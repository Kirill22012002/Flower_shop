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
        private readonly string AfterPaymentURL = "https://cvetu-lepel.by/Payment/GetMessage";

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

        [HttpGet]
        public string GetMessage()
        {
            return "Paid";
        }

        [HttpPost]
        public void GetMessage(string code)
        {
            var myPayment = new MyPayment()
            {
                Id = "2Id",
                Code = code
            };

            _dbContext.MyPayments.Add(myPayment);
            _dbContext.SaveChanges();
        }


        public void Paid(string code)
        {
            var myPayment = new MyPayment()
            {
                Id = "2Id",
                Code = code
            };

            _dbContext.MyPayments.Add(myPayment);
            _dbContext.SaveChanges();
        }
    }
}