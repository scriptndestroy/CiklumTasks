using CiklumTasks.Common;
using CiklumTasks.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiklumTasks.ApplicationServices
{
    public class TasksService: ITasksService
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

        public IEnumerable<TaskStatusDTO> GetTaskStatus()
        {
            return _tasksRepository.GetTaskStatus();
        }

        public async Task<IEnumerable<TaskDTO>> AddAsync(TaskDTO taskDto)
        {
            return await _tasksRepository.AddAsync(taskDto);
        }

        public async Task<IEnumerable<TaskDTO>> UpdateAsync(TaskDTO taskDto)
        {
            return await _tasksRepository.UpdateAsync(taskDto);
        }
        #endregion
    }
}
