using FoodFlow.Common.Persistence;

namespace FoodFlow.Modules.Movements.Business.Abstractions;

public interface IMovementsRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
}
