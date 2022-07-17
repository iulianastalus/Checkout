using Checkout.API.Middlewares;
using Checkout.Domain.Settings;
using MediatR;
using Checkout.Application.Commands.CreateBasket;
using System.Reflection;
using Checkout.Application.MappersConfig;
using Microsoft.Extensions.Options;
using Basket.Infrastructure.Repositories;
using Basket.Domain.Interfaces;

namespace Checkout.API.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void RegisterCommonServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<ExceptionHandler>();
            services.AddSingleton<IBasketRepository, BasketRepository>();
            services.AddStackExchangeRedisCache(options => 
            {
                var redisConfig = configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>();
                options.Configuration = redisConfig.ConnectionString ;
            });
            services.AddMediatR(typeof(CreateBasketCommand).Assembly,Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappersConfig).Assembly);
        }
    }
}
