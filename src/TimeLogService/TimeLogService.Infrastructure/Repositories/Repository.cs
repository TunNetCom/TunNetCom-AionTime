using System.Linq.Expressions;
using TunNetCom.AionTime.SharedKernel.BaseEntites;
using TunNetCom.AionTime.SharedKernel.Data;

namespace TimeLogService.Infrastructure.Repositories;

public class Repository<T>(TimeLogServiceDataBaseContext context)
    : IRepository<T>
    where T : BaseEntity
{
    private readonly TimeLogServiceDataBaseContext _context = context;

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await _context.AddRangeAsync(entities);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        _ = await _context.AddAsync(entity, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        T? entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException(id.ToString());

        _ = _context.Remove(entity);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _ = _context.Entry(entity).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        _ = _context.Entry(entities).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        _context.RemoveRange(entities);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }
}