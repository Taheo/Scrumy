using System.Collections.Generic;

namespace Scrumy.Models.SprintVM
{
    public class SprintPlanVM
    {
        public SprintAddVM SprintToCreate { get; set; }
        public List<SprintTask> TasksToDiscuss { get; set; }
    }
}
