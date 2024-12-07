using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Spots.Application.Domain.Entities;

public class Owner : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }

    public ICollection<Spot> Spots { get; set; }
}
