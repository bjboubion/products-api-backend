using AutoMapper;
using products_api.Products.API.ViewModel;
using products_api.Products.Infrastructure.Context;

namespace products_api.Products.Domain.Models
{
    public class KitProfile : Profile
    {
        public KitProfile()
        {
            CreateMap<DbKit, KitViewModel>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.ImageSrc, opts => opts.MapFrom(src => src.ImageUrl));
            CreateMap<DbKit, KitAddRequest>();
            CreateMap<DbKit, KitUpdateRequest>();
        }
    }
}