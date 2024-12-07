using FoodFlow.Common;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Users.Application.Domain.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace FoodFlow.Modules.Users.Api.Features.User.Create;

public partial class UsersController : BaseController
{
    [Authorize(Roles = UserRole.Admin)]
    [HttpPost]
    [SwaggerOperation("Create user")]
    [SwaggerResponse(StatusCodes.Status200OK, "User created")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(ResultData))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ResultData))]

    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.IsSuccessful)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, result.GetResultResponse());
        }

        return Ok(result.Value);
    }
}
