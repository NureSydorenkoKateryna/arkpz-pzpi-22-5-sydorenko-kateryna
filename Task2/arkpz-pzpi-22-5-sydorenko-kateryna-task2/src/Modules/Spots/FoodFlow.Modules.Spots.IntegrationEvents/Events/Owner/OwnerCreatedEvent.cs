using FoodFlow.Common.IntegrationEvents;

namespace FoodFlow.Modules.Spots.IntegrationEvents.Events.Owner;

public record OwnerCreatedEvent(
    Guid Id, 
    long OwnerId, 
    string FirstName, 
    string LastName, 
    string Email, 
    string Password) : IntegrationEvent(Id);
