using FoodFlow.Modules.Spots.IntegrationEvents.Events.Owner;
using FoodFlow.Modules.Users.Application;
using FoodFlow.Modules.Users.Application.Domain.Helpers;
using MediatR;

namespace FoodFlow.Modules.Users.Api.EventHandlers;

public class OwnerCreatedHandler : INotificationHandler<OwnerCreatedEvent>
{
    private readonly UsersDbContext _usersDbContext;
    public OwnerCreatedHandler(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }
    public async Task Handle(OwnerCreatedEvent notification, CancellationToken cancellationToken)
    {
        var user = new Application.Domain.Entities.User
        {
            FirstName = notification.FirstName,
            LastName = notification.LastName,
            Email = notification.Email,
            Role = UserRole.Owner,
            Active = true,
            Password = notification.Password, // add hashed password
            CreatedAt = DateTime.UtcNow // move to db context
        };

        await _usersDbContext.Users.AddAsync(user, cancellationToken);
        await _usersDbContext.SaveChangesAsync(cancellationToken);
    }
}
