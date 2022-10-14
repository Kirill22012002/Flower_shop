using Flower_shop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_shop.EfStuff.DbModels
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = "";
        public string Price { get; set; } = "";
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
    }
}
