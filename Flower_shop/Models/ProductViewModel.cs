namespace Flower_shop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Price { get; set; } = "";
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string TypeName { get; set; } = "Цветы";
        public bool IsInTrash { get; set; } 
        public IFormFile UploadedFile { get; set; }
        public List<string> TypesName { get; set; }


    }
}