using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.TeachingMaterialsVM
{
    public class EditTeachingMaterialVM
    {
        public string Link { get; set; }
        public string Note { get; set; }

        public Guid TeachingMaterialId { get; set; }

        public List<SelectListItem> TeachingMaterialsToSelect { get; set; }
    }
}
