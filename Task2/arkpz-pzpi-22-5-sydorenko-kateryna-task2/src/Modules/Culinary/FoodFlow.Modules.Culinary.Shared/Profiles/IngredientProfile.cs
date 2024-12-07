using AutoMapper;
using FoodFlow.Modules.Culinary.Shared.Dtos.TechCard;
using FoodFlow.Modules.Culinary.Shared.Requests.TechCard;

namespace FoodFlow.Modules.Culinary.Shared.Profiles;

public class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<CreateIngredientRequest, CreateIngredientDto>();
    }
}
