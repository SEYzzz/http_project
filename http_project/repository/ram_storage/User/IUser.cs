using http_project.domain.User;
namespace http_project.repository.ram_storage.User
{
    public interface IUser
    {
        public Guid AddUser(domain.User.User user);
        public domain.User.User? GetById(Guid id);
        public domain.User.User? GetByLogin(string login);
    }
}
