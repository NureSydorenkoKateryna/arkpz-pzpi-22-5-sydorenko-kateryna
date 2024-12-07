using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Movements.Core.Entities;

public class Import : BaseEntity
{
    public string Name { get; set; }
    public DateTime TimePoint { get; set; }
    public long WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }

    public ICollection<ImportItem> Items { get; set; }
}
