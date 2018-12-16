using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scrumy.Data;
using Scrumy.Models;

namespace Scrumy.Services
{
    public class SprintTaskService : ISprintTaskService
    {
        private readonly ApplicationDbContext _context;
        public void Create(SprintTask sprinttask)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SprintTask> GetAll()
        {
            return _context.SprintTasks.ToList();
        }

        public SprintTask GetSprintTaskByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
