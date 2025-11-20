using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Persistence.Abstractions;

public abstract class RepositoryBase<T>(DbContext context): IRepositoryBase<T> where T : Entity
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual Task SaveChangesAsync(CancellationToken cancellationToken) =>
        _context.SaveChangesAsync(cancellationToken);
}
