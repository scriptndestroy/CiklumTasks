using CiklumTasks.Common;
using System.Collections.Generic;

namespace CiklumTasks.ApplicationServices
{
    public interface ITasksService
    {
        public IEnumerable<TaskDTO> GetAll();
    }
}
