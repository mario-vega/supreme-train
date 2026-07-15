using Api.Infrastructure.Persistence;

namespace Api.Features.Tasks.List;

public sealed class ListTasksHandler
{
    private readonly ITaskRepository _repository;

    public ListTasksHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<ListTasksResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var tasks = _repository.GetAll()
            .Select(task => new ListTasksResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Date = task.Date,
                Priority = task.Priority
            })
            .ToList();

        return Task.FromResult<IReadOnlyList<ListTasksResponse>>(tasks);
    }
}
