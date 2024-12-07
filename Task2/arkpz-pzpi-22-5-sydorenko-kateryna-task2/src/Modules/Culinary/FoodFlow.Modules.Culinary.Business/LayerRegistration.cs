using FoodFlow.Modules.Culinary.Business.Abstractions;
using FoodFlow.Modules.Culinary.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Modules.Culinary.Business;

public static class LayerRegistration
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITechCardService, TechCardService>();
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(LayerRegistration).Assembly));

        return services;
    }
}
