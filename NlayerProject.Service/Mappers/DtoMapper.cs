using AutoMapper;
using NLayerProject.Core.Dtos;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerProject.Service.Mappers
{
    public class DtoMapper : Profile
    {

        //controlların constructorında geçeceğimiz için dependcy injectionı indermemiz gerekir
        public DtoMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();


            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
        }
    }
}
