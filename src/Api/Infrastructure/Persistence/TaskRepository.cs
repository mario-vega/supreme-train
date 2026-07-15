using Api.Features.Tasks;

namespace Api.Infrastructure.Persistence;

public sealed class TaskRepository : ITaskRepository
{
    private static readonly List<TaskItem> Tasks = [];

    public TaskItem GetById(Guid id) => Tasks.FirstOrDefault(t => t.Id == id) ?? throw new InvalidOperationException("Task not found.");

    public IEnumerable<TaskItem> Search(string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return Tasks;
        }

        return Tasks.Where(t => t.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<TaskItem> GetAll() => Tasks.OrderByDescending(t => t.Date);

    public IEnumerable<TaskItem> GetToday() => Tasks.Where(t => t.Date.Date == DateTime.UtcNow.Date).OrderByDescending(t => t.Date);

    public void Add(TaskItem task) => Tasks.Add(task);

    public void Update(TaskItem task)
    {
        var index = Tasks.FindIndex(t => t.Id == task.Id);
        if (index >= 0)
        {
            Tasks[index] = task;
        }
    }

    public void Delete(Guid id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task is not null)
        {
            Tasks.Remove(task);
        }
    }
}
