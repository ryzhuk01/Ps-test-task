namespace BuildingBlocks.Persistence.Abstractions;

public interface IRepositoryBase<T>
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
