using Newtonsoft.Json;

namespace FoodFlow.Modules.Culinary.Shared.Requests.TechCard;

public class CreateTechCardRequest
{
    [JsonProperty("restaurantId")]
    public string SpotId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("ingredients")]
    public List<CreateIngredientRequest> Ingredients { get; set; }
}
