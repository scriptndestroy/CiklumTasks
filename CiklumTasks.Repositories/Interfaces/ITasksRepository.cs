using CiklumTasks.Common;
using System.Collections.Generic;

namespace CiklumTasks.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        public IEnumerable<TaskDTO> GetAll();
    }
}
