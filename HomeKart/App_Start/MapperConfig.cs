using AutoMapper;
using HomeKart.Models;
using HomeKartEntity;
using System;
using System.Web.ModelBinding;

namespace HomeKart.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<AccountModel, User>()
                 .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));
                config.CreateMap<ProductModel, Product>();
                config.CreateMap<ProductCategoryModel, ProductCategory>();
                config.CreateMap<OrderModel, Orders>()
               .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.Now));
            });
        }
    }
}