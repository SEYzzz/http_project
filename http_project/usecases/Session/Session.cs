using http_project.domain.Exceptions;
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

        public async Task<domain.Session.Session?> GetById(string id)
        {
            try
            {
                var session = repo.GetById(id);
                if (session == null)
                    throw new SessionNotFoundException($"Session {id} not found");
                return session;
            }
            catch(Exception ex) when (ex is not SessionNotFoundException)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async System.Threading.Tasks.Task AddAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new Exception("User ID cannot be empty");

            try
            {
                var session = new domain.Session.Session
                {
                    UserId = userId,
                    SessionId = Guid.NewGuid().ToString()
                };
                repo.AddAsync(session);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async System.Threading.Tasks.Task DeleteAsync(string sessionId)
        {
            repo.DeleteAsync(sessionId);
        }
    }
}
