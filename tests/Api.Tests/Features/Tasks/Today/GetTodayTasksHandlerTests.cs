using Api.Features.Tasks;
using Api.Features.Tasks.Today;
using Api.Infrastructure.Persistence;
using Moq;

namespace Api.Tests.Features.Tasks.Today;

public class GetTodayTasksHandlerTests
{
    [Fact]
    public async Task GetTodayTasksHandler_Should_ReturnTasksForToday()
    {
        var repository = new Mock<ITaskRepository>();
        var expectedTasks = new List<TaskItem>
        {
            new() { Id = Guid.NewGuid(), Title = "Today task", Date = DateTime.UtcNow, Priority = 2 }
        };

        repository.Setup(x => x.GetToday()).Returns(expectedTasks);

        var handler = new GetTodayTasksHandler(repository.Object);
        var response = await handler.HandleAsync(CancellationToken.None);

        Assert.NotNull(response);
        Assert.Single(response);
        Assert.Equal(expectedTasks[0].Title, response[0].Title);
        repository.Verify(x => x.GetToday(), Times.Once);
    }
}
