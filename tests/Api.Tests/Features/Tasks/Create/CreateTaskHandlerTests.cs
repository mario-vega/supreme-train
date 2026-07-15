using Api.Features.Tasks;
using Api.Features.Tasks.Create;
using Api.Infrastructure.Persistence;
using Moq;

namespace Api.Tests.Features.Tasks.Create;

public class CreateTaskHandlerTests
{
    [Fact]
    public async Task CreateTaskHandler_Should_CreateTask_When_RequestIsValid()
    {
        var repository = new Mock<ITaskRepository>();
        var handler = new CreateTaskHandler(repository.Object);
        var request = new CreateTaskRequest { Title = "Test", Date = DateTime.UtcNow, Priority = 2 };

        var response = await handler.HandleAsync(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(request.Title, response.Title);
        Assert.NotEqual(Guid.Empty, response.Id);
        repository.Verify(x => x.Add(It.IsAny<TaskItem>()), Times.Once);
    }
}
