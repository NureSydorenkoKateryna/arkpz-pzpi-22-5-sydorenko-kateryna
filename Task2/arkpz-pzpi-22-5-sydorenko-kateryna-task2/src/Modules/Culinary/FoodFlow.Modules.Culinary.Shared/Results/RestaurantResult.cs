using FoodFlow.Common.Result;

namespace FoodFlow.Modules.Culinary.Shared.Results;

public class RestaurantResult
{
    public static ResultData NotFound => new ResultData("RESTAURANT_NOT_FOUND", "Restaurant not found");
}
