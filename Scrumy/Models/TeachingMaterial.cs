using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models
{
    public class TeachingMaterial
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
        public string Note { get; set; }
        public TeachingMaterial()
        {
            Id = Guid.NewGuid();
        }
    }
}
