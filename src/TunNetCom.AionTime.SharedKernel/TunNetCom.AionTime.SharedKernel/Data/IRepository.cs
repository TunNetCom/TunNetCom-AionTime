using System.Linq.Expressions;
using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TunNetCom.AionTime.SharedKernel.Data;

public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task DeleteAsync(int id, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task<bool> IsPropertyExistAsync<TProperty>(
        Expression<Func<TEntity, TProperty>> propertySelector,
        TProperty value,
        object? excludeId = null,
        bool caseSensitive = false);
}