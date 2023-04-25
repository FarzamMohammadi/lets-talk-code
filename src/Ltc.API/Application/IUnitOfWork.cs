using Ltc.API.Infrastructure.Repositories.Orders;
using Ltc.API.Infrastructure.Repositories.Todos;

namespace Ltc.API.Application;

public interface IUnitOfWork
{
    ITodoRepository Todos { get; }
    IOrderRepository Orders { get; }
    Task Complete(CancellationToken cancellationToken = default);
}