﻿using Scrumy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Services
{
    public interface ISprintTaskService
    {
        List<SprintTask> GetAll();
        //SprintTask GetSprintTaskByID(Guid id);
        //void Create(SprintTask sprinttask);
        //void Delete(Guid id);
    }
}
