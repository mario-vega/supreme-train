namespace Api.Features.Tasks;

public sealed class TaskItem
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime Date { get; init; }
    public int Priority { get; init; }
}
