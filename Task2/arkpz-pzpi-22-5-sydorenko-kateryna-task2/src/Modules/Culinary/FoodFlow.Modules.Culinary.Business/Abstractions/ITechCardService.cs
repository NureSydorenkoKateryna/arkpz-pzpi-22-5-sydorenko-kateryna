using FoodFlow.Common.Result;
using FoodFlow.Modules.Culinary.Core.Entities;
using FoodFlow.Modules.Culinary.Shared.Dtos.TechCard;

namespace FoodFlow.Modules.Culinary.Business.Abstractions;

public interface ITechCardService
{
    Task<Result<long>> Create(CreateTechCardDto dto);
    Task<Result<List<TechCard>>> GetAllBy(long restaurantId);
}
