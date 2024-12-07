using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using FoodFlow.Modules.Spots.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using FoodFlow.Modules.Spots.IntegrationEvents;

namespace FoodFlow.Modules.Spots.Api;

public static class SpotsModuleRegistration
{
    public static IServiceCollection AddSpotsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(SpotsModuleRegistration).Assembly)); // todo: move to external layer
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(IntegrationEventsRegistration).Assembly));
        services.AddAutoMapper(typeof(SpotsModuleRegistration).Assembly);
        services.AddApplicationLayer(configuration);
        return services;
    }

    public static IApplicationBuilder UseSpotsModule(this IApplicationBuilder app)
    {
        return app;
    }
}
