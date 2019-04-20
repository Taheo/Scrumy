using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.MixedVM
{
    public class RetroVM
    {
        public List<SprintTask> Tasks { get; set; }
        public List<Sprint> Sprints { get; set; }
        //public List<Opinion> Feedback { get; set; }
    }
}
