using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.SlidesViewModel
{
    public class EditSlideVM
    {
        public Guid SlideId { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }
        public List<SelectListItem> SlidesToSelect { get; set; }
    }
}
