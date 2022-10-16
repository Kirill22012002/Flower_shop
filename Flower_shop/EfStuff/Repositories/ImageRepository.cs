using Flower_shop.EfStuff.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
