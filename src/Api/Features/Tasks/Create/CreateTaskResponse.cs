namespace Api.Features.Tasks.Create;

public sealed class CreateTaskResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
}
