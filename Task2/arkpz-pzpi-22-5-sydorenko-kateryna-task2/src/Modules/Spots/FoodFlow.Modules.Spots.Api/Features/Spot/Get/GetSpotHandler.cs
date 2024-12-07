using AutoMapper;
using FoodFlow.Common.IntegrationEvents;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Spots.Application;
using FoodFlow.Modules.Spots.Application.Domain.Helpers;
using FoodFlow.Modules.Spots.IntegrationEvents.Events.Spot;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodFlow.Modules.Spots.Api.Features.Spot.Get;

public class GetSpotHandler(SpotsDbContext spotsDbContext, IEventBus eventBus, IMapper mapper) : IRequestHandler<GetSpotQuery, Result<SpotResponse>>
{
    public async Task<Result<SpotResponse>> Handle(GetSpotQuery request, CancellationToken cancellationToken)
    {
        // todo: add validation

        var spot = await spotsDbContext.Spots.FirstOrDefaultAsync(s => s.Id == request.SpotId);
        if (spot is null)
        {
            return SpotStatuses.NotFount.GetFailureResult<SpotResponse>();
        }

        if (spot.Type.ToLower().Equals(SpotTypes.Restaurant.ToLower()))
        {
            await eventBus.PublishAsync(new RestaurantCreatedEvent(
                Guid.NewGuid(),
                spot.Id.ToString(),
                spot.OwnerId?.ToString(),
                spot.Address
                ), cancellationToken);
        }

        var spotResponse = mapper.Map<SpotResponse>(spot);
        return Result.Success(spotResponse);
    }
}
