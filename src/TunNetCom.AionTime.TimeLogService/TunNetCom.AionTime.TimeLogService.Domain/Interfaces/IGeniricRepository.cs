namespace TunNetCom.AionTime.TimeLogService.Domain.Interfaces;

public interface IGeniricRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
