using http_project.domain.Task;

namespace http_project.repository.ram_storage.Task
{
    public interface ITask
    {
        public void CreateTask(domain.Task.Task task);
        public domain.Task.TaskStatus GetTaskStatus(Guid id);  // Можно возвращать или Task или TaskStatus?
        public string? GetTaskResult(Guid id);
        public domain.Task.Task GetByIdAsync(Guid id); 
    }
}
