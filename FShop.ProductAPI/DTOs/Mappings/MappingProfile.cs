using AutoMapper;
using FShop.ProductAPI.Models;

namespace FShop.ProductAPI.DTOs.Mappings
{
    public class MappingProfile : Profile   
    {
        public MappingProfile()
        {
           CreateMap<Category, CategoryDTO>().ReverseMap();
           CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
