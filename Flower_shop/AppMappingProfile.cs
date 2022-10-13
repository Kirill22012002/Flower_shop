using AutoMapper;
using Flower_shop.EfStuff.DbModels;
using Flower_shop.Models;
using Flower_shop.Models.UserViewModels;

namespace Flower_shop
{
    public class AppMappingProfile : Profile 
    {
        public AppMappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductViewModel, ProductViewModel>();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, User>().ReverseMap();
            CreateMap<TypeProduct, TypeProductViewModel>().ReverseMap();
        }
    }
}
