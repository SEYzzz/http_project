namespace http_project.domain.Exceptions
{
    public class SessionNotFoundException : Exception
    {
        public SessionNotFoundException(string message) : base(message) { }
    }
}
