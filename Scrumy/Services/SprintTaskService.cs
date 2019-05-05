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

        public SprintTaskService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SprintTask> GetAll()
        {
            return _context.SprintTasks.ToList();
        }

        public List<SprintTask> GetDoneTasks()
        {
            return _context.SprintTasks.Where(x => x.isDone == true).ToList();
        }

        public List<SprintTask> GetTasksInCurrentSprintWithoutSPValue()
        {
            return _context.SprintTasks.Where(x => x.isInCurrentSprint == true && x.StoryPointsValue == 0).ToList();
        }
    }
}
