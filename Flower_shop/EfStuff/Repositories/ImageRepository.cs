namespace Flower_shop.EfStuff.Repositories
{
    public class ImageRepository : BaseRepository<Image>
    {
        public ImageRepository(WebDbContext context) : base(context)
        {
        }
        public Image GetByBlock(int block)
        {
            return _dbSet.Where(x => x.Block == block).FirstOrDefault();
        }
        
    }
}
