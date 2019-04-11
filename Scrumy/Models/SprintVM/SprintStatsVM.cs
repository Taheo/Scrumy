using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.SprintVM
{
    public class SprintStatsVM
    {
        public List<Sprint> Sprints { get; set; }
        public List<SprintTask> Tasks { get; set; }
    }
}
