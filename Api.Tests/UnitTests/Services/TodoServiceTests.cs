using Moq;
using TodoApi.Infrastructure.Database;
using TodoApi.Repositories.Todo;
using TodoApi.Services.Todo;

namespace Api.Tests.UnitTests.Services
{
    public class TodoServiceTests
    {
        private readonly Mock<ITodoRepository> _repositoryMock;
        private readonly ITodoService _service;

        public TodoServiceTests()
        {
            _repositoryMock = new Mock<ITodoRepository>();
            _service = new TodoService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetTodoListAsyncでリストが正常に返却されることの確認()
        {
            // Arrange
            var testData = new List<TodoEntity>
            {
                new TodoEntity { Id = 1, Title = "Test1", Completed = false },
                new TodoEntity { Id = 2, Title = "Test2", Completed = true }
            };
            _repositoryMock.Setup(repo => repo.GetTodoListAsync()).ReturnsAsync(testData);

            // Act
            var result = await _service.GetTodoListAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(testData[0].Id, result.ElementAt(0).Id);
            Assert.Equal(testData[0].Title, result.ElementAt(0).Title);
            Assert.Equal(testData[1].Id, result.ElementAt(1).Id);
            Assert.Equal(testData[1].Title, result.ElementAt(1).Title);
        }

        [Fact]
        public async Task GetTodoListAsyncでリストがない場合0件で返却されることの確認()
        {
            // Arrange
            var testData = new List<TodoEntity> { };
            _repositoryMock.Setup(repo => repo.GetTodoListAsync()).ReturnsAsync(testData);

            // Act
            var result = await _service.GetTodoListAsync();

            // Assert
            Assert.Equal(0, result.Count());
        }
    }
}