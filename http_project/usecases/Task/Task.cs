
namespace http_project.usecases.Task
{
    public class Task : ITask
    {
        private readonly repository.ram_storage.Task.ITask repo;   // Не хорошо, что оно в рам лежит, надо куда-нибудь выкинуть в другое место

        public Task(repository.ram_storage.Task.ITask repo)
        {
            this.repo = repo;
        }

        public async Task<Guid> CreateTaskAsync()
        {
            var task = new domain.Task.Task
            {
                Guid = Guid.NewGuid(),
                Status = domain.Task.TaskStatus.in_progress,
                Result = null
            };

            repo.CreateTask(task);

            // какой-то очень сложный процесс
            _ = ProcessTaskAsync(task.Guid);

            return task.Guid;
        }

        public async Task<domain.Task.TaskStatus> GetTaskStatusAsync(Guid id)
        {
            var status = repo.GetTaskStatus(id);
            return status;
        }

        public async Task<string?> GetTaskResultAsync(Guid id)  // такой себе async
        {
            var result = repo.GetTaskResult(id);
            return result;
        }

        public async Task<domain.Task.Task> GetById(Guid id)
        {
            var task = repo.GetByIdAsync(id);
            return task;
        }

        private async System.Threading.Tasks.Task ProcessTaskAsync(Guid taskId)
        {
            await System.Threading.Tasks.Task.Delay(30000);

            var task = repo.GetByIdAsync(taskId);
            if (task == null)
                return;

            task.Status = domain.Task.TaskStatus.ready;
            task.Result = $"Result for {taskId} generated at {DateTime.UtcNow:O}";

            // Обновление таски
        }
    }
}
