namespace Flower_shop.EfStuff.Repositories.Interfaces
{
    public interface IColorRepository : IBaseRepository<Color>
    {
        public Color GetByAssignment(string name);
    }
}
