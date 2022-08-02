using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ChangeMainImage()
        {
            return View();
        }
    }
}
