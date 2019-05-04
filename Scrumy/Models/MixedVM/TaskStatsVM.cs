using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrumy.Models.MixedVM
{
    public class TaskStatsVM
    {
        //public string[] DeliveredStoryPoints { get; set; }
        public int EstimatedTeamSpeed { get; set; }
        public int EstimatedSPsum { get; set; }
        public int SprintAmount { get; set; }
    }
}
