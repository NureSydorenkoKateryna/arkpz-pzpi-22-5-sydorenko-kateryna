using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Spots.Application.Domain.Entities;

public class Spot : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }

    public long? OwnerId { get; set; }
    public Owner? Owner { get; set; }
    public long? ParentSpotId { get; set; }
    public Spot? ParentSpot { get; set; } // in order to create virtaul warehouse for restaurant
    public ICollection<Spot> ChildrenSpots { get; set; } // all real warehouses for restaurant
}
