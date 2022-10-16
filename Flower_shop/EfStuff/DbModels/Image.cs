using Flower_shop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_shop.EfStuff.DbModels
{
    public class Image : BaseModel
    {
        public int Block { get; set; }
        public string Name { get; set; } = "";
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
