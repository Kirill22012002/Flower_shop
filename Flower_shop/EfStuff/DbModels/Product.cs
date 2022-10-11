using Flower_shop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_shop.EfStuff.DbModels
{
    public class Product
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Price { get; set; } = "";
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public int TypeProductId { get; set; } = 0;
    }
}
