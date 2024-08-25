namespace TimeLogService.Domain.Interfaces.Repositories;

public interface IRepository<T>
    where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();

    Task<T?> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    Task UpdateAsync(T entity);

    Task UpdateRangeAsync(IEnumerable<T> entities);

    Task DeleteAsync(int id);

    Task DeleteRangeAsync(IEnumerable<T> entities);
}