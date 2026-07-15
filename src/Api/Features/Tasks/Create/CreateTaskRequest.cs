namespace Api.Features.Tasks.Create;

public sealed class CreateTaskRequest
{
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime Date { get; init; }
    public int Priority { get; init; }
}
