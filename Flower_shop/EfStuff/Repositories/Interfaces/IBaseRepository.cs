namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<bool> AnyAsync();

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task SaveAsync(T model);

        Task SaveListAsync(IEnumerable<T> models);

        Task RemoveAsync(T model);

        Task RemoveByIdAsync(int id);

        Task<int> CountAsync();
    }
}
