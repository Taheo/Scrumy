using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scrumy.Data;
using Scrumy.Models;

namespace Scrumy.Services
{
    public class SprintService : ISprintService
    {
        private readonly ApplicationDbContext _context;
        public SprintService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Sprint> GetAllSprints()
        {
            return _context.Sprints.ToList();
        }

        public List<Sprint> GetDoneSprints()
        {
            return _context.Sprints.Where(x => x.isDone == true).ToList();
        }
    }
}
