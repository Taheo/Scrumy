using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Scrumy.Models.RetroVM
{
    public class OpinionAddVM
    {
        [DisplayName("Is opinion Positive?")]
        public bool OpinionType { get; set; }
        [DisplayName("Insert your opinion")]
        public string Comment { get; set; }
        [DisplayName("Which Sprint you want to get feedback?")]
        public Guid SprintId { get; set; }
        public List<SelectListItem> Sprints { get; set; }

    }
}