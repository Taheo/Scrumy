using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models
{
    public class Sprint
    {
        public Guid Id { get; set; }
        public string SprintTarget { get; set; }
        public bool isDone { get; set; }

        public Sprint()
        {
            Id = Guid.NewGuid();
        }
    }
}
