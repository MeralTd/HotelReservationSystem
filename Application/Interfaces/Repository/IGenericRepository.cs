using Application.Wrappers.Results;
using Domain.Common;
using System.Linq.Expressions;

namespace Application.Interfaces.Repository;
public interface IGenericRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    Task<List<T>> GetAllPageAsync(PaginationQuery paginationQuery, Expression<Func<T, bool>> filter = null);
    Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
    Task<T> AddAndReturnAsync(T entity);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task<int> CountAsync();
    Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
    Task<decimal> GetSumAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>> filter = null);
}

