using Api.Infrastructure.Persistence;

namespace Api.Features.Tasks.Search;

public sealed class SearchTasksHandler
{
    private readonly ITaskRepository _repository;

    public SearchTasksHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<SearchTasksResponse>> HandleAsync(SearchTasksRequest request, CancellationToken cancellationToken)
    {
        var tasks = _repository.Search(request.Search)
            .Select(task => new SearchTasksResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Date = task.Date,
                Priority = task.Priority
            })
            .ToList();

        return Task.FromResult<IReadOnlyList<SearchTasksResponse>>(tasks);
    }
}
