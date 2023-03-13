namespace Ltc.API.Domain;

public interface IUnitOfWork
{
    void Add<T>(T obj);
    void Complete();
}