using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Users.Api.Features.User.Delete;

public class DeleteUserCommand : IRequest<Result<bool>>
{
    public long UserId { get; set; }
}
