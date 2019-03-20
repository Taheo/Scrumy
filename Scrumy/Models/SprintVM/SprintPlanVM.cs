using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.SprintVM
{
    public class SprintPlanVM
    {
        public Sprint SprintToCreate { get; set; }
        public List<SprintTask> TaskToDiscuss { get; set; }
    }
}
