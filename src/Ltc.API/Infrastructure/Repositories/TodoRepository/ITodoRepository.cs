using Ltc.API.Domain;
using Ltc.API.Infrastructure.Repositories.Base;

namespace Ltc.API.Infrastructure.Repositories.TodoRepository;

public interface ITodoRepository : IRepository<Todo>
{
    Task<Todo?> WithTitle(string title);
}