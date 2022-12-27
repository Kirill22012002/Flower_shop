namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected WebDbContext _webContext;
        protected DbSet<T> _dbSet;

        protected BaseRepository(WebDbContext webContext)
        {
            _webContext = webContext;
            _dbSet = _webContext.Set<T>();
        }

        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }
        public T GetById(long id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task SaveAsync(T model)
        {
            if (model.Id > 0)
            {
                _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }
            await _webContext.SaveChangesAsync();
        }

        public async Task SaveListAsync(IEnumerable<T> models)
        {
            models.ToList().AddRange(models);
            await _webContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(T model)
        {
            _dbSet.Remove(model);
            await _webContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(long id)
        {
            _dbSet.Remove(await GetByIdAsync(id));
            await _webContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}
