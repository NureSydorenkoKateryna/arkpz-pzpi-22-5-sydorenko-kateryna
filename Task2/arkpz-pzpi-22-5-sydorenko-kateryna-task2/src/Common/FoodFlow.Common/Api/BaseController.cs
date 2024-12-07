using AutoMapper;
using FoodFlow.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FoodFlow.Common;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private IMapper _mapper;

    private IMediator _mediator;

    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected IMapper Mapper =>
        _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

    protected IActionResult InternalServerError<T>(Result<T> result) => StatusCode(500, result.GetResultResponse());
}
