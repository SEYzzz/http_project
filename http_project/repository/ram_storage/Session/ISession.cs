using http_project.domain.Session;
namespace http_project.repository.ram_storage.Session
{
    public interface ISession
    {
        public domain.Session.Session? GetById(string sessionId);
        public System.Threading.Tasks.Task AddAsync(domain.Session.Session session);
        public System.Threading.Tasks.Task DeleteAsync(string sessionId);
    }
}
