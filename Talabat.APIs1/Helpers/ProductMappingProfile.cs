using AutoMapper;
using Talabat.APIs1.Dto;
using Talabat.Repository.Entites;

namespace Talabat.APIs1.Helpers
{
    public class ProductMappingProfile  : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductToReturnDtos>()
                .ForMember(d => d.ProductBrand, O => O.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, O => O.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<PictureResolver>());
            // Add more mappings as needed
        }
    }
}
