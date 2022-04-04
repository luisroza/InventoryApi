using InventoryApi.Business.Interfaces;
using InventoryApi.Business.Notifications;
using InventoryApi.Business.Services;
using InventoryApi.Data.Context;
using InventoryApi.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApi.WebApp.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<InventoryContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}