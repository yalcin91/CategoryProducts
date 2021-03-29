﻿
using AutoMapper;

using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.API.Mapping
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
        }
    }
}
