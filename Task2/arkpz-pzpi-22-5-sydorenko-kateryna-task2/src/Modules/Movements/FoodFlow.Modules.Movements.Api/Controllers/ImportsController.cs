using FoodFlow.Common;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Movements.Shared.Dtos.Import;
using FoodFlow.Modules.Movements.Shared.Request.Import;
using FoodFlow.Modules.Movements.Shared.Responses.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Movements.Api.Controllers;

public class ImportsController : BaseController
{
    [HttpPost("plain")]
    [SwaggerOperation("Create plain import")]
    [SwaggerResponse(StatusCodes.Status200OK, "Plain import created", typeof(long))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> Create([FromBody]CreatePlainImportRequest importRequest, CancellationToken ct)
    {
        var dto = Mapper.Map<CreatePlainImportRequest, CreateImportDto>(importRequest);

        //return Ok(nameof(GetById))
        return Ok();
    }

    [HttpPost("item/{importId}")]
    [SwaggerOperation("Add item to import")]
    [SwaggerResponse(StatusCodes.Status200OK, "Item added to import")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> AddItem([FromRoute]long importId, [FromBody]CreateImportItemRequest importItemRequest, CancellationToken ct)
    {
        var dto = Mapper.Map<CreateImportItemRequest, CreateImportItemDto>(importItemRequest);

        //return Ok(nameof(GetById))
        return Ok();
    }

    // create import with items
    [HttpPost]
    [SwaggerOperation("Create import")]
    [SwaggerResponse(StatusCodes.Status200OK, "Import created", typeof(long))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> Create([FromBody]CreateImportRequest importRequest, CancellationToken ct)
    {
        var dto = Mapper.Map<CreateImportRequest, CreateImportDto>(importRequest);

        //return Ok(nameof(GetById))
        return Ok();
    }

    // get all imports
    [HttpGet]
    [SwaggerOperation("Get all imports")]
    [SwaggerResponse(StatusCodes.Status200OK, "All imports", typeof(ImportsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        //return Ok(nameof(GetById))
        return Ok();
    }
}
