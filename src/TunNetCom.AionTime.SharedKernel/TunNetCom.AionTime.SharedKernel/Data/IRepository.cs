using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TunNetCom.AionTime.SharedKernel.Data;

public interface IRepository<T>
    where T : BaseEntity
{
    Task AddAsync(T entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task DeleteAsync(int id, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
}