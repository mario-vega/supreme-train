using Api.Features.Tasks;
using Api.Features.Tasks.Search;
using Api.Infrastructure.Persistence;
using Moq;

namespace Api.Tests.Features.Tasks.Search;

public class SearchTasksHandlerTests
{
    [Fact]
    public async Task SearchTasksHandler_Should_ReturnMatchingTasks_When_SearchTermIsProvided()
    {
        var repository = new Mock<ITaskRepository>();
        var expectedTasks = new List<TaskItem>
        {
            new() { Id = Guid.NewGuid(), Title = "Homework", Date = DateTime.UtcNow, Priority = 2 },
            new() { Id = Guid.NewGuid(), Title = "Home repairs", Date = DateTime.UtcNow.AddMinutes(-1), Priority = 1 }
        };

        repository.Setup(x => x.Search("home")).Returns(expectedTasks);

        var handler = new SearchTasksHandler(repository.Object);
        var response = await handler.HandleAsync(new SearchTasksRequest { Search = "home" }, CancellationToken.None);

        Assert.NotNull(response);
        Assert.Equal(2, response.Count);
        Assert.Equal("Homework", response[0].Title);
        Assert.Equal("Home repairs", response[1].Title);
        repository.Verify(x => x.Search("home"), Times.Once);
    }
}
