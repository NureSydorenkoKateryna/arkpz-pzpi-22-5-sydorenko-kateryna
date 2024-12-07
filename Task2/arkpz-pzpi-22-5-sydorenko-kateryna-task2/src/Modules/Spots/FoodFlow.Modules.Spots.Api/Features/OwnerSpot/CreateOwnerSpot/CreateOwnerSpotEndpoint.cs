using FoodFlow.Common.Result;
using FoodFlow.Modules.Spots.Api.Features.Owner.Create;
using FoodFlow.Modules.Spots.Api.Features.Spot.CreateSpot;
using FoodFlow.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;

namespace FoodFlow.Modules.Spots.Api.Features.OwnerSpot.CreateOwnerSpot;

public partial class OwnerSpotController : BaseController
{
    [HttpPost]
    [SwaggerOperation("Create owner spot")]
    [SwaggerResponse(StatusCodes.Status200OK, "Owner spot created. Spot id returned", typeof(long))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> CreateOwnerSpot([FromBody] CreateOwnerSpotRequest request, CancellationToken ct)
    {
        var ownerCommand = Mapper.Map<CreateOwnerCommand>(request);
        var ownerResult = await Mediator.Send(ownerCommand, ct);
        if (!ownerResult.IsSuccessful)
        {
            return BadRequest(ownerResult.GetResultResponse());
        }

        var spotCommand = Mapper.Map<CreateSpotCommand>(request);
        spotCommand.OwnerId = ownerResult.Value;
        var spotResult = await Mediator.Send(spotCommand, ct);
        if (!spotResult.IsSuccessful)
        {
            return BadRequest(spotResult.GetResultResponse());
        }

        return Ok(spotResult.Value);
    }
}