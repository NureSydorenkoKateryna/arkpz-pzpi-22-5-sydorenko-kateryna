using FoodFlow.Common;
using FoodFlow.Common.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Spots.Api.Features.Owner.Get;

public partial class OwnersController : BaseController
{
    [HttpGet("{ownerId}")]
    [SwaggerOperation("Get owner")]
    [SwaggerResponse(StatusCodes.Status200OK, "Owner", typeof(OwnerResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]    
    public async Task<IActionResult> GetOwner([FromRoute]long ownerId, CancellationToken ct)
    {
        return Ok();
    }
}
