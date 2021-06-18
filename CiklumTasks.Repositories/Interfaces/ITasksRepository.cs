using Ciklum.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciklum.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        public IEnumerable<TaskDTO> GetAll();
    }
}
