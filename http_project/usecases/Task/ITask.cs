using Microsoft.AspNetCore.Mvc;
using http_project.domain.Task;

namespace http_project.usecases.Task;

public interface ITask
{
    public Task<ActionResult<Guid>> CreateTaskAsync();
    public Task<ActionResult<domain.Task.TaskStatus>> GetTaskStatusAsync(Guid id);
    public Task<ActionResult<string?>> GetTaskResultAsync(Guid id);
    public Task<ActionResult<domain.Task.Task>> GetById(Guid id);
}
