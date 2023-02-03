namespace Flower_shop.EfStuff.DbModels
{
    public class CustomerWallet : BaseModel
    {
        public string CustomerId { get; set; }
        public decimal Count { get; set; }
    }
}
