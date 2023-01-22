using Yandex.Checkout.V3;

namespace Flower_shop
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductViewModel>().ReverseMap();
                config.CreateMap<ProductViewModel, ProductViewModel>();
                config.CreateMap<User, UserViewModel>().ReverseMap();
                config.CreateMap<RegisterViewModel, User>().ReverseMap();
                config.CreateMap<TypeProduct, TypeProductViewModel>().ReverseMap();
                config.CreateMap<Image, ImageViewModel>().ReverseMap();
                config.CreateMap<Color, ColorViewModel>().ReverseMap();
            });
        }
    }
}