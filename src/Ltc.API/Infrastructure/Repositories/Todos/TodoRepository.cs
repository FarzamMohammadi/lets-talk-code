using Ltc.API.Domain;
using Ltc.API.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ltc.API.Infrastructure.Repositories.Todos;

public class TodoRepository : Repository<Todo>, ITodoRepository
{
    public TodoRepository(DataContext context) : base(context)
    {
    }

    public async Task<Todo?> WithTitle(string title)
    {
        return await Context.Todos.FirstOrDefaultAsync(p => p.Title == title);
    }
}