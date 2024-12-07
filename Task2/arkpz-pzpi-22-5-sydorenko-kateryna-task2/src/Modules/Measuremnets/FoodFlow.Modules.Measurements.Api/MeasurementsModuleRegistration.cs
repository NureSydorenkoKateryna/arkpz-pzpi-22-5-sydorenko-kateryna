using FoodFlow.Modules.Measurements.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Modules.Measurements.Api;

public static class MeasurementsModuleRegistration
{
    public static IServiceCollection AddMeasurementsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(MeasurementsModuleRegistration).Assembly));
        services.AddAutoMapper(typeof(MeasurementsModuleRegistration).Assembly);

        services.AddApplicationLayer(configuration);

        return services;
    }

    public static IApplicationBuilder UseMeasurementsModule(this IApplicationBuilder app)
    {
        return app;
    }
}
