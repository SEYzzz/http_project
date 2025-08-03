using http_project.domain.Task;
namespace http_project.usecases.Task;

public interface ITask
{
    public Task<Guid> CreateTaskAsync();
    public Task<domain.Task.TaskStatus> GetTaskStatusAsync(Guid id);
    public Task<string?> GetTaskResultAsync(Guid id);
    public Task<domain.Task.Task> GetById(Guid id);
}
