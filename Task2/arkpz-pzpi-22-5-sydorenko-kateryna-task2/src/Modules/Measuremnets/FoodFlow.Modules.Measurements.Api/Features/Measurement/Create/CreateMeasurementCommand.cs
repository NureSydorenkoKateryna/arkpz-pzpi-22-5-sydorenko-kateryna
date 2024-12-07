using MediatR;

namespace FoodFlow.Modules.Measurements.Api.Features.Measurement.Create;

public class CreateMeasurementCommand : IRequest
{
    public string Token { get; set; }
    public decimal Amount { get; set; }
}
