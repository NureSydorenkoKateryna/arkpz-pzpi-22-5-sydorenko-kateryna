using FoodFlow.Common;
using FoodFlow.Common.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Spots.Api.Features.Spot.Get;

public partial class SpotsController : BaseController
{
    [HttpGet("{spotId}")]
    [SwaggerOperation("Get spot")]
    [SwaggerResponse(StatusCodes.Status200OK, "Spot", typeof(SpotResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]

    public async Task<IActionResult> GetSpot([FromRoute]long spotId, CancellationToken ct)
    {
        var query = new GetSpotQuery { SpotId = spotId };
        var result = await Mediator.Send(query, ct);
        if (!result.IsSuccessful)
        {
            return InternalServerError(result);
        }

        return Ok(result.Value);
    }
}
