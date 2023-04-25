namespace Ltc.API.Infrastructure.Repositories.Base;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly DataContext Context;

    protected Repository(DataContext context)
    {
        Context = context;
    }

    public async Task<T?> Find<TK>(TK id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void AddRange(params T[] entities)
    {
        Context.Set<T>().AddRange(entities);
    }

    public void Update(T entity)
    {
        Context.Set<T>().Attach(entity);
    }

    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        Context.Set<T>().RemoveRange(entities);
    }
}