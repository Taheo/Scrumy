using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models
{
    public class SprintTask
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool isDone { get; set; }
        public bool isInCurrentSprint { get; set; }

        public SprintTask()
        {
            Id = Guid.NewGuid();
        }
    }
}
