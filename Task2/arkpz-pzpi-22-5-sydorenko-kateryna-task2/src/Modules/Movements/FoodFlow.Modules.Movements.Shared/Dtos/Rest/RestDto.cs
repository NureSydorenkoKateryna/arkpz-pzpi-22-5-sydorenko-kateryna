namespace FoodFlow.Modules.Movements.Shared.Dtos.Rest;

public class RestDto
{
    public long Id { get; set; }
    public string ProductId { get; set; }
    public decimal Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public long WarehouseId { get; set; }
}
