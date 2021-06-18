using CiklumTasks.Common;
using System.Collections.Generic;

namespace CiklumTasks.Repositories
{
    public interface ITasksRepository
    {
        public IEnumerable<TaskDTO> GetAll();
    }
}
