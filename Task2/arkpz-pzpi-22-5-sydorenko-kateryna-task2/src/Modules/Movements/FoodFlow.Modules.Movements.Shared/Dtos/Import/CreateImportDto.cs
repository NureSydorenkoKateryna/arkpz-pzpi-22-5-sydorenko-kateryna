namespace FoodFlow.Modules.Movements.Shared.Dtos.Import;

public class CreateImportDto
{
    public string Name { get; set; }
    public string WarehouseId { get; set; }
    public List<CreateImportItemDto> Items { get; set; }
}
