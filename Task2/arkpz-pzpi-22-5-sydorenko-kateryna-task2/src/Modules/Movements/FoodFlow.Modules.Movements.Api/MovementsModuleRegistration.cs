using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodFlow.Modules.Movements.Business;
using FoodFlow.Modules.Movements.Persistence;

namespace FoodFlow.Modules.Movements.Api;

// todo: create IModileRegistration interface
public static class MovementsModuleRegistration 
{
    public static IServiceCollection AddMovementsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceLayer(configuration);
        services.AddBusinessLayer();

        return services;
    }

    public static IApplicationBuilder UseMovementsModule(this IApplicationBuilder app)
    {
        return app;
    }
}
