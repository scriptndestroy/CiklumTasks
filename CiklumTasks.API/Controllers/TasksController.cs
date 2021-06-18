using Ciklum.ApplicationServices;
using Ciklum.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiklumTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _tasks;

        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger, TasksService tasks)
        {
            _tasks = tasks;
            _logger = logger;
        }

        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        //[Route("search")]
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
    }
}
