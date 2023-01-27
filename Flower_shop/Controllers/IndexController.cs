using Flower_shop.Models.Notification;
using Newtonsoft.Json;
using Serilog.Events;
using System.Text;

namespace Flower_shop.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
