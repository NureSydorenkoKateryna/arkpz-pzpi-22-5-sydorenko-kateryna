using FoodFlow.Common;
using FoodFlow.Common.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Measurements.Api.Features.Measurement.Create;

public partial class MeasurementsController : BaseController
{
    [HttpPost]
    [SwaggerOperation("Register measurement")]
    [SwaggerResponse(StatusCodes.Status200OK, "Measurement registered")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> RegisterMeasurement([FromBody] CreateMeasurementCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
