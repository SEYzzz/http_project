using Microsoft.AspNetCore.Mvc;

namespace http_project.controllers.Task
{
    /// <summary>
    /// Контроллер таски.
    /// </summary>
    [ApiController]
    [Route("")]
    public class TaskController : Controller
    {
        private readonly usecases.Task.ITask service;

        public TaskController(usecases.Task.ITask service)
        {
            this.service = service;
        }

        /// <summary>
        /// Создаёт и добавляет новую таску.
        /// </summary>
        /// <returns>ID новой таски</returns>
        [HttpGet("task")]
        public async Task<ActionResult<Guid>> CreateTask()
        {
            var taskId = await service.CreateTaskAsync();
            return Ok(new { task_id = taskId }); 
        }

        /// <summary>
        /// Получение статуса таски.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("status/{taskId}")]
        public async Task<ActionResult<string?>> GetStatus(Guid taskId)
        {
            try
            {
                var status = await service.GetTaskStatusAsync(taskId);
                return Ok(new { status = status.Value.ToString().ToLower() });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получение результата таски.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("result/{taskId}")]
        public async Task<ActionResult<string?>> GetResult(Guid taskId)
        {
            try
            {
                var result = await service.GetTaskResultAsync(taskId);
                return Ok(new { result = result.Value!.ToString().ToLower() });
            }
            catch(InvalidOperationException e)
            {
                return BadRequest("Task is not ready");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить таску.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("task/{taskId}")]
        public async Task<ActionResult<domain.Task.Task?>> GetTask(Guid taskId)
        {
            try
            {
                var task = await service.GetById(taskId);
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
