namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WebDbContext context) : base(context)
        {
        }

        public User GetByEmAndPass(string email, string pass)
        {
            var user = _webContext.Users.SingleOrDefault(x => x.Email == email && x.Password == pass);
            return user;
        }
        public bool IsEmailExist(string email) => _webContext.Users.Any(x => x.Email == email);
        public bool IsPasswordExist(string password) => _webContext.Users.Any(x => x.Password == password);

    }
}