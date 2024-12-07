namespace FoodFlow.Modules.Culinary.Core.Entities;

public class RestaurantTechCard
{
    public long RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    public long TechCardId { get; set; }
    public TechCard TechCard { get; set; }
}
