using Ltc.API.Domain;
using Ltc.API.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Program = Ltc.API.Program;

namespace Ltc.IntegrationTests
{
    public class UnitOfWorkTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IServiceScope _serviceScope;

        public UnitOfWorkTests(WebApplicationFactory<Program> factory)
        {
            _serviceScope = factory.Services.CreateScope();
            var context = _serviceScope.ServiceProvider.GetRequiredService<DataContext>();
            _unitOfWork = new UnitOfWork(context);
        }

        [Fact]
        public void Complete_WhenCalled_PersistAddedEntities()
        {
            var context = _serviceScope.ServiceProvider.GetRequiredService<DataContext>();

            var todo = new Todo("Title");
            _unitOfWork.Todos.Add(todo);

            _unitOfWork.Complete();

            // check by repository?
            Assert.NotNull(context.Todos.Find(todo.Id));
        }

        public void Dispose()
        {
            _serviceScope.Dispose();
        }
    }
}