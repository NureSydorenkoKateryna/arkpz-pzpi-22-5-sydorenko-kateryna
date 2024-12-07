using AutoMapper;
using FoodFlow.Modules.Spots.Api.Features.Owner.Create;
using FoodFlow.Modules.Spots.Api.Features.OwnerSpot.CreateOwnerSpot;

namespace FoodFlow.Modules.Spots.Api.Features.Owner;

public class OwnerProfile : Profile
{
    public OwnerProfile()
    {
        CreateMap<CreateOwnerSpotRequest, CreateOwnerCommand>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.OwnerFirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.OwnerLastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.OwnerEmail))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.OwnerPassword));
    }
}
