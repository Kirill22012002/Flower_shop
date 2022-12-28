namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WebDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmAndPassAsync(string email, string pass)
        {
            var user = await _webContext.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == pass);
            return user;
        }
        public bool IsEmailExist(string email)
        {
            return _dbSet.Any(x => x.Email == email);
        }
        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _dbSet.AnyAsync(x => x.Email == email);
        }
        public bool IsPasswordExist(string password)
        {
            return _dbSet.Any(x => x.Password == password);
        }
        public async Task<bool> IsPasswordExistAsync(string password)
        {
            return await _dbSet.AnyAsync(x => x.Password == password);
        }
    }
}