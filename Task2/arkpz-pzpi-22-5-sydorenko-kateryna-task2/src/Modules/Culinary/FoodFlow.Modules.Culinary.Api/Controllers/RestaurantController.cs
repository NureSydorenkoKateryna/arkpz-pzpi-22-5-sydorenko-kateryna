using FoodFlow.Common;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Culinary.Business.Abstractions;
using FoodFlow.Modules.Culinary.Business.Services;
using FoodFlow.Modules.Culinary.Shared.Responses.TechCard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Culinary.Api.Controllers;

public class RestaurantController(ITechCardService techCardService) : BaseController 
{
    [HttpGet("{restaurantId}/techcards")]
    [SwaggerOperation("Get tech cards for restaurant")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tech cards for restaurant", typeof(TechCardsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> GetTechCards([FromRoute] long restaurantId, CancellationToken ct)
    {
        var techCardsResult = await techCardService.GetAllBy(restaurantId);
        if (!techCardsResult.IsSuccessful)
        {
            return InternalServerError(techCardsResult);
        }

        return Ok(techCardsResult.Value);
    }
}
