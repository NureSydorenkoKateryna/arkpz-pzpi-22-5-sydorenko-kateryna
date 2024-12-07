namespace FoodFlow.Modules.Culinary.Shared.Dtos.TechCard;

public class TechCardDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
}
