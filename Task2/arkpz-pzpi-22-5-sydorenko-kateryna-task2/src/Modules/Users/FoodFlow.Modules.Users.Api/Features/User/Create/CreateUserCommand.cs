using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Users.Api.Features.User.Create;

public class CreateUserCommand : IRequest<Result<long>>
{
    public long SpotId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
