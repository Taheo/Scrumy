using Scrumy.Models.SprintTaskViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.MixedVM
{
    public class AgileWallVM
    {
        public List<SprintTask> TaskList { get; set; }
        public SprintTaskAddVM TaskToCreate { get; set; }
        public SprintTaskAddStoryPointsVM StoryPointsValueToAdd { get; set; }
    }
}