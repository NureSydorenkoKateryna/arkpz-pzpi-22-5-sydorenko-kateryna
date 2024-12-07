using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Spots.Api.Features.Spot.Get;

public class GetSpotQuery : IRequest<Result<SpotResponse>>
{
    public long? SpotId { get; set; }
}
