using Microsoft.AspNetCore.HttpsPolicy;
using Yandex.Checkout.V3;

namespace Flower_shop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private readonly Client _client = new Client("976779", "test_MBXuTxf0WcyIigi7Js-zI_xpdCj8zUg58QhK8LFg3vY");
        private readonly string AfterPaymentURL = "https://cvetu-lepel.by/Payment/AfterPayment";

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
            switch (payment.Status)
            {
                case PaymentStatus.Succeeded:
                    return RedirectToAction();

                case PaymentStatus.WaitingForCapture:
                    return RedirectToAction();

                case PaymentStatus.Canceled:
                    return RedirectToAction();
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