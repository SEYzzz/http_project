using http_project.domain.Task;
namespace http_project.repository.ram_storage.Task
{
    public class Task : ITask
    {
        private Dictionary<Guid, domain.Task.Task> data = new Dictionary<Guid, domain.Task.Task>();

        public void CreateTask(domain.Task.Task task)
        {
            if (data.ContainsKey(task.Guid))
                throw new Exception("Key already exists");
            data.Add(task.Guid, task);
        } 

        public domain.Task.TaskStatus GetTaskStatus(Guid id)
        {
            if (!data.ContainsKey(id))
                throw new KeyNotFoundException();                 // тут выбрасываются ошибки, их либо в usecases обработать, либо выбрасывать их оттуда
            return data[id].Status;
        }

        public string GetTaskResult(Guid id)
        {
            if (!data.ContainsKey(id))
                throw new KeyNotFoundException();
            return data[id].Result??"";
        }

        public domain.Task.Task GetByIdAsync(Guid id)
        {
            if (!data.ContainsKey(id))
                throw new KeyNotFoundException();
            return data[id];
        }
    }
}
