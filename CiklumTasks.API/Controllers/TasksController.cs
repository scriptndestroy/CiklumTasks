using CiklumTasks.ApplicationServices;
using CiklumTasks.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiklumTasks.API.Controllers
{    
    [Route("[controller]")]
    [EnableCors("CiklumPolicy")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasks;

        private readonly ILogger<TasksController> _logger;

        public TasksController(ITasksService tasks, ILogger<TasksController> logger)
        {
            _tasks = tasks;
            _logger = logger;
        }

        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]        
        public IActionResult Get()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _tasks.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(this.ControllerContext.RouteData.Values["action"].ToString(), ex);
                return BadRequest(this.ControllerContext.RouteData.Values["action"].ToString());
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskDTO>> PostTask(TaskDTO taskDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _tasks.AddAsync(taskDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(this.ControllerContext.RouteData.Values["action"].ToString(), ex);
                return BadRequest(this.ControllerContext.RouteData.Values["action"].ToString());
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<TaskDTO>> PutTask(TaskDTO taskDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _tasks.UpdateAsync(taskDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(this.ControllerContext.RouteData.Values["action"].ToString(), ex);
                return BadRequest(this.ControllerContext.RouteData.Values["action"].ToString());
                throw;
            }
        }

        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [Route("taskStatus")]
        public IActionResult GetTaskStatus()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _tasks.GetTaskStatus();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(this.ControllerContext.RouteData.Values["action"].ToString(), ex);
                return BadRequest(this.ControllerContext.RouteData.Values["action"].ToString());
                throw;
            }
        }
    }
}
