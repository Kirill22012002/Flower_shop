namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        bool Any();
        T Get(int id);
        List<T> GetAll();
        void Save(T model);
        Task<bool> SaveAsync(T model);
        void SaveList(List<T> models);
        void Remove(int id);
        void Remove(T model);
        int Count();
        void Update(T model);

    }
}
