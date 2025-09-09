using http_project.domain.Session;
using Microsoft.AspNetCore.Mvc;

namespace http_project.usecases.Session
{
    public interface ISession
    {
        public Task<domain.Session.Session?> GetById(string id);
        public System.Threading.Tasks.Task AddAsync(Guid userId);
        public System.Threading.Tasks.Task DeleteAsync(string sessionId);
    }
}
