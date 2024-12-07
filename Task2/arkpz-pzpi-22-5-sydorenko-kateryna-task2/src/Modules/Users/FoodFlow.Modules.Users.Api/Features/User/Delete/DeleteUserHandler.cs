using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Users.Api.Features.User.Delete;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<bool>>
{
    public Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
