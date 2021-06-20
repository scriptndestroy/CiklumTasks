using CiklumTasks.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiklumTasks.ApplicationServices
{
    public interface ITasksService
    {
        public IEnumerable<TaskDTO> GetAll();

        public IEnumerable<TaskStatusDTO> GetTaskStatus();

        public Task<IEnumerable<TaskDTO>> AddAsync(TaskDTO taskDto);

        public Task<IEnumerable<TaskDTO>> UpdateAsync(TaskDTO taskDto);
    }
}
