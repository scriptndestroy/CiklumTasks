using CiklumTasks.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiklumTasks.ApplicationServices
{
    public interface ITasksService
    {
        public IEnumerable<TaskDTO> GetAll();

        public Task<IEnumerable<TaskDTO>> AddAsync(TaskDTO taskDto);
    }
}
