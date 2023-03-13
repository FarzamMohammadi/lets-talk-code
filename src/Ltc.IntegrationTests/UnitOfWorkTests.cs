using Ltc.API.Domain;
using Ltc.API.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        public void Add_WhenCalledWithObject_TracksObject()
        {
            var todo = new Todo("Title");
            _unitOfWork.Add(todo);

            Assert.True(_unitOfWork.IsTracked(todo));
        }

        [Fact]
        public void Complete_WhenCalled_PersistAddedEntities()
        {
            var context = _serviceScope.ServiceProvider.GetRequiredService<DataContext>();

            var todo = new Todo("Title");
            _unitOfWork.Add(todo);

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