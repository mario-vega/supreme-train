using Api.Infrastructure.Persistence;

namespace Api.Features.Tasks.Today;

public sealed class GetTodayTasksHandler
{
    private readonly ITaskRepository _repository;

    public GetTodayTasksHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<GetTodayTasksResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        var tasks = _repository.GetToday()
            .Select(task => new GetTodayTasksResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Date = task.Date,
                Priority = task.Priority
            })
            .ToList();

        return Task.FromResult<IReadOnlyList<GetTodayTasksResponse>>(tasks);
    }
}
