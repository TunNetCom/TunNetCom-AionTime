using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TunNetCom.AionTime.SharedKernel.Data;

public class Repository<TEntity,TDBContext>
    : IRepository<TEntity>
    where TEntity : BaseEntity
    where TDBContext : DbContext
{
    protected readonly TDBContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(TDBContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entities);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _ = await _dbSet.AddAsync(entity, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        TEntity? entity = await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException(id.ToString());

        _ = _dbSet.Remove(entity);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _ = _dbSet.Entry(entity).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        _ = _context.Entry(entities).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        _dbSet.RemoveRange(entities);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsPropertyExistAsync<TProperty>(
        Expression<Func<TEntity, TProperty>> propertySelector,
        TProperty value,
        object? excludeId = null,
        bool caseSensitive = false)
    {
        // Handle null values (decide if null should be considered unique)
        if (value == null) return true;

        // Get property name from selector
        if (propertySelector.Body is not MemberExpression memberExpression)
            throw new ArgumentException("Invalid property selector");

        var propertyName = memberExpression.Member.Name;
        var propertyInfo = typeof(TEntity).GetProperty(propertyName);

        if (propertyInfo == null)
            throw new ArgumentException($"Property {propertyName} not found on {typeof(TEntity).Name}");

        // Build the comparison expression
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var propertyAccess = Expression.Property(parameter, propertyInfo);
        Expression comparison;

        // Handle string comparison (case sensitive/insensitive)
        if (propertyInfo.PropertyType == typeof(string) && !caseSensitive)
        {
            // Case-insensitive comparison
            var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
            var lowerProperty = Expression.Call(propertyAccess, toLowerMethod);
            var lowerValue = Expression.Constant(value.ToString().ToLower());
            comparison = Expression.Equal(lowerProperty, lowerValue);
        }
        else
        {
            // Default comparison
            comparison = Expression.Equal(propertyAccess, Expression.Constant(value));
        }

        var lambda = Expression.Lambda<Func<TEntity, bool>>(comparison, parameter);
        var query = _dbSet.Where(lambda);

        // Handle excluded ID (for updates)
        if (excludeId != null)
        {
            var idProperty = FindIdProperty();
            if (idProperty != null)
            {
                var idParameter = Expression.Parameter(typeof(TEntity), "x");
                var idPropertyAccess = Expression.Property(idParameter, idProperty);
                var idComparison = Expression.NotEqual(
                    idPropertyAccess,
                    Expression.Convert(Expression.Constant(excludeId), idProperty.PropertyType));
                var idLambda = Expression.Lambda<Func<TEntity, bool>>(idComparison, idParameter);
                query = query.Where(idLambda);
            }
        }

        return await query.AnyAsync();
    }

    private PropertyInfo FindIdProperty()
    {
        // Look for common ID property names
        var idNames = new[] { "Id", "ID", $"{typeof(TEntity).Name}Id", $"{typeof(TEntity).Name}ID" };

        foreach (var name in idNames)
        {
            var prop = typeof(TEntity).GetProperty(name);
            if (prop != null) return prop;
        }

        return null;
    }
}