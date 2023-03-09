using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.ViewModels;

namespace Mango.Services.ProductAPI.Mappers;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<ProductViewModel, Product>();
            config.CreateMap<Product, ProductViewModel>();
        });
    }
}