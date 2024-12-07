using FoodFlow.Common;
using ResulStatic = FoodFlow.Common.Result.Result;
using FoodFlow.Common.Result;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFlow.Common.Persistence;

public abstract class Repository<TEntity>(DbContext context) // todo: add logging here
    : IRepository<TEntity> where TEntity : class
{
    public virtual async Task<Result<bool>> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        try
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            
            return ResulStatic.Success(true);
        }
        catch (Exception ex)
        {
            return RepositoryResult.FailToAdd(typeof(TEntity).Name).GetFailureResult<bool>();
        }
    }

    public virtual async Task<Result<bool>> DeleteAsync(long id, CancellationToken ct = default)
    {
        try
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return RepositoryResult.NotFound(typeof(TEntity).Name).GetFailureResult<bool>();
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return ResulStatic.Success(true);
        }
        catch (Exception ex)
        {
            return RepositoryResult.FailToDelete(typeof(TEntity).Name).GetFailureResult<bool>();
        }
    }

    public virtual async Task<Result<IEnumerable<TEntity>>> GetAllAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> orderBy = null,
        int? pageNum = null, int? count = null,
        CancellationToken ct = default)
    {
        try
        {
            IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (pageNum != null && count != null)
            {
                query = query.Skip((int)((pageNum - 1) * count)).Take((int)count);
            }
            else if (count != null)
            {
                query = query.Take((int)count);
            }

            if (orderBy != null)
            {
                return ResulStatic.Success<IEnumerable<TEntity>>(await orderBy.Compile()(query).ToListAsync());
            }
            else
            {
                return ResulStatic.Success<IEnumerable<TEntity>>(await query.ToListAsync());
            }
        }
        catch (Exception ex)
        {
            return RepositoryResult.FailToGetAll(typeof(TEntity).Name).GetFailureResult<IEnumerable<TEntity>>();
        }
    }

    public virtual async Task<Result<TEntity>> GetByIdAsync(long id, CancellationToken ct = default)
    {
        try
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return RepositoryResult.NotFound(typeof(TEntity).Name).GetFailureResult<TEntity>();
            }

            return ResulStatic.Success(entity);
        }
        catch (Exception ex)
        {
            return RepositoryResult.FailToGetById(typeof(TEntity).Name).GetFailureResult<TEntity>();
        }
    }

    public virtual async Task<Result<TEntity>> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, CancellationToken ct = default)
    {
        try
        {
            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(filter, ct);
            return ResulStatic.Success(entity);
        }
        catch (Exception ex)
        {
            return RepositoryResult.FailToGetFirstOrDefault(typeof(TEntity).Name).GetFailureResult<TEntity>();
        }
    }

    public virtual async Task<Result<bool>> IsUnique(Expression<Func<TEntity, bool>> filter, CancellationToken ct = default)
    {
        try
        {
            IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
            var exists = await query.AnyAsync(filter);
            return ResulStatic.Success(!exists);
        }
        catch(Exception ex)
        {
            return RepositoryResult.FailToCheckUniqueness(typeof(TEntity).Name).GetFailureResult<bool>();
        }
    }

    public virtual async Task<Result<bool>> UpdateAsync(TEntity entity, CancellationToken ct = default)
    {
        try
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return ResulStatic.Success(true);
        }
        catch (Exception ex)
        {
            return RepositoryResult.FailToUpdate(typeof(TEntity).Name).GetFailureResult<bool>();
        }
    }
}
