using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TunNetCom.AionTime.SharedKernel.Data;

public class Repository<TEntity,TDBContext>(TDBContext context)
    : IRepository<TEntity>
    where TEntity : BaseEntity
    where TDBContext : DbContext
{
    private readonly TDBContext _context = context;

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _context.AddRangeAsync(entities);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _ = await _context.AddAsync(entity, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        TEntity? entity = await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException(id.ToString());

        _ = _context.Remove(entity);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _ = _context.Entry(entity).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        _ = _context.Entry(entities).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        _context.RemoveRange(entities);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AsNoTracking().Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }
}