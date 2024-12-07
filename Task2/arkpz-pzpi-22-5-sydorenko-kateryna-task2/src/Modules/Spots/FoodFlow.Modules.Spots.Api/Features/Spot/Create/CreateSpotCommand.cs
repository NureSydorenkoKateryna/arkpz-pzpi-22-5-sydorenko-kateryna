using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Spots.Api.Features.Spot.CreateSpot;

public class CreateSpotCommand : IRequest<Result<long>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }

    public long? OwnerId { get; set; }
}
