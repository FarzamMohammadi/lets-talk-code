namespace Ltc.API.Application.CreateTodos;

public class UpdateTodo
{
    private readonly IUnitOfWork _db;

    public UpdateTodo(IUnitOfWork db)
    {
        _db = db;
    }

    public void Update(UpdateTodoDto dto)
    {
     

        _db.Complete();
    }
}