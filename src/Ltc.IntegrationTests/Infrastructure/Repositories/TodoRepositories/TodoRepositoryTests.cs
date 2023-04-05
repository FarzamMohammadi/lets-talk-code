using Ltc.API.Domain;
using Ltc.API.Infrastructure;
using Ltc.API.Infrastructure.Repositories.TodoRepositories;
using Microsoft.EntityFrameworkCore;

namespace Ltc.IntegrationTests.Infrastructure.Repositories.TodoRepositories;

public class TodoRepositoryTests
{
    [Fact]
    public async Task WithTitle_WithExistingTitleForATodo_ReturnsThatTodo()
    {
        var options = new DbContextOptionsBuilder<DataContext>();

        options.UseSqlServer
        (
            "Server=tcp:localhost,5433;Database=ltc;User Id=sa;Password=Welcome1;MultipleActiveResultSets=True;Connection Timeout=30;Trust Server Certificate=true;"
        );

        var context = new DataContext(options.Options);

        var todoRepository = new TodoRepository(context);

        var title = "Testing";
        todoRepository.Add(new Todo(title));

        await context.SaveChangesAsync();

        var todo = await todoRepository.WithTitle(title);

        Assert.NotNull(todo);
    }
}