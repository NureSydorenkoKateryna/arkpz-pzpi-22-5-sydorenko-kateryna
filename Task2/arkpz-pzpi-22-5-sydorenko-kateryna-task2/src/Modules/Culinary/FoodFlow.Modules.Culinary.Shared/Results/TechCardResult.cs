using FoodFlow.Common.Result;

namespace FoodFlow.Modules.Culinary.Shared.Results;

public class TechCardResult
{
    public static ResultData FailToAdd => new ResultData("TECH_CARD_FAIL_TO_ADD", "Fail to add tech card");
    public static ResultData NotFound => new ResultData("TECH_CARD_NOT_FOUND", "Tech card not found");
}
