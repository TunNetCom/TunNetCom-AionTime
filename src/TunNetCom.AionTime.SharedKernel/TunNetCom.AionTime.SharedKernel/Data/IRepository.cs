using System.Linq.Expressions;
using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TunNetCom.AionTime.SharedKernel.Data;

public interface IRepository<T>
    where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();

    Task<T?> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>> predicate);

    Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    Task UpdateAsync(T entity);

    Task UpdateRangeAsync(IEnumerable<T> entities);

    Task DeleteAsync(int id);

    Task DeleteRangeAsync(IEnumerable<T> entities);
}