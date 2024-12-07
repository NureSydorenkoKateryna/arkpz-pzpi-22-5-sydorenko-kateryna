using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodFlow.Modules.Culinary.Infrastructure;
using FoodFlow.Modules.Culinary.Business;
using FoodFlow.Modules.Culinary.Persistence;
using FoodFlow.Modules.Culinary.Shared.Profiles;

namespace FoodFlow.Modules.Culinary.Api;

public static class CulinaryModuleRegistration
{
    public static IServiceCollection AddCulinaryModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(RegistrationProfile).Assembly);
        services.AddBusinessLayer(configuration);
        services.AddInfrastructureLayer(configuration);
        services.AddPersistenceLayer(configuration);

        return services;
    }

    public static IApplicationBuilder UseCulinaryModule(this IApplicationBuilder app)
    {
        return app;
    }
}
