using FoodFlow.Common.IntegrationEvents;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Spots.Application;
using FoodFlow.Modules.Spots.Application.Domain.Entities;
using FoodFlow.Modules.Spots.IntegrationEvents.Events.Spot;
using MediatR;

namespace FoodFlow.Modules.Spots.Api.Features.Spot.CreateSpot;

public class CreateSpotHandler(SpotsDbContext spotsDbContext, IEventBus eventBus)
    : IRequestHandler<CreateSpotCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateSpotCommand request, CancellationToken cancellationToken)
    {
        // todo: add validation for spot type
        var spot = new Application.Domain.Entities.Spot
        {
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            Type = request.Type,
            OwnerId = request.OwnerId
        };

        await spotsDbContext.Spots.AddAsync(spot, cancellationToken);
        await spotsDbContext.SaveChangesAsync(cancellationToken);

        await eventBus.PublishAsync(new RestaurantCreatedEvent(
            Guid.NewGuid(),
            spot.Id.ToString(),
            spot.OwnerId.ToString(),
            spot.Name), cancellationToken);

        return Result.Success(spot.Id);
    }
}
