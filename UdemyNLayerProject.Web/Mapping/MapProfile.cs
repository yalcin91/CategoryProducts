
using AutoMapper;

using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProducts>();
            CreateMap<CategoryWithProducts, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategory>();
            CreateMap<ProductWithCategory, Product>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}
