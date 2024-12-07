using FoodFlow.Modules.Movements.Business.Abstractions;
using FoodFlow.Modules.Movements.Core.Entities;
using FoodFlow.Modules.Spots.IntegrationEvents.Events.Spot;
using MediatR;

namespace FoodFlow.Modules.Measurements.Business.EventHandlers;

public class WarehouseCreatedHandler(IMovementsRepository<Warehouse> warehouseRepository) : INotificationHandler<WarehouseCreatedEvent>
{
    public async Task Handle(WarehouseCreatedEvent notification, CancellationToken cancellationToken)
    {
        // todo: mapping add
        var newWarehouse = new Warehouse
        {
            Name = notification.Name,
            SpotId = notification.SpotId
        };
        

        var savingResult = await warehouseRepository.AddAsync(newWarehouse);
        if (savingResult == null)
        {
            throw new Exception("Warehouse could not be saved");
        }
    }
}
