namespace Flower_shop.EfStuff.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel 
    {
        protected WebDbContext _webContext;
        protected DbSet<T> _dbSet;

        protected BaseRepository(WebDbContext webContext)
        {
            _webContext = webContext;
            _dbSet = _webContext.Set<T>();
        }

        public T Get(int id) => _dbSet.FirstOrDefault(x => x.Id == id);
        public List<T> GetAll() => _dbSet.ToList();
        public void Save(T model)
        {
            if(model.Id > 0)
            {
                _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }
            _webContext.SaveChanges();
        }
        public void Remove(T model)
        {
            _dbSet.Remove(model);
            _webContext.SaveChanges();
        }
        public void Remove(int id)
        {
            Remove(Get(id));
            _webContext.SaveChanges();
        }
        public void SaveList(List<T> models) => models.ForEach(Save);
        public int Count() => _dbSet.Count();
    }
}
