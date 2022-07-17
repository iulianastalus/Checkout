﻿using AutoMapper;
using Basket.Domain.Models;
using Checkout.Application.Commands.CreateBasket;

namespace Checkout.Application.MappersConfig
{
    public class MappersConfig : Profile
    {
        public MappersConfig()
        {
            CreateMap<CreateBasketCommand, ShoppingCart>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.PaysVAT, opt => opt.MapFrom(src => src.PaysVAT));

            CreateMap<ShoppingCart, CreateBasketResponse>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.PaysVAT, opt => opt.MapFrom(src => src.PaysVAT));
        }
    }
}