using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Persistence.Repositories;


public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : BaseEntity, new() where TContext : DbContext, new()
{
    public virtual async Task<List<TEntity>> GetAllPageAsync(PaginationQuery paginationQuery, Expression<Func<TEntity, bool>> filter = null)
    {
        try
        {
            await using TContext context = new();
            return filter == null
                ? await context.Set<TEntity>().Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize)
                    .Take(paginationQuery.PageSize).ToListAsync()
                : await context.Set<TEntity>().Where(filter)
                    .Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize).Take(paginationQuery.PageSize)
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        try
        {
            using TContext context = new();
            return filter == null
                ? context.Set<TEntity>().AsQueryable()
                : context.Set<TEntity>().Where(filter).AsQueryable();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        try
        {
            await using TContext context = new();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        try
        {
            await using TContext context = new();
            return filter == null
                ? await context.Set<TEntity>().CountAsync()
                : await context.Set<TEntity>().Where(filter).CountAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task<decimal> GetSumAsync(Expression<Func<TEntity, decimal>> selector,
        Expression<Func<TEntity, bool>> filter = null)
    {
        try
        {
            await using TContext context = new();
            return filter == null
                ? await context.Set<TEntity>().SumAsync(selector)
                : await context.Set<TEntity>().Where(filter).SumAsync(selector);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        try
        {
            await using TContext context = new();
            return filter == null
                ? await context.Set<TEntity>().FirstOrDefaultAsync()
                : await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task<TEntity> AddAndReturnAsync(TEntity entity)
    {
        try
        {
            await using TContext context = new();
            var entry = context.Entry<TEntity>(entity);
            entry.State = EntityState.Added;
            await context.SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        try
        {
            await using TContext context = new();
            context.Add(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        try
        {
            await using TContext context = new();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        try
        {
            await using TContext context = new();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task<int> CountAsync()
    {
        await using TContext context = new();
        return await context.Set<TEntity>().CountAsync();
    }
}
