using AutoMapper;
using FoodFlow.Modules.Culinary.Core.Entities;
using FoodFlow.Modules.Culinary.Shared.Dtos.TechCard;
using FoodFlow.Modules.Culinary.Shared.Requests.TechCard;

namespace FoodFlow.Modules.Culinary.Shared.Profiles;

public class TechCardProfile : Profile
{
    public TechCardProfile()
    {
        CreateMap<CreateTechCardRequest, CreateTechCardDto>();
        CreateMap<CreateTechCardDto, CreateTechCardRequest>();
        CreateMap<CreateTechCardDto, TechCard>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Description, o => o.MapFrom(s => s.Description));

        CreateMap<TechCard, TechCardDto>();
    }
}
