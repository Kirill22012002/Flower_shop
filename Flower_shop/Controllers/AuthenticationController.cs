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
        private IConfiguration _config;
        public AuthenticationController(
            WebDbContext dbContext,
            IMapper mapper,
            IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
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
                    new Claim(ClaimTypes.AuthenticationMethod, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value)
                };

                var identity = new ClaimsIdentity(claims, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                return RedirectToRoute("default", new { controller = "Index", action = "Index" });
            }

            return View();
        }
        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Autorization(LoginViewModel userView)
        {
            
            var user = _dbContext.Users.Single(x => x.Email == userView.Email && x.Password == userView.Password);

            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.FirstName),
                new Claim(ClaimTypes.AuthenticationMethod, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value)
            };

            var identity = new ClaimsIdentity(claims, _config.GetSection("ConnectionStrings").GetSection("AuthName").Value);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToRoute("default", new { controller = "Index", action = "Index" });
        }

    }
}
