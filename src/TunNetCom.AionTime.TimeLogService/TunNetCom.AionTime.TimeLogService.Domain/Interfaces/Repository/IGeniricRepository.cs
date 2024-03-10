namespace TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;

public interface IGeniricRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entitys);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
