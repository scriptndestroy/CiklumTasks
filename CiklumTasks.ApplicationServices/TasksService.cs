using Ciklum.ApplicationServices.Interfaces;
using Ciklum.Common;
using Ciklum.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ciklum.ApplicationServices
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
