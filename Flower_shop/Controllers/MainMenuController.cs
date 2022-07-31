using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class MainMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
