using CiklumTasks.Common;
using CiklumTasks.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CiklumTasks.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly Context _context;

        #region Constructor
        public TasksRepository(Context context)
        {
            _context = context;
        }
        #endregion

        #region Public methods
        public IEnumerable<TaskDTO> GetAll()
        {
            try
            {
                IEnumerable<TaskDTO> tasks = from t in _context.Tasks
                                             select new TaskDTO()
                                             {
                                                 Id = t.Id
                                             };
                return tasks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async System.Threading.Tasks.Task<IEnumerable<TaskDTO>> AddAsync(TaskDTO taskDto)
        {
            try
            {
                _context.Tasks.Add(new Task {
                     Description = taskDto.Description,
                     Status = taskDto.Status,
                     Title = taskDto.Title
                });
                await _context.SaveChangesAsync();
                IEnumerable<TaskDTO> tasks = from t in _context.Tasks
                                             select new TaskDTO()
                                             {
                                                 Id = t.Id,
                                                 Title = t.Title,
                                                 Status = t.Status,
                                                 Description = t.Description
                                             };
                return tasks;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
