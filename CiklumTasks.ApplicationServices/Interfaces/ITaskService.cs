using Ciklum.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ciklum.ApplicationServices.Interfaces
{
    public interface ITaskService
    {
        public IEnumerable<TaskDTO> GetAll();
    }
}
