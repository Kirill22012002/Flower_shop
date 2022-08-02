using Microsoft.AspNetCore.Mvc;

namespace Flower_shop.Models
{
    public class ProductViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }

    }
}
