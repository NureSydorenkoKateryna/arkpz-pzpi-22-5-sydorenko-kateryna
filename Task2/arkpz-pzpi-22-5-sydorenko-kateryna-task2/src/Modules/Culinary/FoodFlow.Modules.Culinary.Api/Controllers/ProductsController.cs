using FoodFlow.Common;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Culinary.Shared.Responses.Product;
using FoodFlow.Modules.Culinary.Shared.Responses.TechCard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodFlow.Modules.Culinary.Api.Controllers;

public class ProductsController : BaseController
{
    [HttpGet("restaurant/{restaurantId}")]
    [SwaggerOperation("Get products for restaurant")]
    [SwaggerResponse(StatusCodes.Status200OK, "Products for restaurant", typeof(ProductsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> GetProducts([FromRoute]long restaurantId, CancellationToken ct)
    {
        //return Ok(nameof(GetById))
        return Ok();
    }

    [HttpGet("{productId}/techCards")]
    [SwaggerOperation("Get tech cards for product")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tech cards for product", typeof(TechCardsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]
    public async Task<IActionResult> GetTechCards([FromRoute]long productId, CancellationToken ct)
    {
        //return Ok(nameof(GetById))
        return Ok();
    }
}
