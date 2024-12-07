using AutoMapper;
using FoodFlow.Modules.Movements.Shared.Dtos.Import;
using FoodFlow.Modules.Movements.Shared.Request.Import;

namespace FoodFlow.Modules.Movements.Shared.Profiles;

public class ImportItemProfile : Profile
{
    public ImportItemProfile()
    {
        CreateMap<CreateImportItemRequest, CreateImportItemDto>();
    }
}
