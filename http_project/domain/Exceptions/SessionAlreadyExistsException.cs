namespace http_project.domain.Exceptions
{
    public class SessionAlreadyExistsException : Exception
    {
        public SessionAlreadyExistsException(string message) : base(message) { }
    }
}
