using http_project.domain.Session;
using http_project.domain.Exceptions;
namespace http_project.repository.ram_storage.Session
{
    public class Session : ISession
    {
        private Dictionary<string, domain.Session.Session> data = new Dictionary<string, domain.Session.Session>();

        public domain.Session.Session? GetById(string sessionId)
        {
            try
            {
                return data.GetValueOrDefault(sessionId);
            }
            catch(Exception ex)
            {
                throw new RepositoryException("Failed to get session", ex);
            }
        }

        public async System.Threading.Tasks.Task AddAsync(domain.Session.Session session)
        {
            try
            {
                if (data.ContainsKey(session.SessionId))
                    throw new SessionAlreadyExistsException($"Session {session.SessionId} already exists");
                data.Add(session.SessionId, session);
            }
            catch (Exception ex) when (ex is not SessionAlreadyExistsException)
            {
                throw new RepositoryException("Failed to add session", ex);
            }
        }

        public async System.Threading.Tasks.Task DeleteAsync(string sessionId)
        {
            try
            {
                //if (!data.ContainsKey(sessionId))
                //    throw new SessionNotFoundException($"Session {sessionId} not found");
                data.Remove(sessionId);
            }
            catch(Exception ex) when (ex is not SessionNotFoundException)
            {
                throw new RepositoryException("Failed to delete session", ex);
            }
        }
    }
}
