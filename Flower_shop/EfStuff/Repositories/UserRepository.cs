using Flower_shop.EfStuff.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flower_shop.EfStuff.Repositories
{
    public class UserRepository : BaseRepository<User> 
    {
        public UserRepository(WebDbContext context) : base(context)
        {
        }

        public User GetByEmAndPass(string email, string pass)
        {
            var user = _webContext.Users.SingleOrDefault(x => x.Email == email && x.Password == pass);
            return user;
        }
    }
}
