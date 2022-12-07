namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public T Get(int id);
        public List<T> GetAll();
        public void Save(T model);
        public void SaveList(List<T> models);
        public void Remove(int id);
        public void Remove(T model);
        public int Count();
    }
}
