using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models
{
    public class SprintTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        public SprintTask()
        {
            Id = Guid.NewGuid();
        }
    }
}
