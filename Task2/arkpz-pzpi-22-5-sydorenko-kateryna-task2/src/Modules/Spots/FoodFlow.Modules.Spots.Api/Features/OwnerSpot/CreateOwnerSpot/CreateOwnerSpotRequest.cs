using FoodFlow.Common.Result;
using MediatR;

namespace FoodFlow.Modules.Spots.Api.Features.OwnerSpot.CreateOwnerSpot;

public class CreateOwnerSpotRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }

    public string OwnerFirstName { get; set; }
    public string OwnerLastName { get; set; }
    public string OwnerEmail { get; set; }
    public string OwnerPassword { get; set; }
}
