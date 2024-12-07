using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Users.Application.Domain.Entities;

public class User : BaseEntity, ITrackingEntity
{ 
    public string ExternalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // update role to model
    public bool Active { get; set; }
    public string SpotId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
