using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models.SprintVM;

namespace Scrumy.Controllers
{
    public class StatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult StatsMenu()
        {
            return View();
        }

        public ActionResult TaskStats()
        {
            //check if model is ok?
            var model = _context.SprintTasks.ToList();
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