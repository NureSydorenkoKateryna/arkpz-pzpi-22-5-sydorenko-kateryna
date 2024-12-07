using FoodFlow.Common;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Movements.Shared.Dtos.Rest;
using FoodFlow.Modules.Movements.Shared.Responses.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Movements.Api.Controllers;

public class RestsController : BaseController
{
    [HttpGet("warehouse/{warehouseId}")]
    [SwaggerOperation("Get warehouse rests")]
    [SwaggerResponse(StatusCodes.Status200OK, "Warehouse rests", typeof(RestsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> GetWarehouseRests([FromRoute]long warehouseId, CancellationToken ct)
    {
        //return Ok(nameof(GetById))
        return Ok();
    }

    // get rest for product by id
    [HttpGet("{productId}")]
    [SwaggerOperation("Get rest for product")]
    [SwaggerResponse(StatusCodes.Status200OK, "Rest for product", typeof(RestDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> GetRest([FromRoute]long productId, CancellationToken ct)
    {

        //return Ok(nameof(GetById))
        return Ok();
    }
}
