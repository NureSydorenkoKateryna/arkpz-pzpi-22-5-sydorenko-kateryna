namespace FoodFlow.Modules.Movements.Shared.Requests.WriteOff;

public class CreateWriteOffRequest
{
    public long WarehouseId { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
}
