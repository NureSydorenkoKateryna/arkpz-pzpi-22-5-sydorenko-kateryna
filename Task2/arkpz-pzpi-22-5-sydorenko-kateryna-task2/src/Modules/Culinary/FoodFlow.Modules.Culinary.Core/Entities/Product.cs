using FoodFlow.Common.Domain;
using FoodFlow.Modules.Culinary.Core.ValueObjects;

namespace FoodFlow.Modules.Culinary.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }

    public long RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
}
