using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.SprintTaskViewModel
{
    public class SprintTaskAddStoryPointsVM
    {
        public int StoryPointsValue { get; set; }
        public Guid SprintTaskId { get; set; }
        public List<SelectListItem> TasksToSelect { get; set; }
    }
}
