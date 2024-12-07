using FoodFlow.Common.IntegrationEvents;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Spots.Application;
using FoodFlow.Modules.Spots.IntegrationEvents.Events.Owner;
using MediatR;

namespace FoodFlow.Modules.Spots.Api.Features.Owner.Create;

public class CreateOwnerHandler(SpotsDbContext spotsDbContext, IEventBus eventBus) : IRequestHandler<CreateOwnerCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = new Application.Domain.Entities.Owner
        {
            Name = $"{request.FirstName} {request.LastName}",
            Email = request.Email
        };

        await spotsDbContext.Owners.AddAsync(owner, cancellationToken);
        await spotsDbContext.SaveChangesAsync(cancellationToken);

        await eventBus.PublishAsync(
            new OwnerCreatedEvent(
                Guid.NewGuid(),
                owner.Id,
                request.FirstName,
                request.LastName,
                owner.Email,
                request.Password), 
            cancellationToken);

        return Result.Success(owner.Id);
    }
}
