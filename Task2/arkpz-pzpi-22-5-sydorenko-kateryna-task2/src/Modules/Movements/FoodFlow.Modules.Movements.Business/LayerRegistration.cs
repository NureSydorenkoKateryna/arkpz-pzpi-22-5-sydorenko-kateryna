using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Modules.Movements.Business;

public static class LayerRegistration
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
    {
        return services;
    }
}
