using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Common.IntegrationEvents;

public static class IntegrationEventsUtilsRegistration
{
    public static void RegisterIntegrationEventsUtils(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryMessageQueue>();
        services.AddSingleton<IEventBus, EventBus>();
        services.AddHostedService<IntegrationEventProcessorJob>();
    }
}
