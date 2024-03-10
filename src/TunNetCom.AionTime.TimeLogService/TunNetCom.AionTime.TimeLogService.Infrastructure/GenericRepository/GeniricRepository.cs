using TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;
using TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;

namespace TunNetCom.AionTime.TimeLogService.Infrastructure.GenericRepository;

public class GeniricRepository<T> : IGeniricRepository<T> where T : BaseEntity
{
    protected readonly TunNetComAionTimeTimeLogServiceDataBaseContext _context;
    public GeniricRepository(TunNetComAionTimeTimeLogServiceDataBaseContext context)
    {
        _context = context;
    }

    public async Task AddRangeAsync(List<T> entitys)
    {
        await _context.AddRangeAsync(entitys);
        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(T entity)
    {
       await _context.AddAsync(entity);
       await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
                .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
