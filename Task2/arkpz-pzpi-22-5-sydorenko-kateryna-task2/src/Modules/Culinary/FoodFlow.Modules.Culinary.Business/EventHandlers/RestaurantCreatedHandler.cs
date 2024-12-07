using FoodFlow.Modules.Culinary.Business.Abstractions;
using FoodFlow.Modules.Culinary.Core.Entities;
using FoodFlow.Modules.Spots.IntegrationEvents.Events.Spot;
using MediatR;

namespace FoodFlow.Modules.Culinary.Business.EventHandlers;

public class RestaurantCreatedHandler : INotificationHandler<RestaurantCreatedEvent>
{
    private readonly ICulinaryRepository<Restaurant> _repository;
    public RestaurantCreatedHandler(ICulinaryRepository<Restaurant> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RestaurantCreatedEvent notification, CancellationToken cancellationToken)
    {
        var restaurant = new Restaurant
        {
            Name = notification.Name,
            SpotId = notification.SpotId,
            OwnerId = notification.OwnerId
        };

        var savingResult = await _repository.AddAsync(restaurant);
        if (!savingResult.IsSuccessful)
        {
            //todo: logging
        }
    }
}
