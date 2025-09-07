using http_project.domain.Session;
namespace http_project.repository.ram_storage.Session
{
    public class Session : ISession
    {
        private Dictionary<string, domain.Session.Session> data = new Dictionary<string, domain.Session.Session>();

        public domain.Session.Session GetById(string sessionId)
        {
            return data?.Values?.FirstOrDefault(s => s.SessionId.Equals(sessionId));  // Проверку на null куда лучше запихнуть?
        }

        public async System.Threading.Tasks.Task AddAsync(domain.Session.Session session)
        {
            data.Add(session.SessionId, session);
        }

        public async System.Threading.Tasks.Task DeleteAsync(string sessionId)
        {
            data.Remove(sessionId);
        }
    }
}
