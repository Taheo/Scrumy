using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.RetroVM
{
    public class OpinionAddVM
    {
        [DisplayName("Is opinion Positive?")]
        public bool OpinionType { get; set; }
        public string Comment { get; set; }
        [DisplayName("Sprint identifier which you are editing")]
        public Guid SprintId { get; set; }
    }
}