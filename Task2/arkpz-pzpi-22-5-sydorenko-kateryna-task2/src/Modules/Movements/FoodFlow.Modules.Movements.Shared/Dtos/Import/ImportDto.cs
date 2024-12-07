namespace FoodFlow.Modules.Movements.Shared.Dtos.Import;

public class ImportDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime TimePoint { get; set; }
    public string WarehouseId { get; set; }
    public List<ImportItemDto> Items { get; set; }
}

public class ImportItemDto
{
    public string ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
