using FoodFlow.Common.Persistence;
using FoodFlow.Modules.Movements.Business.Abstractions;

namespace FoodFlow.Modules.Movements.Persistence.Repository;

public class MovementsRepository<TEntity> : Repository<TEntity>, IMovementsRepository<TEntity>
    where TEntity : class
{
    public MovementsRepository(MovementsDbContext context) : base(context)
    {
    }
}
