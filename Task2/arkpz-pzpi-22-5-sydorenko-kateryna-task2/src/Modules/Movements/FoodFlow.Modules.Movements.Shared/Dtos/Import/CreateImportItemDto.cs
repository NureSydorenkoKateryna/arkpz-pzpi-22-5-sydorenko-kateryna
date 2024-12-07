namespace FoodFlow.Modules.Movements.Shared.Dtos.Import;

public class CreateImportItemDto
{
    public string ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
