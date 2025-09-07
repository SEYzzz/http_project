using Microsoft.AspNetCore.Mvc;

namespace http_project.usecases.Session
{
    public class Session : ISession
    {
        private readonly repository.ram_storage.Session.ISession repo;

        public Session(repository.ram_storage.Session.ISession repo)
        {
            this.repo = repo;
        }

        public async Task<ActionResult<domain.Session.Session>> GetById(string id)
        {
            return repo.GetById(id);
        }

        public async Task<ActionResult<System.Threading.Tasks.Task>> AddAsync(domain.Session.Session session)
        {
            return repo.AddAsync(session);
        }

        public async Task<ActionResult<System.Threading.Tasks.Task>> DeleteAsync(string sessionId)
        {
            return repo.DeleteAsync(sessionId);
        }
    }
}
