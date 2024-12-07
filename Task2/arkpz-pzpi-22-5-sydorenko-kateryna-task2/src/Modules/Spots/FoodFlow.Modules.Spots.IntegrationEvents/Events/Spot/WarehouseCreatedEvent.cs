using FoodFlow.Common.IntegrationEvents;

namespace FoodFlow.Modules.Spots.IntegrationEvents.Events.Spot;

public record WarehouseCreatedEvent(
    Guid Id,
    string SpotId,
    string Name
    ) 
    : IntegrationEvent(Id);
