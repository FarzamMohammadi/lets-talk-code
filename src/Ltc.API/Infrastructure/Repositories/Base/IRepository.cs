namespace Ltc.API.Infrastructure.Repositories.Base;

public interface IRepository<T> where T : class
{
    Task<T?> Find<TK>(TK id);
    void Add(T entity);
    void AddRange(params T[] entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}