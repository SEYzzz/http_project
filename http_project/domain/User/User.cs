namespace http_project.domain.User
{
    public class User
    {
        public Guid Guid { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
    }
}
