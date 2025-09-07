namespace http_project.domain.User
{
    public class User
    {
        public Guid Guid { get; private set; }
        public string Login { get; private set; }
        public string PasswordHash { get; private set; }

        public User() { }
        public User(Guid guid, string login, string passwordHash)
        {
            Guid = guid;
            Login = login;
            PasswordHash = passwordHash;
        }
    }
}
