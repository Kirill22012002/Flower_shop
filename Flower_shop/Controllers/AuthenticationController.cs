using AutoMapper;
using Flower_shop.EfStuff;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.EfStuff.DbModels.Enums;
using Flower_shop.Models.UserViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Flower_shop.Controllers
{
    public class AuthenticationController : Controller
    {
        private WebDbContext _dbContext;
        private IMapper _mapper;
        public AuthenticationController(
            WebDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel registerView)
        {
            if (ModelState.IsValid)
            {
                var userDb = _mapper.Map<User>(registerView);
                userDb.Role = SiteRole.User;

                _dbContext.Users.Add(userDb);
                _dbContext.SaveChanges();

                var claims = new List<Claim>()
                {
                    new Claim("Id", userDb.Id.ToString()),
                    new Claim("Name", userDb.FirstName),
                    new Claim(ClaimTypes.AuthenticationMethod, "SmileCoockie")
                };

                var identity = new ClaimsIdentity(claims, "SmileCoockie");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }

            return View();
        }
        public IActionResult Autorization()
        {
            return View();
        }

    }
}
