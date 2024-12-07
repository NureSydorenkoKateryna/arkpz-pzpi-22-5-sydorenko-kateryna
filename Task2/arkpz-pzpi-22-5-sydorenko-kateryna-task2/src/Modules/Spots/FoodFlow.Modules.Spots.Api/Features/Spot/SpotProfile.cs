using AutoMapper;
using FoodFlow.Modules.Spots.Api.Features.OwnerSpot.CreateOwnerSpot;
using FoodFlow.Modules.Spots.Api.Features.Spot.CreateSpot;

namespace FoodFlow.Modules.Spots.Api.Features.Spot;

public class SpotProfile : Profile
{
    public SpotProfile()
    {
        CreateMap<CreateOwnerSpotRequest, CreateSpotCommand>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
            .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
            .ForMember(d => d.Type, o => o.MapFrom(s => s.Type));

        CreateMap<Application.Domain.Entities.Spot, SpotResponse>();
    }
}
