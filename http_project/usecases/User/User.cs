using http_project.domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace http_project.usecases.User
{
    public class User : IUser
    {
        private readonly repository.ram_storage.User.IUser repo;

        public User(repository.ram_storage.User.IUser repo)
        {
            this.repo = repo;
        }

        public async Task<string> AddUserAsync(string login, string password)
        {
            try
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                var user = new domain.User.User(
                    Guid.NewGuid(),
                    login,
                    passwordHash
                );
                repo.AddUser(user);
                return user.Guid.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<domain.User.User> GetUserByIdAsync(Guid id)
        {
            var user = repo.GetById(id);
            if (user == null)
                throw new UserNotFoundException($"User {id} not found");
            return user;
        }

        public async Task<domain.User.User?> GetByLoginAsync(string login)
        {
            var user = repo.GetByLogin(login);
            if (user == null)
                throw new UserNotFoundException($"User {login} not found");
            return user;
        }
    }
}
