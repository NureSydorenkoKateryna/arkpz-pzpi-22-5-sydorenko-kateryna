using FoodFlow.Modules.Users.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Modules.Users.Api;

public static class UsersModuleRegistration
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(UsersModuleRegistration).Assembly));
        services.AddApplicationLayer(configuration);
        return services;
    }

    public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app)
    {
        return app;
    }
}
