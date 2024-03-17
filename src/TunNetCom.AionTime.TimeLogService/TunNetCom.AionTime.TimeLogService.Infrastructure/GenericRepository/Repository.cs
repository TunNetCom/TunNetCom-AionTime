namespace TunNetCom.AionTime.TimeLogService.Infrastructure.GenericRepository;

public class Repository<T>(TunNetComAionTimeTimeLogServiceDataBaseContext context) : IGenericRepository<T>
    where T : BaseEntity
{
    private readonly TunNetComAionTimeTimeLogServiceDataBaseContext context = context;

    public async Task AddRangeAsync(List<T> entities)
    {
        await this.context.AddRangeAsync(entities);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task AddAsync(T entity)
    {
        _ = await this.context.AddAsync(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _ = this.context.Remove(entity);
        _ = await this.context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await this.context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await this.context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _ = this.context.Entry(entity).State = EntityState.Modified;
        _ = await this.context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<T> entities)
    {
        _ = this.context.Entry(entities).State = EntityState.Modified;
        _ = await this.context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<T> entities)
    {
         this.context.RemoveRange(entities);
         _ = await this.context.SaveChangesAsync();
    }
}
