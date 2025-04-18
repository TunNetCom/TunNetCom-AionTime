using System.Linq.Expressions;
using TunNetCom.AionTime.SharedKernel.BaseEntites;
using TunNetCom.AionTime.SharedKernel.Data;

namespace TimeLogService.Infrastructure.Repositories;

public class Repository<T>(TimeLogServiceDataBaseContext context)
    : IRepository<T>
    where T : BaseEntity
{
    private readonly TimeLogServiceDataBaseContext _context = context;

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.AddRangeAsync(entities);
        _ = await _context.SaveChangesAsync();
    }

    public async Task AddAsync(T entity)
    {
        _ = await _context.AddAsync(entity);
        _ = await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        T? entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id)
            ?? throw new KeyNotFoundException(id.ToString());

        _ = _context.Remove(entity);
        _ = await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _ = _context.Entry(entity).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _ = _context.Entry(entities).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _context.RemoveRange(entities);
        _ = await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync();
    }
}