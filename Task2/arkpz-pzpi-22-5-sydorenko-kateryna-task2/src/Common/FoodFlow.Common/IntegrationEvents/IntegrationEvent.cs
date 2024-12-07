using MediatR;

namespace FoodFlow.Common.IntegrationEvents;

public interface IIntegrationEvent : INotification
{
    Guid Id { get; init; }
}

public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent;
