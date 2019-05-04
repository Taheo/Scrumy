using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models.MixedVM;
using Scrumy.Models.SprintVM;
using Scrumy.Services;

namespace Scrumy.Controllers
{
    public class StatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISprintTaskService _sprintTaskService;
        private readonly ISprintService _sprintService;

        public StatsController(ApplicationDbContext context, ISprintTaskService sprintTaskService, ISprintService sprintService)
        {
            _context = context;
            _sprintTaskService = sprintTaskService;
            _sprintService = sprintService;
        }

        public ActionResult StatsMenu()
        {
            return View();
        }

        public ActionResult TaskStats()
        {
            var deliveredSP = new List<int>();
            var orderedSprints = _sprintService.GetDoneSprints().OrderBy(v => v.GenerationDate);
            foreach (var item in orderedSprints)
            {
                deliveredSP.Add(_sprintTaskService.GetDoneTasks().Where(x => x.SprintId == item.Id).Sum(z =>z.StoryPointsValue));
            }

            var convertedSP = deliveredSP;
            var settings = _context.ProjectSettings.FirstOrDefault();
            //check if model is ok?
            var model = new TaskStatsVM {
                EstimatedSPsum = settings.EstimatedSPsum,
                EstimatedTeamSpeed = settings.EstimatedTeamSpeed,
                SprintAmount = settings.SprintAmount,
            };

            ViewData["deliveredSP"] = convertedSP;

            return View(model);
        }

        public ActionResult SprintStats()
        {
            var model = new SprintStatsVM
            {
                Sprints = _context.Sprints.ToList(),
                Tasks = _context.SprintTasks.ToList()
            };

            return View(model);
        }
    }
}