namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(WebDbContext context) : base(context)
        {
        }
        public async Task<Image> GetByBlockAsync(int block)
        {
            return await _dbSet.Where(x => x.Block == block).SingleOrDefaultAsync();
        }

    }
}
