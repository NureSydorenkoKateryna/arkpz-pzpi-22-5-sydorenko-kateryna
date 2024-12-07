namespace FoodFlow.Modules.Movements.Shared.Request.Import;

public class CreateImportItemRequest
{
    public string ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
