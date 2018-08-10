using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.SprintTaskViewModel
{
    public class SprintTaskAddVM
    {
        [Required]
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
