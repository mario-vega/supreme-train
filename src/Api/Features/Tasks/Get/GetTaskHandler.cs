using Api.Infrastructure.Persistence;

namespace Api.Features.Tasks.Get;

public sealed class GetTaskHandler
{
    private readonly ITaskRepository _repository;

    public GetTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<GetTaskResponse> HandleAsync(GetTaskRequest request, CancellationToken cancellationToken)
    {
        var task = _repository.GetById(request.Id);

        var response = new GetTaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Date = task.Date,
            Priority = task.Priority
        };

        return Task.FromResult(response);
    }
}
