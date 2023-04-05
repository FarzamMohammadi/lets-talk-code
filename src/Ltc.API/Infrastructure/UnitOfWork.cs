using Ltc.API.Application;
using Ltc.API.Infrastructure.Repositories.TodoRepositories;

namespace Ltc.API.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _db;
    public ITodoRepository Todos { get; }

    public UnitOfWork(DataContext db)
    {
        _db = db;
        Todos = new TodoRepository(_db);
    }

    public Task Complete(CancellationToken cancellationToken = default) => _db.SaveChangesAsync(cancellationToken);
}