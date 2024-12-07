using FoodFlow.Common;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Culinary.Business.Abstractions;
using FoodFlow.Modules.Culinary.Shared.Dtos.TechCard;
using FoodFlow.Modules.Culinary.Shared.Requests.TechCard;
using FoodFlow.Modules.Culinary.Shared.Responses.TechCard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Culinary.Api.Controllers;

public class TechCardsController(ITechCardService techCardService) : BaseController
{
    [HttpPost]
    [SwaggerOperation("Create tech card")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tech card created", typeof(long))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> Create([FromBody]CreateTechCardRequest techCardRequest, CancellationToken ct)
    {
        var dto = Mapper.Map<CreateTechCardRequest, CreateTechCardDto>(techCardRequest);
        var techCardResult = await techCardService.Create(dto);
        if (!techCardResult.IsSuccessful)
        {
            return InternalServerError(techCardResult);
        }

        return CreatedAtAction(nameof(GetById), new { techCardId = techCardResult.Value }, techCardResult.Value);
    }


    [HttpDelete("{techCardId}")]
    [SwaggerOperation("Delete tech card")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Tech card deleted")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> Delete([FromRoute]long techCardId, CancellationToken ct)
    {
        return NoContent();
    }

    [HttpGet("{techCardId}")]
    [SwaggerOperation("Get tech card by id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tech card by id", typeof(TechCardDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> GetById([FromRoute]long techCardId, CancellationToken ct)
    {
        //return Ok(nameof(GetById))
        return Ok();
    }


    // update tech card


    // register tech cards by json
}
