using Newtonsoft.Json;

namespace FoodFlow.Modules.Culinary.Shared.Requests.TechCard;

public class CreateIngredientRequest
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("quantity")]
    public decimal Quantity { get; set; }

    [JsonProperty("unit")]
    public string Unit { get; set; }
}
