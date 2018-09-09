using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models
{
    public class Slide
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }

        public Slide()
        {
            Id = new Guid();
        }
    }
}
