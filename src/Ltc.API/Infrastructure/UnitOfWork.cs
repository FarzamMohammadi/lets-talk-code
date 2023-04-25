using Ltc.API.Application;
using Ltc.API.Infrastructure.Repositories.Orders;
using Ltc.API.Infrastructure.Repositories.Todos;

namespace Ltc.API.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _db;
    public ITodoRepository Todos { get; }
    public IOrderRepository Orders { get; }

    public UnitOfWork(DataContext db)
    {
        _db = db;
        Todos = new TodoRepository(_db);
        Orders = new OrderRepository(_db);
    }

    public Task Complete(CancellationToken cancellationToken = default) => _db.SaveChangesAsync(cancellationToken);
}