using MediatR;

namespace FoodFlow.Modules.Measurements.Api.Features.Measurement.Create;

public class CreateMeasurementHandler : IRequestHandler<CreateMeasurementCommand>
{
    public Task Handle(CreateMeasurementCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
