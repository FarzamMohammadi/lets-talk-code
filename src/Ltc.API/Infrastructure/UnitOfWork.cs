using Ltc.API.Application;
using Ltc.API.Domain;

namespace Ltc.API.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _db;

    public UnitOfWork(DataContext db)
    {
        _db = db;
    }

    public void Add<T>(T obj)
    {
        _db.Add(obj);
    }

    public bool IsTracked<T>(T obj) where T : class
    {
        var entityEntries = _db.ChangeTracker.Entries<T>();

        return entityEntries.Any(p => p.Entity.Equals(obj));
    }

    public void Complete()
    {
        _db.SaveChanges();
    }

    public Todo TodoRepository { get; set; }
}