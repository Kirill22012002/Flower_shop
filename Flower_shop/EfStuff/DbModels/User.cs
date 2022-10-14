using Flower_shop.EfStuff.DbModels.Enums;

namespace Flower_shop.EfStuff.DbModels
{
    public class User : BaseModel
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; }
        public string Password { get; set; }
        public SiteRole Role { get; set; }

    }
}
