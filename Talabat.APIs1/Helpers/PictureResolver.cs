using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.APIs1.Dto;
using Talabat.Repository.Entites;

namespace Talabat.APIs1.Helpers
{

    public class PictureResolver : IValueResolver<Product, ProductToReturnDtos, string>
    {

        public IConfiguration Configuration { get; }

        public PictureResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public string Resolve(Product source, ProductToReturnDtos destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{Configuration["BaseApiUrl"]}{source.PictureUrl}";

            }
            return null;
        }
    }
}
