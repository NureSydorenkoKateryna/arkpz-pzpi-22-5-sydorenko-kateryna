using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Movements.Core.Entities;

public class Rest : BaseEntity, ITrackingEntity
{
    public string ParoductId { get; set; }
    public decimal Quantity { get; set; }

    public long WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
