using Flower_shop.EfStuff.DbModels;
using Microsoft.AspNetCore.HttpsPolicy;
using Newtonsoft.Json;
using System.Net;
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

        /*[HttpPost]
        public void Paid(string code)
        {
            
            var myAsnwer = new Answer()
            {
                notification_type= code
            };

            _dbContext.Answers.Add(myAsnwer);
            _dbContext.SaveChanges();
        }
        public static async Task<string> GetPaymentDataFromYKassa(string url, string apiKey)
        {
            using (var client = new HttpClient())
            {
                // Set the headers
                client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
                // Get the response
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                // Return the response
                return content;
            }
        }*/
        public string GetDataByHttpJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string data = reader.ReadToEnd();

            var myAsnwer = new Answer()
            {
                notification_type = data
            };

            _dbContext.Answers.Add(myAsnwer);
            _dbContext.SaveChanges();

            return data;


        }
    }
}