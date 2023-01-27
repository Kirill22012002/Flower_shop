namespace Flower_shop.EfStuff.DbModels
{
    public class Wallet : BaseModel
    {
        public string CustomerId { get; set; }
        public float Count { get; set; }
    }
}
