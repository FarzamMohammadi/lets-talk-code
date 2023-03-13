using Ltc.API.Domain;

namespace Ltc.API.Application.CreateTodos;

public class CreateTodo
{
    private readonly IUnitOfWork _db;

    // Repository - Query Objects
    // Unit of Work - Tracks objects retrieve from external resource 

    public CreateTodo(IUnitOfWork db)
    {
        _db = db;
    }

    public void Create(CreateTodoDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new ArgumentException(nameof(dto.Title));
        }

        var todo = new Todo(dto.Title);

        _db.Add(todo);
        _db.Complete();
    }
}