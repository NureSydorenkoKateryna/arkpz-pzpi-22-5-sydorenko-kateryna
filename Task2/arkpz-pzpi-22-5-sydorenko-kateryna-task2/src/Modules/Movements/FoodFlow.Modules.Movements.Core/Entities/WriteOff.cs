namespace FoodFlow.Modules.Movements.Core.Entities;

public class WriteOff : Movement
{
    public long WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
}
