using System.Linq.Expressions;

namespace TunNetCom.AionTime.SharedKernel.Data;

public interface IReadOnlyRepository<T>
{
    Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken);

    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

    Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}
