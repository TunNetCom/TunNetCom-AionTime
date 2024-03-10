using TunNetCom.AionTime.TimeLogService.Domain.Interfaces;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;
using TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;

namespace TunNetCom.AionTime.TimeLogService.Infrastructure.GenericRepository;

public class GeniricRepository<T> : IGeniricRepository<T> where T : BaseEntity
{
    private readonly TunNetComAionTimeTimeLogServiceDataBaseContext _context;
    public GeniricRepository(TunNetComAionTimeTimeLogServiceDataBaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
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
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
