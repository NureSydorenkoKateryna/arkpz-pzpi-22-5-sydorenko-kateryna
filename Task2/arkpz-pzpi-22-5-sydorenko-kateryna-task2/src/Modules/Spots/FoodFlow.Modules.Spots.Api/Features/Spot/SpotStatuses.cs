using FoodFlow.Common.Result;

namespace FoodFlow.Modules.Spots.Api.Features.Spot;

public class SpotStatuses
{
    public static ResultData NotFount => new ResultData("SPOT_NOT_FOUND", "Spot not found");
}
