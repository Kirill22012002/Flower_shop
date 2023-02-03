namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _dbContext;
        protected DbSet<T> _dbSet;

        protected BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task AddAsync(T model)
        {
            await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<bool> TryAddAsync(T model)
        {
            await _dbSet.AddAsync(model);
            int result = await _dbContext.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddAllAsync(List<T> models)
        {
            foreach (var model in models)
            {
                await AddAsync(model);
            }
        }

        public virtual async Task UpdateAsync(T model)
        {
            _dbSet.Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T model)
        {
            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(long id)
        {
            await DeleteAsync(await GetByIdAsync(id));
            await _dbContext.SaveChangesAsync();
        }

    }
}
