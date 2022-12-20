namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(WebDbContext context) : base(context)
        {
        }
    }
}
