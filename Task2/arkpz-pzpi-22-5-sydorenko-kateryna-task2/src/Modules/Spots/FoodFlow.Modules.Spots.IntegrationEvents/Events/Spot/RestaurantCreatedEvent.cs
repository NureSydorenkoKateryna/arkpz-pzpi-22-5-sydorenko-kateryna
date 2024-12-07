using FoodFlow.Common.IntegrationEvents;

namespace FoodFlow.Modules.Spots.IntegrationEvents.Events.Spot;

public record RestaurantCreatedEvent(
    Guid Id,
    string SpotId,
    string OwnerId,
    string Name) 
    : IntegrationEvent(Id);
