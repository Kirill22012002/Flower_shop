using Flower_shop.EfStuff.DbModels;
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
                    Value = 100.00m,
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
        public void Paid(Transaction transactionVm)
        {

            var myAsnwer = new Answer()
            {
                Json = transactionVm.Event.ToString()
            };

            _dbContext.Answers.Add(myAsnwer);
            _dbContext.SaveChanges();
        }
    }
}