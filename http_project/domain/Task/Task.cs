namespace http_project.domain.Task
{
    public enum TaskStatus
    {
        in_progress,
        ready
    }
    public class Task
    {
        public Guid Guid {  get; set; }
        public TaskStatus Status { get; set; }
        public string? Result { get; set; }
    }
}
