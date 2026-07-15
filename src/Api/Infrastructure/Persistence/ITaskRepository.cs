using Api.Features.Tasks;

namespace Api.Infrastructure.Persistence;

public interface ITaskRepository
{
    TaskItem GetById(Guid id);
    IEnumerable<TaskItem> Search(string? search);
    IEnumerable<TaskItem> GetAll();
    IEnumerable<TaskItem> GetToday();
    void Add(TaskItem task);
    void Update(TaskItem task);
    void Delete(Guid id);
}
