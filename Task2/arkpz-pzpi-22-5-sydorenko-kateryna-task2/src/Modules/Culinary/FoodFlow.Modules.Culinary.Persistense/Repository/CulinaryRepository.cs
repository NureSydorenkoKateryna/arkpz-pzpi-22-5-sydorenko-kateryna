using FoodFlow.Common.Persistence;
using FoodFlow.Modules.Culinary.Business.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FoodFlow.Modules.Culinary.Persistence.Repository;

public class CulinaryRepository<TEntity> 
    : Repository<TEntity>, ICulinaryRepository<TEntity>
    where TEntity : class
{
    public CulinaryRepository(CulinaryDbContext context) 
        : base(context) {}
}
