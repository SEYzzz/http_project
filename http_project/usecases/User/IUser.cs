using Microsoft.AspNetCore.Mvc;
using http_project.domain.User;
namespace http_project.usecases.User
{
    public interface IUser
    {
        public Task<string> AddUserAsync(string login, string password);
        public Task<domain.User.User?> GetUserByIdAsync(Guid id);
        public Task<domain.User.User?> GetByLoginAsync(string login);
    }
}
