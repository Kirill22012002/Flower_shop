namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Image GetByBlock(int block);
    }
}