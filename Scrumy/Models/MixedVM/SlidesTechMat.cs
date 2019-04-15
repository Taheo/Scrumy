using Scrumy.Models.SlidesViewModel;
using Scrumy.Models.TeachingMaterialsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models.MixedVM
{
    public class SlidesTechMat
    {
        public List<Slide> SlideSet { get; set; }
        public List<TeachingMaterial> TechMatSet { get; set; }
        public TeachingMaterialAddVM TeachingMaterial { get; set; }
        public SlideAddVM Slide { get; set; }
    }
}
