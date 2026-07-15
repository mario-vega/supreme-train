using Api.Features.Tasks;
using Api.Features.Tasks.List;
using Api.Infrastructure.Persistence;
using Moq;

namespace Api.Tests.Features.Tasks.List;

public class ListTasksHandlerTests
{
    [Fact]
    public async Task ListTasksHandler_Should_ReturnAllTasksInDescendingOrder()
    {
        var repository = new Mock<ITaskRepository>();
        var expectedTasks = new List<TaskItem>
        {
            new() { Id = Guid.NewGuid(), Title = "Older", Date = DateTime.UtcNow.AddDays(-1), Priority = 1 },
            new() { Id = Guid.NewGuid(), Title = "Newer", Date = DateTime.UtcNow, Priority = 2 }
        };

        repository.Setup(x => x.GetAll()).Returns(expectedTasks);

        var handler = new ListTasksHandler(repository.Object);
        var response = await handler.HandleAsync(CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(2, response.Count);
        Assert.Equal("Older", response[0].Title);
        Assert.Equal("Newer", response[1].Title);
        repository.Verify(x => x.GetAll(), Times.Once);
    }
}
