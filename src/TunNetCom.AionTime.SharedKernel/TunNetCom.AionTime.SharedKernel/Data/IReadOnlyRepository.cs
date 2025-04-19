using System.Linq.Expressions;

namespace TunNetCom.AionTime.SharedKernel.Data;

public interface IReadOnlyRepository<TEntity>
{
    Task<IReadOnlyList<TEntity>> GetAsync(CancellationToken cancellationToken);

    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IReadOnlyList<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}
