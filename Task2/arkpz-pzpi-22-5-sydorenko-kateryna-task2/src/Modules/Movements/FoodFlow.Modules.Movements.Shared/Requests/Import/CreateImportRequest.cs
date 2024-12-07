namespace FoodFlow.Modules.Movements.Shared.Request.Import;

public class CreateImportRequest : CreatePlainImportRequest
{
    public List<CreateImportItemRequest> Items { get; set; }
}
