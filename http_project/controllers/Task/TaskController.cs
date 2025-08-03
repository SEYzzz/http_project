using Microsoft.AspNetCore.Mvc;

namespace http_project.controllers.Task
{
    [ApiController]
    [Route("")]
    public class TaskController : Controller
    {
        private readonly usecases.Task.ITask service;

        public TaskController(usecases.Task.ITask service)
        {
            this.service = service;
        }

        [HttpGet("task")]
        public async Task<IActionResult> CreateTask()
        {
            var taskId = await service.CreateTaskAsync();
            return Ok(new { task_id = taskId }); 
        }

        [HttpGet("status/{taskId}")]
        public async Task<IActionResult> GetStatus(Guid taskId)
        {
            try
            {
                var status = await service.GetTaskStatusAsync(taskId);
                return Ok(new { status = status.ToString().ToLower() });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("result/{taskId}")]
        public async Task<IActionResult> GetResult(Guid taskId)
        {
            try
            {
                var result = service.GetTaskResultAsync(taskId);
                return Ok(new { result = result.ToString().ToLower() });
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

        [HttpGet("task/{taskId}")]
        public async Task<IActionResult> GetTask(Guid taskId)
        {
            try
            {
                var task = service.GetById(taskId);
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
