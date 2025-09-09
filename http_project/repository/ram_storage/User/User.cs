using http_project.domain.User;
using http_project.domain.Exceptions;
namespace http_project.repository.ram_storage.User
{
    public class User : IUser
    {
        private Dictionary<Guid, domain.User.User> data = new Dictionary<Guid, domain.User.User>();
        private Dictionary<string, domain.User.User> dataByLogin = new Dictionary<string, domain.User.User>();

        public Guid AddUser(domain.User.User user)
        {
            try
            {
                if (dataByLogin.ContainsKey(user.Login))
                    throw new UserAlreadyExistsException($"User with login {user.Login} already exists");
                data.Add(user.Id, user);
                dataByLogin.Add(user.Login, user);
                return user.Id;
            }
            catch(Exception ex) when (ex is not  UserAlreadyExistsException)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }

        public domain.User.User? GetById(Guid Id)
        { 
            try
            {
                if (!data.ContainsKey(Id))
                    return null;
                return data[Id];
            }
            catch(Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }

        public domain.User.User? GetByLogin(string login)
        {
            try
            {
                if (!dataByLogin.ContainsKey(login))
                    return null;
                return dataByLogin[login];
            }
            catch(Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }
    }
}
