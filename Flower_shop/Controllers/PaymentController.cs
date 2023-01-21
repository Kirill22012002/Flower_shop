using Flower_shop.EfStuff.DbModels;
using Microsoft.AspNetCore.HttpsPolicy;
using Newtonsoft.Json;
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
        public void Paid(string notification_type, string operation_id, string label, string datetime,
        decimal amount, decimal withdraw_amount, string sender, string sha1_hash, string currency, bool codepro)
        {
            
            var myAsnwer = new Answer()
            {
                notification_type= notification_type,
                operation_id= operation_id, 
                label= label,
                datetime=datetime,
                amount= amount,
                withdraw_amount= withdraw_amount,
                sender= sender,
                sha1_hash= sha1_hash,
                currency=currency,
                codepro=codepro
            };

            _dbContext.Answers.Add(myAsnwer);
            _dbContext.SaveChanges();
        }
    }
}