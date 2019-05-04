using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models
{
    public class ProjectSettings
    {
        public Guid Id { get; set; }
        public int EstimatedTeamSpeed { get; set; }
        public int EstimatedSPsum { get; set; }
        public int SprintAmount { get; set; }
        public int SprintLength { get; set; }
        public ProjectSettings()
        {
            Id = Guid.NewGuid();
        }
    }
}
