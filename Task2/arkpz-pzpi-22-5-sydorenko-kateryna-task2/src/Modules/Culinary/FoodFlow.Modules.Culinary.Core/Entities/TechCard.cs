using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Culinary.Core.Entities;

// todo: ent about of tech crad creation -> products for movevements
public class TechCard : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<RestaurantTechCard> RestaurantTechCards { get; set; }
}
