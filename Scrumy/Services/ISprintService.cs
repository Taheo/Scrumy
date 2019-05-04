using Scrumy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumy.Services
{
    public interface ISprintService
    {
        List<Sprint> GetAllSprints();
        List<Sprint> GetDoneSprints();
        Sprint GetCurrentSprint();
    }
}
