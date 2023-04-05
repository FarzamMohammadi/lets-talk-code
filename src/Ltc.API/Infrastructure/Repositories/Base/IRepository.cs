namespace Ltc.API.Infrastructure.Repositories.Base;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}