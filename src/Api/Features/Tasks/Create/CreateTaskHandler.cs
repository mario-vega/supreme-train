using Api.Infrastructure.Persistence;

namespace Api.Features.Tasks.Create;

public sealed class CreateTaskHandler
{
    private readonly ITaskRepository _repository;

    public CreateTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<CreateTaskResponse> HandleAsync(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Date = request.Date == default ? DateTime.UtcNow : request.Date,
            Priority = request.Priority
        };

        _repository.Add(task);

        var response = new CreateTaskResponse
        {
            Id = task.Id,
            Title = task.Title
        };

        return Task.FromResult(response);
    }
}
