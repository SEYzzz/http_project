using http_project.domain.Session;
using Microsoft.AspNetCore.Mvc;

namespace http_project.usecases.Session
{
    public interface ISession
    {
        public Task<ActionResult<domain.Session.Session>> GetById(string id);
        public Task<ActionResult<System.Threading.Tasks.Task>> AddAsync(domain.Session.Session session); // Что за идиотизм с таск?
        public Task<ActionResult<System.Threading.Tasks.Task>> DeleteAsync(string sessionId); // Посмотреть как это убрать красиво чтобы было
    }
}
