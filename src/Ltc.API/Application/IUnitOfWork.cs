namespace Ltc.API.Application;

public interface IUnitOfWork
{
    void Add<T>(T obj);
    void Complete();
}