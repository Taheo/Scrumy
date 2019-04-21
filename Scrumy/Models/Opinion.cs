using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Models
{
    public class Opinion
    {
        public Guid Id { get; set; }
        public bool OpinionType { get; set; }
        public string Comment { get; set; }
        public DateTime AddedAt { get; set; }
        public string Author { get; set; }
        public Opinion(string currentUser)
        {
            Id = Guid.NewGuid();
            AddedAt = DateTime.Today;
            Author = currentUser;
        }
    }
}
