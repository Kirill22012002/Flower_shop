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
                config.CreateMap<GoogleUserViewModel, User>()
                            .ForMember(x => x.Id, opt => opt.MapFrom(s => long.Parse(s.Id)))
                            .ForMember(x => x.FirstName, opt => opt.MapFrom(s => s.Name.Substring(0, s.Name.IndexOf(" "))))
                            .ForMember(x => x.LastName, opt => opt.MapFrom(s => s.Family_name))
                            .ForMember(x => x.Email, opt => opt.MapFrom(s => s.Email))
                            .ReverseMap();
            });
        }
    }
}