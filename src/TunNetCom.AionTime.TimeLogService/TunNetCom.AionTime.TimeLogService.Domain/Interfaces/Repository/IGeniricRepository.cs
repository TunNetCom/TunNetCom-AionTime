namespace TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();

    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task AddRangeAsync(List<T> entities);

    Task UpdateAsync(T entity);

    Task UpdateRangeAsync(List<T> entities);

    Task DeleteAsync(T entity);

    Task DeleteRangeAsync(List<T> entities);

}
