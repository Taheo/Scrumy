using Scrumy.Models.SprintTaskViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.SprintVM
{
    public class SprintPlanVM
    {
        public SprintAddVM SprintToCreate { get; set; }
        public List<SprintTask> TasksToDiscuss { get; set; }
    }
}
