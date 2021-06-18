using CiklumTasks.Common;
using System.Collections.Generic;

namespace CiklumTasks.ApplicationServices.Interfaces
{
    public interface ITaskService
    {
        public IEnumerable<TaskDTO> GetAll();
    }
}
