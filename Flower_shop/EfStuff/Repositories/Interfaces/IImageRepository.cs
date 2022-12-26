namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<Image> GetByBlockAsync(int block);
    }
}