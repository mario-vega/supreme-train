using Api.Features.Tasks;
using Api.Features.Tasks.Get;
using Api.Infrastructure.Persistence;
using Moq;

namespace Api.Tests.Features.Tasks.Get;

public class GetTaskHandlerTests
{
    [Fact]
    public async Task GetTaskHandler_Should_ReturnTask_When_TaskExists()
    {
        var repository = new Mock<ITaskRepository>();
        var expectedTask = new TaskItem { Id = Guid.NewGuid(), Title = "Test", Date = DateTime.UtcNow, Priority = 2 };
        repository.Setup(x => x.GetById(expectedTask.Id)).Returns(expectedTask);

        var handler = new GetTaskHandler(repository.Object);
        var response = await handler.HandleAsync(new GetTaskRequest { Id = expectedTask.Id }, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(expectedTask.Id, response.Id);
        Assert.Equal(expectedTask.Title, response.Title);
        repository.Verify(x => x.GetById(expectedTask.Id), Times.Once);
    }
}
