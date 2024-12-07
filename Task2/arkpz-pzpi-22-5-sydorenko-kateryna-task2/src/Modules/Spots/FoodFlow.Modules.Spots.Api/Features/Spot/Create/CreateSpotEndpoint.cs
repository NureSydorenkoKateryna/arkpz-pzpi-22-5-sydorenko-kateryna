using FoodFlow.Common.Result;
using FoodFlow.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using FoodFlow.Modules.Spots.Api.Features.Spot.CreateSpot;

namespace FoodFlow.Modules.Spots.Api.Features.Spot.Create;


public partial class SpotsController : BaseController
{
    [HttpPost]
    [SwaggerOperation("Create spot")]
    [SwaggerResponse(StatusCodes.Status200OK, "Spot created")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> Create([FromBody]CreateSpotCommand request)
    {
        var result = await Mediator.Send(request);
        if (!result.IsSuccessful)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, result.GetResultResponse());
        }

        return CreatedAtAction("GetSpot", new { spotId = result.Value }, result.Value);
    }
}