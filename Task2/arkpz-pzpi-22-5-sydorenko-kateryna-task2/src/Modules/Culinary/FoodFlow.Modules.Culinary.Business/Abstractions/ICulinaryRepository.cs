using FoodFlow.Common.Persistence;

namespace FoodFlow.Modules.Culinary.Business.Abstractions;

public interface ICulinaryRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
}
