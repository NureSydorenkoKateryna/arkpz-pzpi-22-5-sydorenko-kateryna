using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Users.Api.Features.User.Create;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<long>>
{
    public Task<Result<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
