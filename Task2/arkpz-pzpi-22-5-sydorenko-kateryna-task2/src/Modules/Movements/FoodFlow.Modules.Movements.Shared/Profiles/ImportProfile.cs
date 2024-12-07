using AutoMapper;
using FoodFlow.Modules.Movements.Shared.Dtos.Import;
using FoodFlow.Modules.Movements.Shared.Request.Import;

namespace FoodFlow.Modules.Movements.Shared.Profiles;

public class ImportProfile : Profile
{
    public ImportProfile()
    {
        CreateMap<CreatePlainImportRequest, CreateImportDto>();
    }
}
