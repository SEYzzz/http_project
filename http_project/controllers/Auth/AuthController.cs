using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace http_project.controllers.Auth
{
    /// <summary>
    /// Контроллер аутентификации и авторизации
    /// </summary>
    [Controller]
    [Route("/")]
    public class AuthController : Controller
    {
        private readonly usecases.User.IUser userService;
        private readonly usecases.Session.ISession sessionService;

        public AuthController(usecases.User.IUser userService,  usecases.Session.ISession sessionService)
        {
            this.userService = userService;
            this.sessionService = sessionService;
        }
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>Guid зарегистрированного пользователя</returns>
        [HttpGet("/register")]
        public async Task<ActionResult<Guid>> Register(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return BadRequest("Login and password are required");

            var userId = await userService.AddUserAsync(login, password);
            await sessionService.AddAsync(userId);
            return Ok(new { userID = userId });
        }

        /// <summary>
        /// Авторизация пользователя 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        [HttpPost("/login")]
        public async Task<ActionResult> Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return BadRequest("Login and password are required");

            try
            {
                var user = await userService.GetByLoginAsync(login); // Проверка пароля и тд где
                await sessionService.AddAsync(user.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // можно что-то КРОМЕ BadRequest возвращать????
            }
        }
    }
}
