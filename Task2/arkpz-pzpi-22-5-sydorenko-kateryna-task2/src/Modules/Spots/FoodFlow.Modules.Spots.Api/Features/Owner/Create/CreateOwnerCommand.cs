using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Spots.Api.Features.Owner.Create;

public class CreateOwnerCommand : IRequest<Result<long>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
