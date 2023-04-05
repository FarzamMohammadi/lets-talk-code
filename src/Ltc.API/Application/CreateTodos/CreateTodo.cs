using Ltc.API.Domain;

namespace Ltc.API.Application.CreateTodos;

public class CreateTodo
{
    private readonly IUnitOfWork _unitOfWork;

    // Repository - Query Objects
    // Unit of Work - Tracks objects retrieve from external resource 

    public CreateTodo(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateTodoDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new ArgumentException();
        }

        var todo = new Todo(dto.Title);

        _unitOfWork.Todos.Add(todo);
        _unitOfWork.Complete();
    }
}