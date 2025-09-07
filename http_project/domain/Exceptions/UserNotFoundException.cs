namespace http_project.domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message): base(message) { }
    }
}
