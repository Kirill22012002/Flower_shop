namespace Flower_shop.EfStuff.DbModels.Enums
{
    [Flags]
    public enum SiteRole
    {
        Admin = 1,
        User = 2,
        Developer = 4
    }
}
