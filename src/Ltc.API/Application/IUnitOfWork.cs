using Ltc.API.Infrastructure.Repositories.TodoRepository;

namespace Ltc.API.Application;

public interface IUnitOfWork
{
    ITodoRepository Todos { get; }
    Task Complete(CancellationToken cancellationToken = default);
}