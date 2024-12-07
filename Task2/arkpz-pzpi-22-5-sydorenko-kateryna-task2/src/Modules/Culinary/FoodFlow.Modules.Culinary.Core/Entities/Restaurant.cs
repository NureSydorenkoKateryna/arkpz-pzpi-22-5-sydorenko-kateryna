using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Culinary.Core.Entities;

// todo: create handler for this entity
public class Restaurant : BaseEntity
{
    public string SpotId { get; set; } // externalId from another module
    public string Name { get; set; }
    public string OwnerId { get; set; } // externalId from another module

    public ICollection<RestaurantTechCard> RestaurantTechCards { get; set; }
    public ICollection<Product> Products { get; set; }
}
