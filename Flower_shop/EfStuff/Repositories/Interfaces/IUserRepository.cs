namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User GetByEmAndPass(string email, string pass);
        public bool IsEmailExist(string email);
        public bool IsPasswordExist(string password);
    }
}
