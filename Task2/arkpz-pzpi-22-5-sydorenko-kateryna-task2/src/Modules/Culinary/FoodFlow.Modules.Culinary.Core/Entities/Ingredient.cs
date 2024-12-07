using FoodFlow.Common.Domain;
using FoodFlow.Modules.Culinary.Core.ValueObjects;

namespace FoodFlow.Modules.Culinary.Core.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; }
    public MeasurementUnit Unit { get; set; }
    public decimal Amount { get; set; }

    public long TechCardId { get; set; }
    public TechCard TechCard { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}
