using CiklumTasks.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiklumTasks.Repositories
{
    public interface ITasksRepository
    {
        public IEnumerable<TaskDTO> GetAll();

        public Task<IEnumerable<TaskDTO>> AddAsync(TaskDTO taskDto);
    }
}
