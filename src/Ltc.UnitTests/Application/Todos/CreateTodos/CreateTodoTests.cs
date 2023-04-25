using Ltc.API.Application;
using Ltc.API.Application.CreateTodos;
using Ltc.API.Domain;
using Moq;

namespace Ltc.Tests.Application;

public class CreateTodoTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_WithInvalidTitle_ThrowsArgumentException(string title)
    {
        var mock = new Mock<IUnitOfWork>();

        var createTodo = new CreateTodo(mock.Object);

        Assert.Throws<ArgumentException>(() => createTodo.Create(new CreateTodoDto { Title = title }));
    }

    [Fact]
    public void Create_WithValidTodo_CallsUnitOfWorkAdd()
    {
        var mock = new Mock<IUnitOfWork>();
        mock.Setup(p => p.Todos.Add(It.IsAny<Todo>()));

        var createTodo = new CreateTodo(mock.Object);

        createTodo.Create(new CreateTodoDto { Title = "123" });

        mock.Verify(p => p.Todos.Add(It.IsAny<Todo>()), Times.Once);
    }

    [Fact]
    public void Create_WithValidTodo_CompletesTheUnitOfWork()
    {
        var mock = new Mock<IUnitOfWork>();
        mock.Setup(p => p.Todos.Add(It.IsAny<Todo>()));

        var createTodo = new CreateTodo(mock.Object);

        createTodo.Create(new CreateTodoDto { Title = "123" });

        mock.Verify(p => p.Complete(It.IsAny<CancellationToken>()), Times.Once);
    }
}