using CiklumTasks.ApplicationServices.Interfaces;
using CiklumTasks.Common;
using CiklumTasks.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CiklumTasks.ApplicationServices
{
    public class TasksService: ITaskService
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly ILogger<TasksService> _logger;

        #region Constructor
        public TasksService(ITasksRepository tasksRepository, ILogger<TasksService> logger)
        {
            _tasksRepository = tasksRepository;
            _logger = logger;
        }
        #endregion

        #region Public Methods
        public IEnumerable<TaskDTO> GetAll()
        {
            return _tasksRepository.GetAll();
        }
        #endregion
    }
}
