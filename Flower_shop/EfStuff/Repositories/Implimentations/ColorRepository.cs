namespace Flower_shop.EfStuff.Repositories.Implimentations
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(WebDbContext context) : base(context)
        {
        }
        public Color GetByAssignment(string name)
        {
            return _dbSet.SingleOrDefault(x => x.AssignmentName == name);
        }
    }
}
