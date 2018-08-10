﻿using System;
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

        public SprintTask()
        {
            Id = Guid.NewGuid();
        }
    }
}
