namespace FoodFlow.Modules.Culinary.Shared.Dtos.TechCard;

public class CreateTechCardDto
{
    public string SpotId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<CreateIngredientDto> Ingredients { get; set; }
}
