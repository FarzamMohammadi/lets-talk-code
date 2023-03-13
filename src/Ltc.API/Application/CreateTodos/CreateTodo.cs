using Ltc.API.Domain;

namespace Ltc.API.Application;

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
            throw new ArgumentException();
        }

        var todo = new Todo(dto.Title);

        _db.Add(todo);
        _db.Complete();
    }
}