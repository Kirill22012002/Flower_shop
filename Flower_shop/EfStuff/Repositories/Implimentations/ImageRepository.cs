﻿namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
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
