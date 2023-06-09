using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagement.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly GlobalTicketDbContext DbContext;

    public BaseRepository(GlobalTicketDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var t = await DbContext.Set<T>().FindAsync(id, token);
        return t;
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken token = default)
    {
        return await DbContext.Set<T>().ToListAsync(token);
    }

    public virtual async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size, CancellationToken token = default)
    {
        return await DbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync(token);
    }

    public async Task<T> AddAsync(T entity, CancellationToken token = default)
    {
        await DbContext.Set<T>().AddAsync(entity, token);
        await DbContext.SaveChangesAsync(token);

        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken token = default)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(T entity, CancellationToken token = default)
    {
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync(token);
    }
}