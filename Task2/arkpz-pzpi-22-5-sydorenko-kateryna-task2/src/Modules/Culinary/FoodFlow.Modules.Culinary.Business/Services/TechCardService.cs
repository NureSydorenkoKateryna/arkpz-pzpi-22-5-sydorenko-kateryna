using AutoMapper;
using FoodFlow.Common.Result;
using FoodFlow.Modules.Culinary.Business.Abstractions;
using FoodFlow.Modules.Culinary.Core.Entities;
using FoodFlow.Modules.Culinary.Shared.Dtos.TechCard;
using FoodFlow.Modules.Culinary.Shared.Results;

namespace FoodFlow.Modules.Culinary.Business.Services;

public class TechCardService(
    ICulinaryRepository<TechCard> culinaryRepository, 
    ICulinaryRepository<RestaurantTechCard> restaurantTeachCardRepository,
    ICulinaryRepository<Restaurant> restaurantRepository,
    IMapper mapper) : ITechCardService
{
    public async Task<Result<long>> Create(CreateTechCardDto dto)
    {
        // todo: create products first
        var techCard = new TechCard
        {
            Name = dto.Name,
            Description = dto.Description,
            Ingredients = dto.Ingredients.Select(x => new Ingredient
            {
                Name = x.Name,
                Amount = x.Quantity,
                Unit = new Core.ValueObjects.MeasurementUnit(x.Unit)
            }).ToList(),
        };
        var restaurantResult = await restaurantRepository.GetFirstOrDefaultAsync(x => x.SpotId == dto.SpotId);
        if (!restaurantResult.IsSuccessful)
        {
            return RestaurantResult.NotFound.GetFailureResult<long>();
        }

        var savingResult = await culinaryRepository.AddAsync(techCard);
        if (!savingResult.IsSuccessful)
        {
            return TechCardResult.FailToAdd.GetFailureResult<long>();
        }

        var restaurantTechCard = new RestaurantTechCard
        {
            RestaurantId = restaurantResult.Value.Id,
            TechCardId = techCard.Id
        };

        await restaurantTeachCardRepository.AddAsync(restaurantTechCard);

        return Result.Success(techCard.Id);
    }

    public async Task<Result<List<TechCard>>> GetAllBy(long restaurantId)
    {
        var restaurantResult = await restaurantRepository.GetFirstOrDefaultAsync(x => x.SpotId == restaurantId.ToString());
        if (!restaurantResult.IsSuccessful)
        {
            return RestaurantResult.NotFound.GetFailureResult<List<TechCard>>();
        }

        var restaurantTechCards = await restaurantTeachCardRepository.GetAllAsync(x => x.RestaurantId == restaurantResult.Value.Id);
        if (!restaurantTechCards.IsSuccessful)
        {
            return TechCardResult.NotFound.GetFailureResult<List<TechCard>>();
        }

        var techCards = restaurantTechCards.Value.Select(x => x.TechCard).ToList();

        return Result.Success(techCards.ToList());
    }
}
